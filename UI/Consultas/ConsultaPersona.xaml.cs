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
    /// Interaction logic for ConsultaPersona.xaml
    /// </summary>
    public partial class ConsultaPersona : Window
    {
        public ConsultaPersona()
        {
            InitializeComponent();
        }

        private void ButtonConsultar_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Personas>();
            if(TextBoxCriterio.Text.Trim().Length > 0)
            {
                listado = PersonasBLL.GetList(p => true);
            }
            else
            {
                listado = PersonasBLL.GetList(p=> true);
            }
            ConsultaDataGridView.ItemsSource = listado;
            //ConsultaDataGridView.ItemsSource = null;
        }

        private void TextBoxCriterio_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
