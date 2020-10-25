using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App10
{
    public partial class MainPage : ContentPage
    {
        List<Persona> Personas = new List<Persona>();

        public MainPage()
        {
            InitializeComponent();
            lstPersonas.ItemsSource = Personas.ToList();

        }

        private void button_Clicked(object sender, EventArgs e)
        {
            lblMensaje.Text = txtNombre.Text;
            Persona nuevaPersona = new Persona() { Nombre = txtNombre.Text, Correo = txtCorreo.Text };
            Personas.Add(nuevaPersona);
            lstPersonas.ItemsSource = Personas.OrderBy(n => n.Nombre).ToList();
            txtNombre.Text = "";
            txtCorreo.Text = "";

        }

        private void cmdLimpiar(object sender, EventArgs e)
        {
            Personas.RemoveAll(n => n.Nombre == txtNombre.Text);
            lstPersonas.ItemsSource = Personas.OrderBy(n => n.Nombre).ToList();
            txtNombre.Text = "";
            txtCorreo.Text = "";
        }

        private void lstPersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var personaSeleccionada = e.SelectedItem as Persona;
            txtNombre.Text = personaSeleccionada.Nombre;
            txtCorreo.Text = personaSeleccionada.Correo;
            lblMensaje.Text = personaSeleccionada.Nombre;
        }

        private void button_modificar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Eliminar_page()
            {
                BindingContext = new Persona() { Nombre = txtNombre.Text, Correo = txtCorreo.Text }
            });

            
        }

        private void Secundaria(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Eliminar_page() { 
            BindingContext=new Persona() { Nombre =txtNombre.Text, Correo = txtCorreo.Text}
            });

        }
    }

    internal class Persona
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
    }
}
