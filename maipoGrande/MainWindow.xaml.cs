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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
using maipoGrandeDatos;

namespace maipoGrande
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OracleConnection conn = null;

        public MainWindow()
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
                MessageBox.Show("Error de conexion");
                throw new Exception("Error de conexion") ;
            }

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OracleCommand comando = new OracleCommand("SELECT * FROM usuario WHERE EMAIL = :email AND PASSWORD = :password AND ROL_ID_ROL = 1", conn);

                comando.Parameters.Add(":email", userBox.Text);
                comando.Parameters.Add(":password", passBox.Password);

                OracleDataReader lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    new Window1().Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("No se reconoce un usuario correcto. Vuelva a intentar");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la conexion");
            }
        }
    }
}
