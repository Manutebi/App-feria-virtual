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
using MaterialDesignThemes.Wpf;

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
                OracleCommand comando = new OracleCommand("login", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                comando.Parameters.Add("mail", userBox.Text);
                comando.Parameters.Add("pass", passBox.Password);
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                //OracleCommand comando = new OracleCommand("SELECT * FROM usuario WHERE EMAIL = :email AND PASSWORD = :password AND ROL_ID_ROL = 1", conn);

                //comando.Parameters.Add(":email", userBox.Text);
                //comando.Parameters.Add(":password", passBox.Password);

                OracleDataReader lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    Usuario user = new Usuario();
                    user.Id_usuario = lector.GetInt32(0);
                    user.Nombre = lector.GetString(1);
                    user.Apellido = lector.GetString(2);
                    user.Email = lector.GetString(3);
                    user.Password = lector.GetString(4);
                    user.Run = lector.GetInt32(5);
                    user.Usuario_activo = lector.GetInt32(6);
                    user.Superuser = lector.GetInt32(7);
                    user.Ciudad_id_ciudad = lector.GetInt32(8);
                    user.Rol_id_rol = lector.GetInt32(9);

                    new Window1(user.Id_usuario, user.Nombre, user.Apellido, user.Email, user.Password, user.Run, user.Usuario_activo, user.Superuser, user.Ciudad_id_ciudad, user.Rol_id_rol).Show();
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

        //Theme Code ========================>
        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        //===================================>

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            //Theme Code ========================>
            ITheme theme = paletteHelper.GetTheme();
            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }

            paletteHelper.SetTheme(theme);
            //===================================>
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }   
}
