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
    /// Lógica de interacción para Productos.xaml
    /// </summary>
    public partial class Productos : Page
    {
        OracleConnection conn = null;

        public Productos()
        {
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
        private void cargarIdCalidad()
        {
            cbIdCalidad.SelectedValue = 0;
            try
            {
                OracleCommand comando = new OracleCommand("listar_calidad", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                cbIdCalidad.SelectedValuePath = "ID_CALIDAD";
                cbIdCalidad.DisplayMemberPath = "DESCRIPCION_C";
                cbIdCalidad.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la id de calidad en el combobox");
            }
        }
        private void cargarIdProducto()
        {
            cbIdProducto.SelectedValue = 0;
            try
            {
                OracleCommand comando = new OracleCommand("listar_producto", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                cbIdProducto.SelectedValuePath = "ID_PROD";
                cbIdProducto.DisplayMemberPath = "N_PROD";
                cbIdProducto.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la id de calidad en el combobox");
            }
        }
        private void cargarUpdateProducto(string id_producto)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM producto WHERE id_prod = :id_prod", conn);
                cmd.Parameters.Add(":id_producto", id_producto);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                NombreProductoBox.Text = dt.Rows[0]["N_PROD"].ToString();
                cbIdCalidad.SelectedValue = dt.Rows[0]["CALIDAD_ID_CALIDAD"].ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void ListadoProductos_Loaded(object sender, RoutedEventArgs e)
        {
            cargarProductoDG();
        }
        private void CbIdCalidad_Loaded(object sender, RoutedEventArgs e)
        {
            cargarIdCalidad();
        }
        private void CbIdProducto_Loaded(object sender, RoutedEventArgs e)
        {
            cargarIdProducto();
        }

        private void GuardarProducto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OracleCommand comando = new OracleCommand("agregar_producto", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("nom", OracleDbType.Varchar2).Value = NombreProductoBox.Text;
                comando.Parameters.Add("ruta", OracleDbType.Varchar2).Value = "ruta";
                comando.Parameters.Add("calidad", OracleDbType.Int32).Value = Convert.ToInt32(cbIdCalidad.SelectedValue);
                comando.ExecuteNonQuery();
                MessageBox.Show("Producto Guardado en la base de datos.");

                cbIdProducto.SelectedValue = 0;
                cargarIdProducto();
                cargarProductoDG();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo en el guardado de Producto, asegurate de rellenar todas las casillas.");
            }
        }
        private void ActualizarProducto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OracleCommand comando = new OracleCommand("actualizar_producto", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idp", OracleDbType.Int32).Value = Convert.ToInt32(cbIdProducto.SelectedValue);
                comando.Parameters.Add("nom", OracleDbType.Varchar2).Value = NombreProductoBox.Text;
                comando.Parameters.Add("ruta", OracleDbType.Varchar2).Value = "RutaNoDisponible";
                comando.Parameters.Add("calidad", OracleDbType.Int32).Value = Convert.ToInt32(cbIdCalidad.SelectedValue);
                comando.ExecuteNonQuery();
                MessageBox.Show("Producto actualizado con exito.");

                NombreProductoBox.Clear();
                cbIdCalidad.SelectedValue = 0;
                cbIdProducto.SelectedValue = 0;
                cargarIdProducto();
                cargarProductoDG();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo en la actualizacion, asegurate de rellenar todas las casillas");
            }
        }
        private void EliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OracleCommand comando = new OracleCommand("eliminar_producto", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idp", OracleDbType.Int32).Value = Convert.ToInt32(cbIdProducto.SelectedValue);
                comando.ExecuteNonQuery();
                MessageBox.Show("Producto eliminado con exito");

                cbIdProducto.SelectedValue = 0;
                cargarIdProducto();
                cargarProductoDG();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo ha salido mal al eliminar el usuario.");
            }
        }

        private void CbIdProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbIdProducto.SelectedValue.ToString() != null)
            {
                string id_producto = cbIdProducto.SelectedValue.ToString();
                cargarUpdateProducto(id_producto);
            }
        }


    }
}
