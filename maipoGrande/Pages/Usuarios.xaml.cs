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


namespace maipoGrande.Pages
{
    /// <summary>
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>
    public partial class Usuarios : Page
    {
        OracleConnection conn = null;
        public Usuarios()
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

         private void cargarUsuarioDG()
        {
            try
            {
                OracleCommand comando = new OracleCommand("listar_user", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);
                int cantidad = lista.Rows.Count;
                cantidadUsuarios.Text = cantidad + " Usuarios registrados en el sistema";
                listadoUser.ItemsSource = lista.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuario");
            }
        }
       
       


        private void ListadoUser_Loaded(object sender, RoutedEventArgs e)
        {
            cargarUsuarioDG();
        }


        private void AgreUpdateEventHandler(object sender, Addusuarios.UpdateEventArgs args)
        {
            cargarUsuarioDG();
        }
        private void ActuUpdateEventHandler(object sender, Updateusuarios.UpdateEventArgs args)
        {
            cargarUsuarioDG();
        }

        private void add_usuarios(object sender, RoutedEventArgs e)
        {
            Addusuarios objaddusuarios = new Addusuarios(this);
            objaddusuarios.UpdateEventHandler += AgreUpdateEventHandler;
            objaddusuarios.Show();
            
        } 

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            cargarUsuarioDG();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Decimal id = (Decimal)((Button)sender).CommandParameter;
            //new Updateusuarios(Convert.ToInt32(id)).Show();
            Updateusuarios objupdusuarios = new Updateusuarios(Convert.ToInt32(id));
            objupdusuarios.UpdateEventHandler += ActuUpdateEventHandler;
            objupdusuarios.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Decimal id = (Decimal)((Button)sender).CommandParameter;
                try
                {
                    OracleCommand comando = new OracleCommand("eliminar_user", conn);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add("idp", OracleDbType.Int32).Value = id;
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Usuario eliminado con exito");

                    cargarUsuarioDG();
                }
                catch (Exception)
                {
                    MessageBox.Show("Algo ha salido mal al eliminar el usuario.");
                }
        }

        private void Button_Click_1()
        {

        }
    }
}