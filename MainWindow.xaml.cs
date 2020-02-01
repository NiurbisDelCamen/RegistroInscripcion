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
using Registro_Inscripcion.UI.Consultas;
using Registro_Inscripcion.UI.Registros;

namespace Registro_Inscripcion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItemPersonas_Click(object sender, RoutedEventArgs e)
        {
            FormPersonas formPersonas = new FormPersonas();
            formPersonas.Show();

        }

        private void MenuItemInscripcion_Click(object sender, RoutedEventArgs e)
        {
            FormInscripciones formInscripcion = new FormInscripciones();
            formInscripcion.Show();
        }

        private void MenuItemConsulta_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void MenuItemConsultarPersonas_Click(object sender, RoutedEventArgs e)
        {
            ConsultaPersona consulta = new ConsultaPersona();
            consulta.Show();
        }

        private void MenuItemConsultarinscripcion_Click(object sender, RoutedEventArgs e)
        {
            ConsultarInscripcion consultarInscripcion = new ConsultarInscripcion();
            consultarInscripcion.Show();
        }
    }
}
