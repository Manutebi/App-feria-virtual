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

namespace maipoGrande.Pages
{
    /// <summary>
    /// Lógica de interacción para Addpdv.xaml
    /// </summary>
    public partial class Addpdv : Window
    {
        OracleConnection conn = null;
        public Addpdv(Procesos procesos)
        {
            InitializeComponent();
            abrirConexion();
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




       
        private void cargarUpdatePDV(string id_pdv)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM pdv WHERE id_pdv = :id_pdv", conn);
                cmd.Parameters.Add(":id_pdv", id_pdv);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                fechaFinBox.Text = dt.Rows[0]["FECHA_TERMINO"].ToString();
                cbIdSolicitud.SelectedValue = dt.Rows[0]["SOLICITUD_COMPRA_ID_SOLICITUD"].ToString();
                cbIdEstadoPDV.SelectedValue = dt.Rows[0]["ESTADO_PDV_ID_ESTADOPDV"].ToString();
                string activo = dt.Rows[0]["TIPO_LOCAL"].ToString();
                if (activo == "1") { VentaLocalSi.IsChecked = true; }
                else { VentaLocalNo.IsChecked = true; }
            }
            catch (Exception ex)
            {
            }
        }
        private void cargarIdSolicitud()
        {
            cbIdSolicitud.SelectedValue = 0;
            try
            {
                OracleCommand comando = new OracleCommand("listar_solicitud_compra", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                cbIdSolicitud.SelectedValuePath = "ID_SOLICITUD";
                cbIdSolicitud.DisplayMemberPath = "ID_SOLICITUD";
                cbIdSolicitud.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar id de solicitud en el combobox");

            }

        }



        private void cargarIdEstado()
        {
            cbIdEstadoPDV.SelectedValue = 0;
            try
            {
                OracleCommand comando = new OracleCommand("listar_estado_pdv", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                cbIdEstadoPDV.SelectedValuePath = "ID_ESTADOPDV";
                cbIdEstadoPDV.DisplayMemberPath = "D_ESTADOPDV";
                cbIdEstadoPDV.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la id de estado en el combobox");
            }
        }
        private void Guardar_proceso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numero = 2;
                OracleCommand comando = new OracleCommand("agregar_pdv", conn);
                OracleCommand cmd = new OracleCommand("actualizar_solicitud_compra_estado", conn);
                cmd.Parameters.Add("idp", OracleDbType.Int32).Value = Convert.ToInt32(cbIdSolicitud.SelectedValue);
                cmd.Parameters.Add("estado", OracleDbType.Int32).Value = numero;
                DateTime f1a = DateTime.Today;
                DateTime f2a = Convert.ToDateTime(string.Format("{0:yyyy-mm-dd}", fechaFinBox));

                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("fecha_ini", OracleDbType.Date).Value = f1a;
                comando.Parameters.Add("fecha_ter", OracleDbType.Date).Value = f2a;
                comando.Parameters.Add("ctdad_reunida", OracleDbType.Int32).Value = 0;
                comando.Parameters.Add("precio_total", OracleDbType.Int32).Value = 0;
                comando.Parameters.Add("estado", OracleDbType.Int32).Value = Convert.ToInt32(cbIdEstadoPDV.SelectedValue);
                comando.Parameters.Add("solicitud", OracleDbType.Int32).Value = Convert.ToInt32(cbIdSolicitud.SelectedValue);
                if (VentaLocalSi.IsChecked == true) { comando.Parameters.Add("local", OracleDbType.Int32).Value = 1; }
                else { comando.Parameters.Add("local", OracleDbType.Int32).Value = 0; }
                comando.ExecuteNonQuery();

                MessageBox.Show("proceso Guardado en la base de datos.");
                cbIdEstadoPDV.SelectedValue = 0;
                cbIdSolicitud.SelectedValue = 0;
                Agregar();
                Close();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo en la creacion del proceso de compra, asegurate de rellenar todas las casillas.");
            }
        }
       
       

     
       
        private void CbIdSolicitud_Loaded(object sender, RoutedEventArgs e)
        {
            cargarIdSolicitud();
        }
        private void CbIdEstadoPDV_Loaded(object sender, RoutedEventArgs e)
        {
            cargarIdEstado();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
            
        }


    }
}
