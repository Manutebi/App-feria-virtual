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
    /// Lógica de interacción para Updateusuarios.xaml
    /// </summary>
    public partial class Updateusuarios : Window
    {
        OracleConnection conn = null;
        int id;
        public Updateusuarios(int id)
        {
            InitializeComponent();
            abrirConexion();
            this.id = id;
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
        private void cargarUpdateUser(int id)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM usuario inner join ciudad on ciudad.ID_CIUDAD = usuario.CIUDAD_ID_CIUDAD inner join estados on estados.ID_ESTADO = ciudad.ESTADOS_ID_ESTADO inner join pais on pais.ID_PAIS = estados.PAIS_ID_PAIS WHERE id_usuario = :id_usuario", conn);
                cmd.Parameters.Add(":id_usuario", id);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                RunBox.Text = dt.Rows[0]["RUN"].ToString();
                nombreBox.Text = dt.Rows[0]["NOMBRE"].ToString();
                apellidoBox.Text = dt.Rows[0]["APELLIDO"].ToString();
                passBox.Text = dt.Rows[0]["PASSWORD"].ToString();
                emailBox.Text = dt.Rows[0]["EMAIL"].ToString();
                cbtipoUser.SelectedValue = dt.Rows[0]["ROL_ID_ROL"].ToString();
                cbPais.SelectedValue = dt.Rows[0]["PAIS_ID_PAIS"].ToString() ;
                cbEstado.SelectedValue = dt.Rows[0]["ESTADOS_ID_ESTADO"].ToString();
                cbCiudad.SelectedValue = dt.Rows[0]["CIUDAD_ID_CIUDAD"].ToString();

            }
            catch (Exception ex)
            {
            }
        }
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }

        }

        protected void actualizar()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }


        private void cargarTipoUser()
        {
            
            try
            {
                OracleCommand comando = new OracleCommand("listar_rol", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                cbtipoUser.SelectedValuePath = "ID_ROL";
                cbtipoUser.DisplayMemberPath = "N_ROL";
                cbtipoUser.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer tipo de usuario");
            }
        }
        
        private void cargarPais()
        {
            
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM PAIS ORDER BY N_PAIS", conn);
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow fila = dt.NewRow();

                cbPais.SelectedValuePath = "ID_PAIS";
                cbPais.DisplayMemberPath = "N_PAIS";
                cbPais.ItemsSource = dt.DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer pais");
            }
        }
        private void cargarRegion(string id_pais)
        {
            
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM estados WHERE pais_id_pais = :id_pais", conn);
                cmd.Parameters.Add(":id_pais", id_pais);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow fila = dt.NewRow();

                cbEstado.SelectedValuePath = "ID_ESTADO";
                cbEstado.DisplayMemberPath = "N_ESTADO";
                cbEstado.ItemsSource = dt.DefaultView;

            }
            catch (Exception ex)
            {
            }
        }
        private void cargarCiudad(string id_estado)
        {
            
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM ciudad WHERE estados_id_estado = :id_estado", conn);
                cmd.Parameters.Add(":id_estado", id_estado);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow fila = dt.NewRow();

                cbCiudad.SelectedValuePath = "ID_CIUDAD";
                cbCiudad.DisplayMemberPath = "N_CIUDAD";
                cbCiudad.ItemsSource = dt.DefaultView;

            }
            catch (Exception ex)
            {
            }
        }

        private void CbPais_Loaded(object sender, RoutedEventArgs e)
        {
            cargarPais();
        }
        private void CbtipoUser_Loaded(object sender, RoutedEventArgs e)
        {
            cargarTipoUser();
        }
        

        
        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OracleCommand comando = new OracleCommand("actualizar_user", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idp", OracleDbType.Int32).Value = id;
                comando.Parameters.Add("nom", OracleDbType.Varchar2).Value = nombreBox.Text;
                comando.Parameters.Add("ape", OracleDbType.Varchar2).Value = apellidoBox.Text;
                comando.Parameters.Add("ema", OracleDbType.Varchar2).Value = emailBox.Text;
                comando.Parameters.Add("cont", OracleDbType.Varchar2).Value = passBox.Text;
                comando.Parameters.Add("run", OracleDbType.Int32).Value = Convert.ToInt32(RunBox.Text);
                comando.Parameters.Add("activo", OracleDbType.Int32).Value = 1;
                comando.Parameters.Add("super", OracleDbType.Int32).Value = 0;
                comando.Parameters.Add("ciudad", OracleDbType.Int32).Value = Convert.ToInt32(cbCiudad.SelectedValue);
                comando.Parameters.Add("rol", OracleDbType.Int32).Value = Convert.ToInt32(cbtipoUser.SelectedValue);
                comando.ExecuteNonQuery();
                MessageBox.Show("Usuario actualizado con exito.");
                actualizar();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo en la actualizacion, asegurate de rellenar todas las casillas");
            }
        }

        private void CbPais_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbPais.SelectedValue.ToString() != null)
            {
                string id_pais = cbPais.SelectedValue.ToString();
                cargarRegion(id_pais);
            }
        }
        private void CbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbEstado.SelectedValue.ToString() != null)
            {
                string id_estado = cbEstado.SelectedValue.ToString();
                cargarCiudad(id_estado);
            }
        }

        

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            cargarUpdateUser(id);
        }
    }
}
