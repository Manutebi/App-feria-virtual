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
    /// Lógica de interacción para Solicitudes.xaml
    /// </summary>
    public partial class Solicitudes : Page
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

        public Solicitudes(int id_usuario, string nombre, string apellido, string email, string password, int run, int usuario_activo, int superuser, int ciudad, int rol)
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


        private void ListadoSolicitudCompra_Loaded(object sender, RoutedEventArgs e) 
        { 
        
            cargarSolicitudDG2();
        }

        private void cargarSolicitudDG2()
        {
            try
            {
                OracleCommand comando = new OracleCommand("LISTAR_SOLICITUD_COMPRA", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                listadoSolicitudCompra.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer Solicitud");
            }
        }

        private void actualizar(object sender, RoutedEventArgs e)
        {
            cargarSolicitudDG2();
        }


        private void AgreUpdateEventHandler(object sender, Addventas.UpdateEventArgs args)
        {
            cargarSolicitudDG2();
        }
        private void ActuUpdateEventHandler(object sender, Updateventas.UpdateEventArgs args)
        {
            cargarSolicitudDG2();
        }

        private void add_ventas(object sender, RoutedEventArgs e)
        {
            Addventas objaddventas = new Addventas(id);
            objaddventas.UpdateEventHandler += AgreUpdateEventHandler;
            objaddventas.Show(id_usuario, nombre, apellido, email, password, run, usuario_activo, superuser, ciudad, rol);

        }

     

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Decimal id = (Decimal)((Button)sender).CommandParameter;
            //new Updateusuarios(Convert.ToInt32(id)).Show();
            Updateventas objupdventas = new Updateventas(id_usuario, nombre, apellido, email, password, run, usuario_activo, superuser, ciudad, rol);
            objupdventas.UpdateEventHandler += ActuUpdateEventHandler;
            objupdventas.Show();
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

                cargarSolicitudDG2();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo ha salido mal al eliminar el usuario.");
            }
        }


    }
}