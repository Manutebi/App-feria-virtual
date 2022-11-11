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
    /// Lógica de interacción para Contratos.xaml
    /// </summary>
    public partial class Contratos : Page
    {
        OracleConnection conn = null;
    
        public Contratos()
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

        private void cargarContrato()
        {
            try
            {
                OracleCommand comando = new OracleCommand("listar_contrato", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                listadoContrato.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Contrato en la lista");
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
        private void cargarIDContrato()
        {
            cbIdContrato.SelectedValue = 0;
            try
            {
                OracleCommand comando = new OracleCommand("listar_contrato", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                cbIdContrato.SelectedValuePath = "ID_CONTRATO";
                cbIdContrato.DisplayMemberPath = "ID_CONTRATO";
                cbIdContrato.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar contrato en el combobox");
            }
        }
        private void cargarUpdateContrato(string id_contrato)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM contrato WHERE id_contrato = :id_contrato", conn);
                cmd.Parameters.Add(":id_contrato", id_contrato);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                contratoActivoSi.IsEnabled = true;
                ContratoActivoNo.IsEnabled = true;
                cbIdUser2.SelectedValue = dt.Rows[0]["USUARIO_ID_USUARIO"].ToString();
                fecha_InDate.Text = dt.Rows[0]["FECHA_INICIO"].ToString();
                fecha_TerDate.Text = dt.Rows[0]["FECHA_TERMINO"].ToString();
                string activo = dt.Rows[0]["CONTRATO_ACTIVO"].ToString();
                if (activo == "1") { contratoActivoSi.IsChecked = true; }
                else { ContratoActivoNo.IsChecked = true; }
            }
            catch (Exception ex)
            {
            }
        }

        private void ListadoContrato_Loaded(object sender, RoutedEventArgs e)
        {
            cargarContrato();
        }
        private void CbIdContrato_Loaded(object sender, RoutedEventArgs e)
        {
            cargarIDUser2();
        }
        private void CbIdContrato_Loaded_1(object sender, RoutedEventArgs e)
        {
            cargarIDContrato();
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
                MessageBox.Show("Contrato Guardado en la base de datos.");

                cbIdContrato.SelectedValue = 0;
                cargarIDUser2();
                cargarContrato();
                cargarIDContrato();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo en el guardado de contrato, asegurate de rellenar todas las casillas.");
            }
        }
        private void Actualizar_Contrato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime f1 = Convert.ToDateTime(string.Format("{0:yyyy-mm-dd}", fecha_InDate));
                DateTime f2 = Convert.ToDateTime(string.Format("{0:yyyy-mm-dd}", fecha_TerDate));
                OracleCommand comando = new OracleCommand("actualizar_contrato", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idp", OracleDbType.Int32).Value = Convert.ToInt32(cbIdContrato.Text);
                comando.Parameters.Add("fecha_ini", OracleDbType.Date).Value = f1;
                comando.Parameters.Add("fecha_ter", OracleDbType.Date).Value = f2;
                if (contratoActivoSi.IsChecked == true) { comando.Parameters.Add("contrato", OracleDbType.Int32).Value = 1; }
                else { comando.Parameters.Add("contrato", OracleDbType.Int32).Value = 0; }
                comando.Parameters.Add("usuario", OracleDbType.Varchar2).Value = Convert.ToInt32(cbIdUser2.SelectedValue);
                comando.ExecuteNonQuery();
                MessageBox.Show("Contrato actualizado con exito.");
                cbIdContrato.SelectedValue = 0;
                cargarIDUser2();
                cargarContrato();
                cargarIDContrato();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo en la actualizacion, asegurate de rellenar todas las casillas");
            }
        }
        private void EliminarContrato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OracleCommand comando = new OracleCommand("eliminar_contrato", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idp", OracleDbType.Int32).Value = Convert.ToInt32(cbIdContrato.SelectedValue);
                comando.ExecuteNonQuery();
                MessageBox.Show("Contrato eliminado con exito");

                cbIdContrato.SelectedValue = 0;
                cargarIDUser2();
                cargarContrato();
                cargarIDContrato();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo ha salido mal al eliminar el contrato.");
            }
        }

        private void CbIdContrato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbIdContrato.SelectedValue.ToString() != null)
            {
                string id_contrato = cbIdContrato.SelectedValue.ToString();
                cargarUpdateContrato(id_contrato);
            }
        }
    }
}
