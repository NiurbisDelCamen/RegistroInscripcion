using Registro_Inscripcion.BLL;
using Registro_Inscripcion.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Registro_Inscripcion.UI.Consultas
{
    /// <summary>
    /// Interaction logic for ConsultarInscripcion.xaml
    /// </summary>
    public partial class ConsultarInscripcion : Window
    {
        public ConsultarInscripcion()
        {
            InitializeComponent();
        }

        private void ButtonConsultar_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Inscripciones>();
            if (TextBoxCriterio.Text.Trim().Length > 0)
            {
                listado = InscripcionesBLL.GetList(p => true);
            }
            else
            {
                listado = InscripcionesBLL.GetList(p => true);
            }
            ConsultaDataGridView.ItemsSource = listado;
            //ConsultaDataGridView.ItemsSource = null;
        }
    }
}
