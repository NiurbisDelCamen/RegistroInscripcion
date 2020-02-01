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
using Registro_Inscripcion.Entidades;
using Registro_Inscripcion.BLL;

namespace Registro_Inscripcion.UI.Registros
{
    /// <summary>
    /// Interaction logic for FormInscripciones.xaml
    /// </summary>
    public partial class FormInscripciones : Window
    {
        public FormInscripciones()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            TextBoxInscripcionesId.Text = "0";
            DatePickerFechaInscripcion.SelectedDate = DateTime.Now;
            TextBoxPersonaId.Text = "0";
            TextBoxComentario.Text = string.Empty;
            TextBoxMonto.Text = string.Empty;
            TextBoxBalance.Text = string.Empty;
        }
      /*  private void ButtonNuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }*/

        private Inscripciones LlenaClase()
        {
            Inscripciones  inscripcion = new Inscripciones();
           
            inscripcion.IncripcionId = inscripcion.PersonaId = Convert.ToInt32(TextBoxInscripcionesId.Text);
            inscripcion.PersonaId = Convert.ToInt32(TextBoxPersonaId.Text);
            inscripcion.Fecha = (DateTime)DatePickerFechaInscripcion.SelectedDate;
            inscripcion.Comentarios = TextBoxComentario.Text;
            inscripcion.Monto = Convert.ToDecimal(TextBoxMonto.Text);
            inscripcion.Balance = Convert.ToDecimal(TextBoxBalance.Text);
            inscripcion.Deposito = Convert.ToDecimal(TextBoxDeposito.Text);

            if (Convert.ToDecimal(TextBoxBalance.Text) > 0)
            {
                inscripcion.Balance = (Convert.ToDecimal(TextBoxBalance.Text) - inscripcion.Deposito);
                PersonasBLL.GuardarBalance(Convert.ToInt32(TextBoxPersonaId.Text), (inscripcion.Balance));
            }
            else
            {
               inscripcion.Balance = inscripcion.Balance - inscripcion.Deposito;
                PersonasBLL.GuardarBalance(Convert.ToInt32(TextBoxPersonaId), (inscripcion.Monto - inscripcion.Deposito));

            }

            return inscripcion;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Inscripciones inscripcion = InscripcionesBLL.Buscar(Convert.ToInt32(TextBoxInscripcionesId.Text));
            return (inscripcion != null);
        }

        private bool Validar() //Validar los campos
        {
            bool paso = true;
            if (string.IsNullOrEmpty(TextBoxInscripcionesId.Text))
            {
                MessageBox.Show("El campo inscripcionesId debe estar en 0 para agregar una inscripcion");
                TextBoxPersonaId.Focus();
                paso = false;
            }
            if (string.IsNullOrEmpty(TextBoxPersonaId.Text))
            {
                MessageBox.Show("El campo PersonaId no puede estar vacio y debe ser mayor o igual que 1");
                TextBoxPersonaId.Focus();
                paso = false;
            }

            if (TextBoxComentario.Text == string.Empty)
            {
                MessageBox.Show("El campo comentario no puede estar vacio");
                TextBoxComentario.Focus();
                paso = false;
            }

            if (string.IsNullOrEmpty(TextBoxMonto.Text))
            {
                MessageBox.Show("El campo  monto no puede estar vacio");
                TextBoxBalance.Focus();
                paso = false;
            }

            if (string.IsNullOrEmpty(TextBoxBalance.Text))
            {
                MessageBox.Show("El campo balance no puede estar vacio");
                TextBoxBalance.Focus();
                paso = false;
            }

            return paso;
        }

        /*private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            Inscripciones inscripcion;
            bool paso = false;

            if (!Validar())
                return;

            inscripcion = LlenaClase();

            if (string.IsNullOrEmpty(TextBoxInscripcionesId.Text) || TextBoxInscripcionesId.Text == "0")
                paso = InscripcionesBLL.Guardar(inscripcion);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar persona que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = InscripcionesBLL.Modificar(inscripcion);
            }

            //Informar resultado
            if (paso)
            {
                Limpiar();
            }
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }*/

        private void ButtonNuevo_Click_1(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void ButtonGuardar_Click_1(object sender, RoutedEventArgs e)
        {
            Inscripciones inscripcion;
            bool paso = false;

            if (!Validar())
                return;

            inscripcion = LlenaClase();

            if (string.IsNullOrEmpty(TextBoxInscripcionesId.Text) || TextBoxInscripcionesId.Text == "0")
                paso = InscripcionesBLL.Guardar(inscripcion);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar persona que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = InscripcionesBLL.Modificar(inscripcion);
            }

            //Informar resultado
            if (paso)
            {
                Limpiar();
            }
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void LlenaCampo(Inscripciones inscripcion)
        {
            TextBoxInscripcionesId.Text = Convert.ToString(inscripcion.IncripcionId);
            TextBoxPersonaId.Text =Convert.ToString(inscripcion.PersonaId);
            TextBoxComentario.Text = inscripcion.Comentarios;
            TextBoxMonto.Text = Convert.ToString( inscripcion.Monto );
            TextBoxBalance.Text = Convert.ToString (inscripcion.Balance);
            DatePickerFechaInscripcion.SelectedDate = (DateTime)inscripcion.Fecha;
        }

        private void btn_Buscar_Click(object sender, RoutedEventArgs e) //Buscar
        {
            int id;
            Inscripciones inscripcion = new Inscripciones();
            int.TryParse(TextBoxInscripcionesId.Text, out id);

            Limpiar();

            inscripcion = InscripcionesBLL.Buscar(id);

            if (inscripcion != null)
            {
                MessageBox.Show("Persona encontrada");
                LlenaCampo(inscripcion);
            }
            else
            {
                MessageBox.Show("Persona no encontrada");
            }
        }

        private void ButtonBuscar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Inscripciones inscripcion = new Inscripciones();
            int.TryParse(TextBoxInscripcionesId.Text, out id);

            Limpiar();

            inscripcion = InscripcionesBLL.Buscar(id);

            if (inscripcion != null)
            {
                LlenaCampo(inscripcion);
            }
            else
            {
                MessageBox.Show("Inscripcion no encontrada", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonEliminar_Click(object sender, RoutedEventArgs e)
        {
            Inscripciones inscripcion = new Inscripciones();
            int id;
            int.TryParse(TextBoxPersonaId.Text, out id);
            Limpiar();

            inscripcion = InscripcionesBLL.Buscar(id);
            if (InscripcionesBLL.Eliminar(id))
            {
                PersonasBLL.GuardarBalance(inscripcion.PersonaId, (0 * inscripcion.Balance));
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show( "No se puede eliminar una inscripcion que no existe" , "ERROR", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
