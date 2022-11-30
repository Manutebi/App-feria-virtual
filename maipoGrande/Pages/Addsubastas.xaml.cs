using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Deployment.Internal;
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

namespace maipoGrande.Pages
{
    /// <summary>
    /// Lógica de interacción para Addsubastas.xaml
    /// </summary>
    public partial class Addsubastas : Window
    {
        int id;
        OracleConnection conn = null;
        public Addsubastas(int id)
        {
            InitializeComponent();
            abrirConexion();
            this.id = id;
        }
        private void obtenerPDV(string id_pdv)
        {
            OracleCommand cmd = new OracleCommand("SELECT * FROM pdv WHERE id_pdv = :id_pdv", conn);
            cmd.Parameters.Add(":id_pdv", id_pdv);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Precio_pdv.Text = dt.Rows[0]["PRECIO_TOTAL"].ToString();
            cbIdPdv.SelectedValue = id_pdv;
            if (dt.Rows[0]["TIPO_LOCAL"].ToString() == "0"){
                RbLocalNo.IsChecked = true;
            }
            else{
                RbLocalSi.IsChecked = true;
            }
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
        private void cargarIdPdv()
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

                cbIdPdv.SelectedValuePath = "ID_PDV";
                cbIdPdv.DisplayMemberPath = "ID_PDV";
                cbIdPdv.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer tipo de usuario");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            string id_pdv = Convert.ToString(id);
            obtenerPDV(id_pdv);
        }

        private void cbIdPdv_Loaded(object sender, RoutedEventArgs e)
        {
            cargarIdPdv();
        }
    }
}
