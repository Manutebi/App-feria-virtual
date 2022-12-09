using MimeKit;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;


namespace maipoGrande.Pages
{
    /// <summary>
    /// Lógica de interacción para AddEstadisticas.xaml
    /// </summary>
    public partial class AddEstadisticas : Window
    {
        int id;
        OracleConnection conn = null;
        public AddEstadisticas(int id)
        {
            InitializeComponent();
            abrirConexion();
            this.id = id;
        }
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }

        }
        protected void Agregar()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }
        private void abrirConexion()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["oracleDB"].ConnectionString;
            conn = new OracleConnection(ConnectionString);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexion :O");
                throw new Exception("Error de conexion");
            }

        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void obtenerSubasta(string id_subasta)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM subasta WHERE id_subasta = :id_subasta", conn);
                cmd.Parameters.Add(":id_subasta", id_subasta);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                String Fecha;
                SubastaId.Text = dt.Rows[0]["ID_SUBASTA"].ToString();
                PrecioPdv.Text = dt.Rows[0]["PRECIO_PDV"].ToString();
                ValorSubasta.Text = dt.Rows[0]["VALOR_INICIAL"].ToString();
                Fecha = dt.Rows[0]["FECHA_TERMINO_SUB"].ToString();
                DateTime fecha = Convert.ToDateTime(Fecha);
                int mes = fecha.Month;
                CbFechaAsignada.SelectedValue = mes;

                if (dt.Rows[0]["TIPO_PDV"].ToString() == "0")
                {
                    RbLocalNo.IsChecked = true;
                }
                else
                {
                    RbLocalSi.IsChecked = true;
                }
                
            }
            catch (Exception ex)
            { }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            string id_subasta = Convert.ToString(id);
            obtenerSubasta(id_subasta);
        }

        private void cargarIdFecha() 
        {
            try
            {
                OracleCommand comando = new OracleCommand("listar_fecha", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                CbFechaAsignada.SelectedValuePath = "ID_FECHA";
                CbFechaAsignada.DisplayMemberPath = "NOMBRE_MES";
                CbFechaAsignada.ItemsSource = lista.DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al leer la fecha");
            }
        }
        private void CbFechaAsignada_Loaded(object sender, RoutedEventArgs e)
        {
            cargarIdFecha();
        }

        private void GuardarSubasta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OracleCommand comando = new OracleCommand("agregar_estadisticas", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("id_subasta", OracleDbType.Int32).Value = Convert.ToInt32(SubastaId.Text);
                comando.Parameters.Add("precio", OracleDbType.Int32).Value = Convert.ToInt32(PrecioPdv.Text);
                if (RbLocalNo.IsChecked == true) { comando.Parameters.Add("tipo", OracleDbType.Int32).Value = 0; }
                else { comando.Parameters.Add("tipo", OracleDbType.Int32).Value = 1; }
                comando.Parameters.Add("precio_subasta", OracleDbType.Int32).Value = Convert.ToInt32(ValorSubasta.Text);
                comando.Parameters.Add("fecha_id", OracleDbType.Int32).Value = Convert.ToInt32(CbFechaAsignada.SelectedValue);

                try
                {
                    OracleCommand comando2 = new OracleCommand("eliminar_subastas", conn);
                    comando2.CommandType = System.Data.CommandType.StoredProcedure;
                    comando2.Parameters.Add("idp", OracleDbType.Int32).Value = id;
                    try {
                        //FALTA EL CORREO :)
                        comando.ExecuteNonQuery();
                        comando2.ExecuteNonQuery();
              

                        String Servidor = "smtp.gmail.com";
                        int Puerto = 587;

                        String GmailUser = "manuanigar@gmail.com";
                        String GmailPass = "zwcd lzpb omzi edyx";

                        MimeMessage mensaje = new MimeMessage();
                        mensaje.From.Add(new MailboxAddress("Pruebads", GmailUser));
                        mensaje.To.Add(new MailboxAddress("destiuon", GmailUser));
                        mensaje.Subject = "Hola";

                        BodyBuilder CuerpoMensaje = new BodyBuilder();
                        CuerpoMensaje.TextBody = "Hola";
                        CuerpoMensaje.HtmlBody = "Hola <b>Hola</b>";

                        SmtpClient ClienteSmtp = new SmtpClient();
                        ClienteSmtp.CheckCertificateRevocation = false;
                        ClienteSmtp.Connect(Servidor, Puerto, MailKit.Security.SecureSocketOptions.StartTls);
                        ClienteSmtp.Authenticate(GmailUser, GmailPass);
                        ClienteSmtp.Send(mensaje);
                        ClienteSmtp.Disconnect(true);

                        MessageBox.Show("Subasta completada con exito");
                        MessageBox.Show("Datos de la venta guardados con exito.");
                        MessageBox.Show("Notificación enviada al correo del cliente");






                        Agregar();
                        Close();
                    }
                    catch { }
                }
                catch (Exception)
                {
                    MessageBox.Show("Algo ha salido mal al eliminar el proceso de venta.");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo en el guardado de los datos, asegurate de rellenar todas las casillas.");
            }
        }
    }
}
