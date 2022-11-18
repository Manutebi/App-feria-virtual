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
        

        private void addpdv(object sender, RoutedEventArgs e)
        {
            Addpdv objaddpdv = new Addpdv();
            objaddpdv.Show();

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


    }
}