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

        public Window1()
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

                listadoUser.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuario");
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
        private void cargarProcesoDG(){
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
        private void cargarSolicitudDG() {
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
        private void cargarTipoUser()
        {
            cbtipoUser.SelectedValue = 0;
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
        private void cargarIDUser()
        {
            cbID.SelectedValue = 0;
            try
            {
                cbID.SelectedValue = 0;
                OracleCommand comando = new OracleCommand("listar_user", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                cbID.SelectedValuePath = "ID_USUARIO";
                cbID.DisplayMemberPath = "NOMBRE";
                cbID.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer la id de usuario");
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
        private void cargarIDProceso(){
            cbIDproceso.SelectedValue = 0;
            try
            {
                OracleCommand comando = new OracleCommand("listar_pdv", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                cbIDproceso.SelectedValuePath = "ID_PDV";
                cbIDproceso.DisplayMemberPath = "ID_PDV";
                cbIDproceso.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer proceso");
            }
        }
        private void cargarPais(){
            cbPais.SelectedValue = 0;
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
            cbEstado.SelectedValue = 0;
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
            cbCiudad.SelectedValue = 0;
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
        private void cargarUpdateUser(string id_usuario){
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM usuario inner join ciudad on ciudad.ID_CIUDAD = usuario.CIUDAD_ID_CIUDAD inner join estados on estados.ID_ESTADO = ciudad.ESTADOS_ID_ESTADO inner join pais on pais.ID_PAIS = estados.PAIS_ID_PAIS WHERE id_usuario = :id_usuario", conn);
                cmd.Parameters.Add(":id_usuario", id_usuario);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                RunBox.Text = dt.Rows[0]["RUN"].ToString();
                nombreBox.Text = dt.Rows[0]["NOMBRE"].ToString();
                apellidoBox.Text = dt.Rows[0]["APELLIDO"].ToString();
                passBox.Text = dt.Rows[0]["PASSWORD"].ToString();
                emailBox.Text = dt.Rows[0]["EMAIL"].ToString();
                cbtipoUser.SelectedValue = dt.Rows[0]["ROL_ID_ROL"].ToString();
            }
            catch (Exception ex)
            {
            }
        }
        private void cargarIDContrato(){
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
        private void cargarUpdateContrato(string id_contrato){
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
        private void cargarUpdatePDV(string id_pdv){
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM pdv WHERE id_pdv = :id_pdv", conn);
                cmd.Parameters.Add(":id_pdv", id_pdv);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                fechaFinBox.Text = dt.Rows[0]["FECHA_TERMINO"].ToString();
                cbIdSolicitud.SelectedValue = dt.Rows[0]["SOLICITUD_COMPRA_ID_SOLICITUD"].ToString();
                cbIdEstadoPDV.SelectedValue = dt.Rows[0]["ESTADO_PDV_ID_ESTADOPDV"].ToString();
                string activo = dt.Rows[0]["TIPO_LOCAL"].ToString();
                if (activo == "1") { VentaLocalSi.IsChecked = true; }
                else { VentaLocalNo.IsChecked = true; }
            }
            catch (Exception ex)
            {
            }
        }
        private void cargarIdSolicitud(){
            cbIdSolicitud.SelectedValue = 0;
            try
            {
                OracleCommand comando = new OracleCommand("listar_solicitud_compra", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                cbIdSolicitud.SelectedValuePath = "ID_SOLICITUD";
                cbIdSolicitud.DisplayMemberPath = "ID_SOLICITUD";
                cbIdSolicitud.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar id de solicitud en el combobox");
            }
        }
        private void cargarIdEstado(){
            cbIdEstadoPDV.SelectedValue = 0;
            try
            {
                OracleCommand comando = new OracleCommand("listar_estado_pdv", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                cbIdEstadoPDV.SelectedValuePath = "ID_ESTADOPDV";
                cbIdEstadoPDV.DisplayMemberPath = "D_ESTADOPDV";
                cbIdEstadoPDV.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la id de estado en el combobox");
            }
        }
        private void cargarIdCalidad(){
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
        private void cargarIdProducto(){
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
        private void cargarUpdateProducto(string id_producto){
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

        private void ListadoUser_Loaded(object sender, RoutedEventArgs e)
        {
            cargarUsuarioDG();
        }
        //private void Listadoprocesos_Loaded(object sender, RoutedEventArgs e)
        //{
            //cargarProcesoDG();
        //}
        private void ListadoContrato_Loaded(object sender, RoutedEventArgs e)
        {
            cargarContrato();
        }
        private void ListadoProductos_Loaded(object sender, RoutedEventArgs e)
        {
            cargarProductoDG();
        }

        private void CbPais_Loaded(object sender, RoutedEventArgs e)
        {
            cargarPais();
        }
        private void CbtipoUser_Loaded(object sender, RoutedEventArgs e)
        {
            cargarTipoUser();
        }
        private void CbID_Loaded(object sender, RoutedEventArgs e)
        {
            cargarIDUser();
        }
        private void CbIdContrato_Loaded(object sender, RoutedEventArgs e)
        {
            cargarIDUser2();
        }
        private void CbIDproceso_Loaded(object sender, RoutedEventArgs e)
        {
            cargarIDProceso();
        }
        private void CbIdContrato_Loaded_1(object sender, RoutedEventArgs e)
        {
            cargarIDContrato();
        }
        private void CbIdSolicitud_Loaded(object sender, RoutedEventArgs e)
        {
            cargarIdSolicitud();
        }
        private void CbIdEstadoPDV_Loaded(object sender, RoutedEventArgs e)
        {
            cargarIdEstado();
        }
        private void CbIdCalidad_Loaded(object sender, RoutedEventArgs e){
            cargarIdCalidad();
        }
        private void CbIdProducto_Loaded(object sender, RoutedEventArgs e)
        {
            cargarIdProducto();
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            
            //Console.WriteLine(cbtipoUser.SelectedValue);

            try
            {
                OracleCommand comando = new OracleCommand("agregar_user", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
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
                MessageBox.Show("Usuario Guardado en la base de datos.");
                cbID.SelectedValue = 0;
                cargarUsuarioDG();
                cargarIDUser();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo en la creacion del usuario, asegurate de rellenar todas las casillas.");
            }
        }
        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OracleCommand comando = new OracleCommand("actualizar_user", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idp", OracleDbType.Int32).Value = Convert.ToInt32(cbID.SelectedValue);
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

                String a = "";
                RunBox.Text = a;
                nombreBox.Clear();
                apellidoBox.Clear();
                passBox.Clear();
                emailBox.Clear();
                cbtipoUser.SelectedValue = 0;
                cbEstado.SelectedValue = 0;
                cbCiudad.SelectedValue = 0;
                cbPais.SelectedValue = 0;
                cbID.SelectedValue = 0;

                cargarUsuarioDG();
                cargarIDUser();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo en la actualizacion, asegurate de rellenar todas las casillas");
            }
        }
        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OracleCommand comando = new OracleCommand("eliminar_user", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idp", OracleDbType.Int32).Value = Convert.ToInt32(cbID.SelectedValue);
                comando.ExecuteNonQuery();
                MessageBox.Show("Usuario eliminado con exito");

                cbID.SelectedValue = 0;
                cargarUsuarioDG();
                cargarIDUser();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo ha salido mal al eliminar el usuario.");
            }
        }

        private void Guardar_proceso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numero = 2;
                OracleCommand comando = new OracleCommand("agregar_pdv", conn);
                OracleCommand cmd = new OracleCommand("actualizar_solicitud_compra_estado", conn);
                cmd.Parameters.Add("idp", OracleDbType.Int32).Value = Convert.ToInt32(cbIdSolicitud.SelectedValue);
                cmd.Parameters.Add("estado", OracleDbType.Int32).Value = numero;
                DateTime f1a = DateTime.Today;
                DateTime f2a = Convert.ToDateTime(string.Format("{0:yyyy-mm-dd}", fechaFinBox));

                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("fecha_ini", OracleDbType.Date).Value = f1a;
                comando.Parameters.Add("fecha_ter", OracleDbType.Date).Value = f2a;
                comando.Parameters.Add("ctdad_reunida", OracleDbType.Int32).Value = 0;
                comando.Parameters.Add("precio_total", OracleDbType.Int32).Value = 0;
                comando.Parameters.Add("estado", OracleDbType.Int32).Value = Convert.ToInt32(cbIdEstadoPDV.SelectedValue);
                comando.Parameters.Add("solicitud", OracleDbType.Int32).Value = Convert.ToInt32(cbIdSolicitud.SelectedValue);
                if(VentaLocalSi.IsChecked == true) { comando.Parameters.Add("local", OracleDbType.Int32).Value = 1; }
                else { comando.Parameters.Add("local", OracleDbType.Int32).Value = 0; }
                comando.ExecuteNonQuery();

                MessageBox.Show("proceso Guardado en la base de datos.");
                cbIdEstadoPDV.SelectedValue = 0;
                cbIDproceso.SelectedValue = 0;
                cbIdSolicitud.SelectedValue = 0;
                cargarIDProceso();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo en la creacion del proceso de compra, asegurate de rellenar todas las casillas.");
            }
        }
        private void Actualizar_proceso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OracleCommand comando = new OracleCommand("actualizar_pdv", conn);
                DateTime f2a = Convert.ToDateTime(string.Format("{0:yyyy-mm-dd}", fechaFinBox));

                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idp", OracleDbType.Int32).Value = Convert.ToInt32(cbIDproceso.SelectedValue);
                comando.Parameters.Add("fecha_ter", OracleDbType.Date).Value = f2a;
                comando.Parameters.Add("estado", OracleDbType.Int32).Value = Convert.ToInt32(cbIdEstadoPDV.SelectedValue);
                comando.Parameters.Add("solicitud", OracleDbType.Int32).Value = Convert.ToInt32(cbIdSolicitud.SelectedValue);
                if (VentaLocalSi.IsChecked == true) { comando.Parameters.Add("local", OracleDbType.Int32).Value = 1; }
                else { comando.Parameters.Add("local", OracleDbType.Int32).Value = 0; }
                comando.ExecuteNonQuery();
                MessageBox.Show("Proceso de venta actualizado con exito.");
                cbIdEstadoPDV.SelectedValue = 0;
                cbIDproceso.SelectedValue = 0;
                cbIdSolicitud.SelectedValue = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Algo fallo en la actualizacion, asegurate de rellenar todas las casillas");
            }
        }
        private void Eliminar_proceso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OracleCommand comando = new OracleCommand("eliminar_pdv", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idp", OracleDbType.Int32).Value = Convert.ToInt32(cbIDproceso.Text);
                comando.ExecuteNonQuery();
                MessageBox.Show("Proceso de ventas eliminado con exito");
                cbIDproceso.SelectedValue = 0;
                cbIdEstadoPDV.SelectedValue = 0;
                cbIDproceso.SelectedValue = 0;
                cbIdSolicitud.SelectedValue = 0;
                cargarIDProceso();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo ha salido mal al eliminar el proceso de ventas.");
            }
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
                if (contratoActivoSi.IsChecked == true) {comando.Parameters.Add("contrato", OracleDbType.Int32).Value = 1;}
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

        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("¿Desea salir?", "Cerrando sesión", MessageBoxButton.YesNo);
                if (MessageBoxResult.Yes == result) {
                    new MainWindow().Show();
                    Close();
                }
                else if (MessageBoxResult.No == result){
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al tratar de cerrar sesión");
            }
        }

        private void CbPais_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbPais.SelectedValue.ToString() != null){
                string id_pais = cbPais.SelectedValue.ToString();
                cargarRegion(id_pais);
            }
        }
        private void CbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbEstado.SelectedValue.ToString() != null){
                string id_estado = cbEstado.SelectedValue.ToString();
                cargarCiudad(id_estado);
            }
        }

        private void CbID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbID.SelectedValue.ToString() != null){
                string id_usuario = cbID.SelectedValue.ToString();
                cargarUpdateUser(id_usuario);
            }
        }
        private void CbIdContrato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbIdContrato.SelectedValue.ToString() != null){
                string id_contrato = cbIdContrato.SelectedValue.ToString();
                cargarUpdateContrato(id_contrato);
            }
        }
        private void CbIDproceso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbIDproceso.SelectedValue.ToString() != null)
            {
                string id_pdv = cbIDproceso.SelectedValue.ToString();
                cargarUpdatePDV(id_pdv);
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

        private void MostrarSolicitudNo_Checked(object sender, RoutedEventArgs e)
        {
            cargarProcesoDG();
        }
        private void MostrarSolicitudSi_Checked(object sender, RoutedEventArgs e)
        {
            cargarSolicitudDG();
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