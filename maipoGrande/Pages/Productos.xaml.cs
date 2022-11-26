using System;
using System.Collections.Generic;
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
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
using maipoGrandeDatos;
using Microsoft.Win32;
using System.Windows.Navigation;

namespace maipoGrande.Pages
{
    /// <summary>
    /// Lógica de interacción para Productos.xaml
    /// </summary>
    public partial class Productos : Page
    {
        OracleConnection conn = null;

        public Productos()
        {
            abrirConexion();
            InitializeComponent();
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
        private void cargarProductoDG()
        {
            try
            {
                OracleCommand comando = new OracleCommand("listar_producto", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                listadoProductos.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Producto en la lista");
            }
        }
        

        private void ListadoProductos_Loaded(object sender, RoutedEventArgs e)
        {
            cargarProductoDG();
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cargarProductoDG();
        }

        private void AgreUpdateEventHandler(object sender, Addproductos.UpdateEventArgs args)
        {
            cargarProductoDG();
        }
        private void ActuUpdateEventHandler(object sender, Updateproductos.UpdateEventArgs args)
        {
            cargarProductoDG();
        }

        private void add_productos(object sender, RoutedEventArgs e)
        {
            Addproductos objaddproductos = new Addproductos(this);
            objaddproductos.UpdateEventHandler += AgreUpdateEventHandler;
            objaddproductos.Show();

        }

     

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Decimal id = (Decimal)((Button)sender).CommandParameter;
            //new Updateusuarios(Convert.ToInt32(id)).Show();
            Updateproductos objupdproductos = new Updateproductos(Convert.ToInt32(id));
            objupdproductos.UpdateEventHandler += ActuUpdateEventHandler;
            objupdproductos.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Decimal id = (Decimal)((Button)sender).CommandParameter;
            try
            {
                OracleCommand comando = new OracleCommand("eliminar_producto", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idp", OracleDbType.Int32).Value = id;
                comando.ExecuteNonQuery();
                MessageBox.Show("Producto eliminado con exito");

                cargarProductoDG();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo ha salido mal al eliminar el producto.");
            }
        }
    }
}