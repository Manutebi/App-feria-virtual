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

namespace maipoGrande
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        OracleConnection conn = null;
        int id_usuario;
        string nombre;
        string apellido;
        string email;
        string password;
        int run;
        int usuario_activo;
        int superuser;
        int ciudad;
        int rol;

        public Window1(int id_usuario, string nombre, string apellido, string email, string password, int run, int usuario_activo, int superuser, int ciudad, int rol)
        {
            abrirConexion();
            InitializeComponent();
            this.id_usuario = id_usuario;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.password = password;
            this.run = run;
            this.usuario_activo = usuario_activo;
            this.superuser = superuser;
            this.ciudad = ciudad;
            this.rol = rol;

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

        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("¿Desea salir?", "Cerrando sesión", MessageBoxButton.YesNo);
                if (MessageBoxResult.Yes == result)
                {
                    new MainWindow().Show();
                    Close();
                }
                else if (MessageBoxResult.No == result)
                {
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al tratar de cerrar sesión");
            }
        }



        private void click_usuarios(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/Usuarios.xaml", UriKind.RelativeOrAbsolute));
        }
        private void click_contratos(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/Contratos.xaml", UriKind.RelativeOrAbsolute));

        }
        private void click_procesos(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/Proceso_de_venta.xaml", UriKind.RelativeOrAbsolute));
        }
        private void click_productos(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/Productos.xaml", UriKind.RelativeOrAbsolute));
        }
        private void click_solicitudes(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/Solicitudes_de_compra.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}