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
    /// Lógica de interacción para Proceso_de_venta.xaml
    /// </summary>
    public partial class Procesos : Page
    {
        OracleConnection conn = null;

        public Procesos()
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

        private void cargarProcesoDG()
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

                listadoprocesos.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer proceso");
            }
        }

        

 

        private void cargarSolicitudDG()
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

                listadoprocesos.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer Solicitud");
            }
        }
        private void MostrarSolicitudNo_Checked(object sender, RoutedEventArgs e)
        {
            cargarProcesoDG();
            IDBotones.Visibility = Visibility.Visible;
        }
        private void MostrarSolicitudSi_Checked(object sender, RoutedEventArgs e)
        {
            cargarSolicitudDG();
            IDBotones.Visibility = Visibility.Collapsed;
    
        }

        private void AgreUpdateEventHandler(object sender, Addpdv.UpdateEventArgs args)
        {
            cargarProcesoDG();
        }


        private void ActuUpdateEventHandler(object sender, Updatepdv.UpdateEventArgs args)
        {
            cargarProcesoDG();
        }

        private void add_pdv(object sender, RoutedEventArgs e)
        {
            //Addpdv objaddpdv = new Addpdv(this);
            //objaddpdv.UpdateEventHandler += AgreUpdateEventHandler;
            //objaddpdv.Show();

        }


        public void boton_actualizar(object sender, RoutedEventArgs e)
        {
            cargarProcesoDG();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Decimal id = (Decimal)((Button)sender).CommandParameter;
            //new Updateusuarios(Convert.ToInt32(id)).Show();
            Updatepdv objupdpdv = new Updatepdv(Convert.ToInt32(id));
            objupdpdv.UpdateEventHandler += ActuUpdateEventHandler;
            objupdpdv.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try {
                Decimal id = (Decimal)((Button)sender).CommandParameter;
                Addsubastas objaddSubasta = new Addsubastas(Convert.ToInt32(id));
                objaddSubasta.UpdateEventHandler += ActuUpdateEventHandler;
                objaddSubasta.Show();
            }
            catch (Exception) 
            { 
            }
            //Decimal id = (Decimal)((Button)sender).CommandParameter;
            //try
            //{
            //    OracleCommand comando = new OracleCommand("eliminar_pdv", conn);
            //    comando.CommandType = System.Data.CommandType.StoredProcedure;
            //    comando.Parameters.Add("idp", OracleDbType.Int32).Value = id;
            //    comando.ExecuteNonQuery();
            //    MessageBox.Show("Proceso de venta eliminado con exito");

            //    cargarProcesoDG();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Algo ha salido mal al eliminar el proceso de venta.");
            //}
        }
        private void ActuUpdateEventHandler(object sender, Addsubastas.UpdateEventArgs args)
        {
            cargarProcesoDG();
        }

    }
}