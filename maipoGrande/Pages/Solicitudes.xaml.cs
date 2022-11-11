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
        private void cargarIdProducto2()
        {
            cbProducto.SelectedValue = 0;
            try
            {
                OracleCommand comando = new OracleCommand("listar_producto", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                cbProducto.SelectedValuePath = "ID_PROD";
                cbProducto.DisplayMemberPath = "N_PROD";
                cbProducto.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la id de calidad en el combobox");
            }
        }
        private void cargarUpdateSolicitud(string id_solicitud)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM solicitud_compra WHERE id_solicitud = :id_solicitud", conn);
                cmd.Parameters.Add(":id_solicitud", id_solicitud);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cantidadBox.Text = dt.Rows[0]["CTDAD_NECESARIA"].ToString();
                cbEstadoSolicitud.SelectedValue = dt.Rows[0]["ESTADO_SOLICITUD_ID_ESTADO"].ToString();
                cbProducto.SelectedValue = dt.Rows[0]["PRODUCTO_ID_PROD"].ToString();
            }
            catch (Exception ex)
            {
            }
        }
        private void cargarEstadoSolicitud()
        {

            cbEstadoSolicitud.SelectedValue = 0;
            try
            {
                OracleCommand comando = new OracleCommand("listar_estado_solicitud", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                cbEstadoSolicitud.SelectedValuePath = "ID_ESTADO";
                cbEstadoSolicitud.DisplayMemberPath = "D_ESTADO";
                cbEstadoSolicitud.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la id de estado en el combobox");
            }
        }
        private void cargarIdsolicitud2()
        {
            cbIdSolicitudCompra.SelectedValue = 0;
            try
            {
                OracleCommand comando = new OracleCommand("listar_solicitud_compra", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                cbIdSolicitudCompra.SelectedValuePath = "ID_SOLICITUD";
                cbIdSolicitudCompra.DisplayMemberPath = "ID_SOLICITUD";
                cbIdSolicitudCompra.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar id de solicitud en el combobox");
            }
        }

        private void ListadoSolicitudCompra_Loaded(object sender, RoutedEventArgs e)
        {
            cargarSolicitudDG2();
        }
        private void CbProducto_Loaded(object sender, RoutedEventArgs e)
        {
            cargarIdProducto2();
        }
        private void CbEstadoSolicitud_Loaded(object sender, RoutedEventArgs e)
        {
            cargarEstadoSolicitud();
        }
        private void CbIdSolicitudCompra_Loaded(object sender, RoutedEventArgs e)
        {
            cargarIdsolicitud2();
        }

        private void CbIdSolicitudCompra_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbIdSolicitudCompra.SelectedValue.ToString() != null)
            {
                string id_solicitud = cbIdSolicitudCompra.SelectedValue.ToString();
                cargarUpdateSolicitud(id_solicitud);
            }
        }

        private void GuardarSolicitud_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OracleCommand comando = new OracleCommand("agregar_solicitud_compra", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("fecha_soli", OracleDbType.Date).Value = DateTime.Today;
                comando.Parameters.Add("c_necesaria", OracleDbType.Int32).Value = Convert.ToInt32(cantidadBox.Text);
                comando.Parameters.Add("estado", OracleDbType.Int32).Value = 1;
                comando.Parameters.Add("producto", OracleDbType.Int32).Value = Convert.ToInt32(cbProducto.SelectedValue);
                comando.Parameters.Add("usuario", OracleDbType.Int32).Value = id_usuario;
                comando.ExecuteNonQuery();
                MessageBox.Show("Solicitud de compra guardado en la base de datos.");

                cbProducto.SelectedValue = 0;
                cbEstadoSolicitud.SelectedValue = 0;
                cbIdSolicitudCompra.SelectedValue = 0;
                cargarIdsolicitud2();
                cargarSolicitudDG2();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo en el guardado de Solicitud de compra, asegurate de rellenar todas las casillas.");
            }
        }
        private void ActualizarSolicitud_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OracleCommand comando = new OracleCommand("actualizar_solicitud_compra", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idp", OracleDbType.Int32).Value = Convert.ToInt32(cbIdSolicitudCompra.SelectedValue);
                comando.Parameters.Add("c_necesaria", OracleDbType.Int32).Value = Convert.ToInt32(cantidadBox.Text);
                comando.Parameters.Add("estado", OracleDbType.Int32).Value = Convert.ToInt32(cbEstadoSolicitud.SelectedValue);
                comando.Parameters.Add("producto", OracleDbType.Int32).Value = Convert.ToInt32(cbProducto.SelectedValue);
                comando.ExecuteNonQuery();
                MessageBox.Show("Solicitud actualizada con exito.");

                cbProducto.SelectedValue = 0;
                cbEstadoSolicitud.SelectedValue = 0;
                cbIdSolicitudCompra.SelectedValue = 0;
                cargarIdsolicitud2();
                cargarSolicitudDG2();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo en la actualizacion, asegurate de rellenar todas las casillas");
            }
        }
        private void EliminarSolicitud_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OracleCommand comando = new OracleCommand("eliminar_solicitud_compra", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idp", OracleDbType.Int32).Value = Convert.ToInt32(cbIdSolicitudCompra.SelectedValue);
                comando.ExecuteNonQuery();
                MessageBox.Show("Solicitud eliminada con exito");

                cbProducto.SelectedValue = 0;
                cbEstadoSolicitud.SelectedValue = 0;
                cbIdSolicitudCompra.SelectedValue = 0;
                cargarIdsolicitud2();
                cargarSolicitudDG2();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo ha salido mal al eliminar la solicitud.");
            }
        }


    }
}