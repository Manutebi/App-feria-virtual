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

namespace maipoGrande
{
    /// <summary>
    /// Lógica de interacción para transportistaExterno.xaml
    /// </summary>
    public partial class transportistaExterno : Window
    {
        public transportistaExterno()
        {
            InitializeComponent();
        }

        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("¿Desea salir?", "Cerrando sesión", MessageBoxButton.YesNo);
                if (MessageBoxResult.Yes == result)
                {
                    new MainWindow().Show();
                    Close();
                }
                else if (MessageBoxResult.No == result)
                {
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al tratar de cerrar sesión");
            }
        }
    }
}
