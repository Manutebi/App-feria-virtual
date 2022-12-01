using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Deployment.Internal;
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
using static maipoGrande.Pages.Addsubastas;
using static System.Resources.ResXFileRef;

namespace maipoGrande.Pages
{
    /// <summary>
    /// Lógica de interacción para Addsubastas.xaml
    /// </summary>
    public partial class Addsubastas : Window
    {
        int id;
        OracleConnection conn = null;
        public Addsubastas(int id)
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
        private void obtenerPDV(string id_pdv)
        {
            OracleCommand cmd = new OracleCommand("SELECT * FROM pdv WHERE id_pdv = :id_pdv", conn);
            cmd.Parameters.Add(":id_pdv", id_pdv);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            precioPdv.Text = dt.Rows[0]["PRECIO_TOTAL"].ToString();
            cbIdPdv.SelectedValue = id_pdv;
            if (dt.Rows[0]["TIPO_LOCAL"].ToString() == "0"){
                RbLocalNo.IsChecked = true;
            }
            else{
                RbLocalSi.IsChecked = true;
            }
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
        private void GuardarSubasta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OracleCommand comando = new OracleCommand("agregar_subastas", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("fecha_p", OracleDbType.Date).Value = DateTime.Today;
                comando.Parameters.Add("fecha_t", OracleDbType.Date).Value = Convert.ToDateTime(string.Format("{0:yyyy-mm-dd}", fechaTerminoSubasta));
                comando.Parameters.Add("cond_c", OracleDbType.Int32).Value = Convert.ToInt32(condCarga.SelectedValue);
                comando.Parameters.Add("cond_t", OracleDbType.Int32).Value = Convert.ToInt32(condTamano.SelectedValue);
                comando.Parameters.Add("cond_r", OracleDbType.Int32).Value = Convert.ToInt32(condRefrigeracion.SelectedValue);
                comando.Parameters.Add("valor_i", OracleDbType.Int32).Value = 0;
                comando.Parameters.Add("pdv", OracleDbType.Int32).Value = Convert.ToInt32(cbIdPdv.SelectedValue);
                comando.Parameters.Add("estado_s", OracleDbType.Int32).Value = Convert.ToInt32(CbEstadoSubasta.SelectedValue);
                comando.Parameters.Add("precio_pdv", OracleDbType.Int32).Value = Convert.ToInt32(precioPdv.Text);
                if (RbLocalNo.IsChecked == true)
                {
                    comando.Parameters.Add("tipo_pdv", OracleDbType.Int32).Value = 0;
                }
                else
                {
                    comando.Parameters.Add("tipo_pdv", OracleDbType.Int32).Value = 1;
                }

                try
                {
                    OracleCommand comando2 = new OracleCommand("eliminar_pdv", conn);
                    comando2.CommandType = System.Data.CommandType.StoredProcedure;
                    comando2.Parameters.Add("idp", OracleDbType.Int32).Value = id;
                    comando.ExecuteNonQuery();
                    comando2.ExecuteNonQuery();
                    MessageBox.Show("Proceso de venta eliminado con exito");
                    MessageBox.Show("Subasta guardada en la base de datos.");
                    Agregar();
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Algo ha salido mal al eliminar el proceso de venta.");
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo en el guardado de la subasta, asegurate de rellenar todas las casillas.");
            }
        }
        private void cargarIdPdv()
        {
            try
            {
                OracleCommand comando = new OracleCommand("listar_pdv", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                cbIdPdv.SelectedValuePath = "ID_PDV";
                cbIdPdv.DisplayMemberPath = "ID_PDV";
                cbIdPdv.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer ID PDV");
            }
        }
        private void cargarIdEstadoSubasta()
        {
            try
            {
                OracleCommand comando = new OracleCommand("listar_estado_subasta", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                CbEstadoSubasta.SelectedValuePath = "ID_ESTADO";
                CbEstadoSubasta.DisplayMemberPath = "D_ESTADO";
                CbEstadoSubasta.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer ID ESTADO SUBASTA");
            }
        }
        private void CbEstadoSubasta_Loaded(object sender, RoutedEventArgs e)
        {
            cargarIdEstadoSubasta();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            string id_pdv = Convert.ToString(id);
            obtenerPDV(id_pdv);
        }

        private void cbIdPdv_Loaded(object sender, RoutedEventArgs e)
        {
            cargarIdPdv();
        }

        private void condTamano_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Tamano> tamano = new ObservableCollection<Tamano>();

            tamano.Add(new Tamano { tamano = "100" });
            tamano.Add(new Tamano { tamano = "200" });
            tamano.Add(new Tamano { tamano = "300" });
            tamano.Add(new Tamano { tamano = "400" });
            condTamano.SelectedValuePath = "tamano";
            condTamano.DisplayMemberPath = "tamano";
            condTamano.ItemsSource = tamano;

        }
        private void condCarga_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Carga> carga = new ObservableCollection<Carga>();

            carga.Add(new Carga { carga = "1000" });
            carga.Add(new Carga { carga = "2000" });
            carga.Add(new Carga { carga = "3000" });
            carga.Add(new Carga { carga = "4000" });
            condCarga.SelectedValuePath = "carga";
            condCarga.DisplayMemberPath = "carga";
            condCarga.ItemsSource = carga;
        }
        private void condRefrigeracion_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Refrigeracion> refrigeracion = new ObservableCollection<Refrigeracion>();

            refrigeracion.Add(new Refrigeracion { refrigeracion = "0" });
            refrigeracion.Add(new Refrigeracion { refrigeracion = "1" });
            condRefrigeracion.SelectedValuePath = "refrigeracion";
            condRefrigeracion.DisplayMemberPath = "refrigeracion";
            condRefrigeracion.ItemsSource = refrigeracion;
        }
        public class Tamano
        {
            public String tamano { get; set; }
        }
        public class Carga
        {
            public String carga { get; set; }
        }
        public class Refrigeracion
        {
            public String refrigeracion { get; set; }
        }

    }
}
