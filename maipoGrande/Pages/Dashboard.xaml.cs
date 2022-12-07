using LiveCharts;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace maipoGrande.Pages
{
    /// <summary>
    /// Lógica de interacción para Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        OracleConnection conn = null;
        public ChartValues<double> Values { get; set; } = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public ChartValues<double> Values2 { get; set; } = new ChartValues<double> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int sumaPrecioPdv_local = 0;
        int sumaValorSubasta_local = 0;
        int sumaPrecioPdv_externa = 0;
        int sumaValorSubasta_externa = 0;

        int precioPdv_mes1_local = 0;
        int precioPdv_mes2_local = 0;
        int precioPdv_mes3_local = 0;
        int precioPdv_mes4_local = 0;
        int precioPdv_mes5_local = 0;
        int precioPdv_mes6_local = 0;
        int precioPdv_mes7_local = 0;
        int precioPdv_mes8_local = 0;
        int precioPdv_mes9_local = 0;
        int precioPdv_mes10_local = 0;
        int precioPdv_mes11_local = 0;
        int precioPdv_mes12_local = 0;
        int valorSubasta_mes1_local = 0;
        int valorSubasta_mes2_local = 0;
        int valorSubasta_mes3_local = 0;
        int valorSubasta_mes4_local = 0;
        int valorSubasta_mes5_local = 0;
        int valorSubasta_mes6_local = 0;
        int valorSubasta_mes7_local = 0;
        int valorSubasta_mes8_local = 0;
        int valorSubasta_mes9_local = 0;
        int valorSubasta_mes10_local = 0;
        int valorSubasta_mes11_local = 0;
        int valorSubasta_mes12_local = 0;

        int precioPdv_mes1_externa = 0;
        int precioPdv_mes2_externa = 0;
        int precioPdv_mes3_externa = 0;
        int precioPdv_mes4_externa = 0;
        int precioPdv_mes5_externa = 0;
        int precioPdv_mes6_externa = 0;
        int precioPdv_mes7_externa = 0;
        int precioPdv_mes8_externa = 0;
        int precioPdv_mes9_externa = 0;
        int precioPdv_mes10_externa = 0;
        int precioPdv_mes11_externa = 0;
        int precioPdv_mes12_externa = 0;
        int valorSubasta_mes1_externa = 0;
        int valorSubasta_mes2_externa = 0;
        int valorSubasta_mes3_externa = 0;
        int valorSubasta_mes4_externa = 0;
        int valorSubasta_mes5_externa = 0;
        int valorSubasta_mes6_externa = 0;
        int valorSubasta_mes7_externa = 0;
        int valorSubasta_mes8_externa = 0;
        int valorSubasta_mes9_externa = 0;
        int valorSubasta_mes10_externa = 0;
        int valorSubasta_mes11_externa = 0;
        int valorSubasta_mes12_externa = 0;
        public Dashboard()
        {
            InitializeComponent();
            abrirConexion();
            cargar_precioPdv_mes1_local();
            cargar_precioPdv_mes2_local();
            cargar_precioPdv_mes3_local();
            cargar_precioPdv_mes4_local();
            cargar_precioPdv_mes5_local();
            cargar_precioPdv_mes6_local();
            cargar_precioPdv_mes7_local();
            cargar_precioPdv_mes8_local();
            cargar_precioPdv_mes9_local();
            cargar_precioPdv_mes10_local();
            cargar_precioPdv_mes11_local();
            cargar_precioPdv_mes12_local();
            cargar_valorsubasta_mes1_local();
            cargar_valorsubasta_mes2_local();
            cargar_valorsubasta_mes3_local();
            cargar_valorsubasta_mes4_local();
            cargar_valorsubasta_mes5_local();
            cargar_valorsubasta_mes6_local();
            cargar_valorsubasta_mes7_local();
            cargar_valorsubasta_mes8_local();
            cargar_valorsubasta_mes9_local();
            cargar_valorsubasta_mes10_local();
            cargar_valorsubasta_mes11_local();
            cargar_valorsubasta_mes12_local();

            cargar_precioPdv_mes1_externa();
            cargar_precioPdv_mes2_externa();
            cargar_precioPdv_mes3_externa();
            cargar_precioPdv_mes4_externa();
            cargar_precioPdv_mes5_externa();
            cargar_precioPdv_mes6_externa();
            cargar_precioPdv_mes7_externa();
            cargar_precioPdv_mes8_externa();
            cargar_precioPdv_mes9_externa();
            cargar_precioPdv_mes10_externa();
            cargar_precioPdv_mes11_externa();
            cargar_precioPdv_mes12_externa();
            cargar_valorsubasta_mes1_externa();
            cargar_valorsubasta_mes2_externa();
            cargar_valorsubasta_mes3_externa();
            cargar_valorsubasta_mes4_externa();
            cargar_valorsubasta_mes5_externa();
            cargar_valorsubasta_mes6_externa();
            cargar_valorsubasta_mes7_externa();
            cargar_valorsubasta_mes8_externa();
            cargar_valorsubasta_mes9_externa();
            cargar_valorsubasta_mes10_externa();
            cargar_valorsubasta_mes11_externa();
            cargar_valorsubasta_mes12_externa();
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

        // Inicio de Cargas locales//

        private void cargar_precioPdv_mes1_local()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 1 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes1_local += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes2_local()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 2 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes2_local += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes3_local()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 3 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes3_local += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes4_local()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 4 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes4_local += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes5_local()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 5 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes5_local += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes6_local()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 6 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes6_local += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes7_local()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 7 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes7_local += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes8_local()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 8 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes8_local += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes9_local()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 9 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes9_local += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes10_local()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 10 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes10_local += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes11_local() {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 11 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes11_local += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes12_local()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 12 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes12_local += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_valorsubasta_mes1_local()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 1 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes1_local += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes2_local()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 2 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes2_local += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes3_local()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 3 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes3_local += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes4_local()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 4 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes4_local += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes5_local()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 5 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes5_local += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes6_local()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 6 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes6_local += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes7_local()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 7 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes7_local += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes8_local()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 8 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes8_local += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes9_local()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 9 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes9_local += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes10_local()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 10 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes10_local += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes11_local()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 11 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes11_local += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes12_local()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 12 and tipo_pdv = 1", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes12_local += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void sumarPrecioPdv_local()
        {
            sumaPrecioPdv_local = precioPdv_mes1_local + precioPdv_mes2_local + precioPdv_mes3_local + precioPdv_mes4_local + precioPdv_mes5_local + precioPdv_mes6_local + precioPdv_mes7_local + precioPdv_mes8_local + precioPdv_mes9_local + precioPdv_mes10_local + precioPdv_mes11_local + precioPdv_mes12_local;
        }
        private void sumarValorSubasta_local()
        {
            sumaValorSubasta_local = valorSubasta_mes1_local + valorSubasta_mes2_local + valorSubasta_mes3_local + valorSubasta_mes4_local + valorSubasta_mes5_local + valorSubasta_mes6_local + valorSubasta_mes7_local + valorSubasta_mes8_local + valorSubasta_mes9_local + valorSubasta_mes10_local + valorSubasta_mes11_local + valorSubasta_mes12_local;
        }

        //Fin de Cargas Locales//

        //Inicio de Cargas Externas//

        private void cargar_precioPdv_mes1_externa()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 1 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes1_externa += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes2_externa()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 2 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes2_externa += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes3_externa()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 3 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes3_externa += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes4_externa()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 4 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes4_externa += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes5_externa()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 5 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes5_externa += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes6_externa()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 6 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes6_externa += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes7_externa()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 7 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes7_externa += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes8_externa()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 8 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes8_externa += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes9_externa()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 9 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes9_externa += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes10_externa()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 10 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes10_externa += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes11_externa()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 11 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes11_externa += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_precioPdv_mes12_externa()
        {
            OracleCommand cmd = new OracleCommand("select precio_pdv from estadisticas where fecha_id_fecha = 12 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                precioPdv_mes12_externa += Convert.ToInt32(dr["PRECIO_PDV"]);
            }
        }
        private void cargar_valorsubasta_mes1_externa()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 1 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes1_externa += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes2_externa()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 2 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes2_externa += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes3_externa()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 3 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes3_externa += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes4_externa()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 4 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes4_externa += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes5_externa()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 5 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes5_externa += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes6_externa()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 6 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes6_externa += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes7_externa()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 7 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes7_externa += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes8_externa()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 8 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes8_externa += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes9_externa()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 9 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes9_externa += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes10_externa()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 10 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes10_externa += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes11_externa()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 11 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes11_externa += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void cargar_valorsubasta_mes12_externa()
        {
            OracleCommand cmd = new OracleCommand("select valor_subasta from estadisticas where fecha_id_fecha = 12 and tipo_pdv = 0", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                valorSubasta_mes12_externa += Convert.ToInt32(dr["VALOR_SUBASTA"]);
            }
        }
        private void sumarPrecioPdv_externa()
        {
            sumaPrecioPdv_externa = precioPdv_mes1_externa + precioPdv_mes2_externa + precioPdv_mes3_externa + precioPdv_mes4_externa + precioPdv_mes5_externa + precioPdv_mes6_externa + precioPdv_mes7_externa + precioPdv_mes8_externa + precioPdv_mes9_externa + precioPdv_mes10_externa + precioPdv_mes11_externa + precioPdv_mes12_externa;
        }
        private void sumarValorSubasta_externa()
        {
            sumaValorSubasta_externa = valorSubasta_mes1_externa + valorSubasta_mes2_externa + valorSubasta_mes3_externa + valorSubasta_mes4_externa + valorSubasta_mes5_externa + valorSubasta_mes6_externa + valorSubasta_mes7_externa + valorSubasta_mes8_externa + valorSubasta_mes9_externa + valorSubasta_mes10_externa + valorSubasta_mes11_externa + valorSubasta_mes12_externa;
        }

        //Fin de Cargas Externas

        private void UpdateOnclick(object sender, RoutedEventArgs e)
        {
            Chart.Update(true);
        }

        private void Click_ventasLocales(object sender, RoutedEventArgs e)
        {
            sumarPrecioPdv_local();
            totalVentas.Content = (sumaPrecioPdv_local);

            sumarValorSubasta_local();
            TotalSubastas.Content = (sumaValorSubasta_local);
            
            DataContext = null;
            Values = new ChartValues<double> { precioPdv_mes1_local, precioPdv_mes2_local, precioPdv_mes3_local, precioPdv_mes4_local, precioPdv_mes5_local, precioPdv_mes6_local, precioPdv_mes7_local, precioPdv_mes8_local, precioPdv_mes9_local, precioPdv_mes10_local, precioPdv_mes11_local, precioPdv_mes12_local };
            Values2 = new ChartValues<double> { valorSubasta_mes1_local, valorSubasta_mes2_local, valorSubasta_mes3_local, valorSubasta_mes4_local, valorSubasta_mes5_local, valorSubasta_mes6_local, valorSubasta_mes7_local, valorSubasta_mes8_local, valorSubasta_mes9_local, valorSubasta_mes10_local, valorSubasta_mes11_local, valorSubasta_mes12_local };
            DataContext = this;
            Chart.Update(true);
        }
        private void click_ventasExternas(object sender, RoutedEventArgs e)
        {
            sumarPrecioPdv_externa();
            totalVentas.Content = (sumaPrecioPdv_externa);

            sumarValorSubasta_externa();
            TotalSubastas.Content = (sumaValorSubasta_externa);

            DataContext = null;
            Values = new ChartValues<double> { precioPdv_mes1_externa, precioPdv_mes2_externa, precioPdv_mes3_externa, precioPdv_mes4_externa, precioPdv_mes5_externa, precioPdv_mes6_externa, precioPdv_mes7_externa, precioPdv_mes8_externa, precioPdv_mes9_externa, precioPdv_mes10_externa, precioPdv_mes11_externa, precioPdv_mes12_externa };
            Values2 = new ChartValues<double> { valorSubasta_mes1_externa, valorSubasta_mes2_externa, valorSubasta_mes3_externa, valorSubasta_mes4_externa, valorSubasta_mes5_externa, valorSubasta_mes6_externa, valorSubasta_mes7_externa, valorSubasta_mes8_externa, valorSubasta_mes9_externa, valorSubasta_mes10_externa, valorSubasta_mes11_externa, valorSubasta_mes12_externa };
            DataContext = this;
            
            Chart.Update(true);
        }
    }
}
