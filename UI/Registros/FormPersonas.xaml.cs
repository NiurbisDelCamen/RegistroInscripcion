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
    /// Interaction logic for FormPersonas.xaml
    /// </summary>
    public partial class FormPersonas : Window
    {
        public FormPersonas()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            TextBoxPersonaId.Text = "0";
            TextBoxNombre.Text = string.Empty;
            TextBoxCedula.Text = string.Empty;
            TextBoxTelefono.Text = string.Empty;
            TextBoxDireccion.Text = string.Empty;
            DatePickerFechaNacimiento.SelectedDate = DateTime.Now;
        }

        private void ButtonNuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private Personas LlenaClase()
        {
            Personas persona = new Personas();

            persona.PersonaID = Convert.ToInt32(TextBoxPersonaId.Text);
            persona.Nombre = TextBoxNombre.Text;
            persona.Telefono = TextBoxTelefono.Text;
            persona.Cedula = TextBoxCedula.Text;
            persona.Direccion = TextBoxDireccion.Text;
            persona.FechaNacimiento = (DateTime)DatePickerFechaNacimiento.SelectedDate;
            persona.Balance = Convert.ToDecimal(TextBoxBalance.Text);
            return persona;
        }

        private void ButtonGuardar_Click(object sender, RoutedEventArgs e)
        {
            Personas persona;
            bool paso = false;

            if (!Validar())
                return;

            persona = LlenaClase();

            if (string.IsNullOrEmpty(TextBoxPersonaId.Text) || TextBoxPersonaId.Text == "0")
                paso = PersonasBLL.Guardar(persona);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar persona que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = PersonasBLL.Modificar(persona);
            }

            //Informar resultado
            if (paso)
            {
                Limpiar();
            }
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void LlenaCampo(Personas persona)
        {
            TextBoxPersonaId.Text = Convert.ToString(persona.PersonaID);
            TextBoxNombre.Text = persona.Nombre;
            TextBoxCedula.Text = persona.Cedula;
            TextBoxTelefono.Text = persona.Telefono;
            TextBoxDireccion.Text = persona.Direccion;
            DatePickerFechaNacimiento.SelectedDate = persona.FechaNacimiento;
            TextBoxBalance.Text = Convert.ToString(persona.Balance);
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Personas persona = PersonasBLL.Buscar(Convert.ToInt32(TextBoxPersonaId.Text));
            return (persona != null);
        }

        private bool Validar() //Validar los campos
        {
            bool paso = true;
            if(string.IsNullOrEmpty(TextBoxPersonaId.Text))
            {
                MessageBox.Show("El campo PersonaID debe estar en 0 para agregar una nueva persona");
                TextBoxPersonaId.Focus();
                paso = false;
            }

            if (TextBoxNombre.Text == string.Empty) 
            {
                MessageBox.Show("El campo direccion no puede estar vacio");
                TextBoxNombre.Focus();
                paso = false;
            }

            if (string.IsNullOrEmpty(TextBoxCedula.Text))
            {
                MessageBox.Show("El campo  cedula no puede estar vacio");
                TextBoxCedula.Focus();
                paso = false;
            }

            if (string.IsNullOrEmpty(TextBoxTelefono.Text))
            {
                MessageBox.Show("El campo telefono no puede estar vacio");
                TextBoxTelefono.Focus();
                paso = false;
            }

            if (string.IsNullOrEmpty(TextBoxDireccion.Text))
            {
                MessageBox.Show("El campo direccion no puede estar vacio");
                TextBoxTelefono.Focus();
                paso = false;
            }
            return paso;
        }

        private void ButtonBuscar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Personas persona = new Personas();
            int.TryParse(TextBoxPersonaId.Text, out id);

            Limpiar();

            persona = PersonasBLL.Buscar(id);

            if (persona != null)
            {
                MessageBox.Show("Persona encontrada");
                LlenaCampo(persona);
            }
            else
            {
                MessageBox.Show("Persona no encontrada");
            }
        }

        private void ButtonEliminar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(TextBoxPersonaId.Text, out id);
            Limpiar();

            if (PersonasBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("No se puede eliminar una persona que no existe");
            }
        }

    }
}
