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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace maipoGrande.Pages
{
    /// <summary>
    /// Lógica de interacción para Subastas.xaml
    /// </summary>
    public partial class Subastas : Page
    {
        OracleConnection conn = null;
        public Subastas()
        {
            InitializeComponent();
            abrirConexion();
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
        private void add_subastas(object sender, RoutedEventArgs e)
        {
        }
        private void cargarSubastaDG()
        {
            try
            {
                OracleCommand comando = new OracleCommand("listar_subasta", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                listadoSubastas.ItemsSource = lista.DefaultView;

            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar usuario");
            }
        }
        private void listadoSubastas_Loaded(object sender, RoutedEventArgs e)
        {
            cargarSubastaDG();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Decimal id = (Decimal)((Button)sender).CommandParameter;
            //new Updateusuarios(Convert.ToInt32(id)).Show();
            UpdateSubastas objupdatesubastas = new UpdateSubastas(Convert.ToInt32(id));
            objupdatesubastas.UpdateEventHandler += ActuUpdateEventHandler;
            objupdatesubastas.Show();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Decimal id = (Decimal)((Button)sender).CommandParameter;
            //new Updateusuarios(Convert.ToInt32(id)).Show();
            AddEstadisticas objaddestadisticas = new AddEstadisticas(Convert.ToInt32(id));
            objaddestadisticas.UpdateEventHandler += ActuUpdateEventHandler;
            objaddestadisticas.Show();
        }
        private void ActuUpdateEventHandler(object sender, UpdateSubastas.UpdateEventArgs args)
        {
            cargarSubastaDG();
        }
        private void ActuUpdateEventHandler(object sender, AddEstadisticas.UpdateEventArgs args)
        {
            cargarSubastaDG();
        }

    }
}
