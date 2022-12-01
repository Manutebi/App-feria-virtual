using BespokeFusion;
using MaterialDesignThemes.Wpf;
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
    /// Lógica de interacción para Addcontratos.xaml
    /// </summary>
    public partial class Addcontratos : Window
    {
        OracleConnection conn = null;
        public Addcontratos(Contratos contratos)
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
                MessageBox.Show("Error de conexion");
                throw new Exception("Error de conexion");
            }

        }

        private void cargarIDUser2()
        {
            cbIdUser2.SelectedValue = 0;
            try
            {
                OracleCommand comando = new OracleCommand("listar_user", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                cbIdUser2.SelectedValuePath = "ID_USUARIO";
                cbIdUser2.DisplayMemberPath = "NOMBRE";
                cbIdUser2.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer usuario");
            }
        }
        
       

        private void CbIdContrato_Loaded(object sender, RoutedEventArgs e)
        {
            cargarIDUser2();
        }
       

        private void GuardarContrato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime f1 = Convert.ToDateTime(string.Format("{0:yyyy-mm-dd}", fecha_InDate));
                DateTime f2 = Convert.ToDateTime(string.Format("{0:yyyy-mm-dd}", fecha_TerDate));
                OracleCommand comando = new OracleCommand("agregar_contrato", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("fecha_ini", OracleDbType.Date).Value = f1;
                comando.Parameters.Add("fecha_ter", OracleDbType.Date).Value = f2;
                comando.Parameters.Add("contrato", OracleDbType.Int32).Value = 1;
                comando.Parameters.Add("usuario", OracleDbType.Varchar2).Value = Convert.ToInt32(cbIdUser2.SelectedValue);
                comando.ExecuteNonQuery();
                MaterialMessageBox.Show("Contrato guardado con exito.");

                Close();
                cargarIDUser2();
                Agregar();
                
            }
            catch (Exception)
            {
                MaterialMessageBox.ShowError("Algo fallo en el guardado de contrato, asegurate de rellenar todas las casillas.");
            }
        }
        
       

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
