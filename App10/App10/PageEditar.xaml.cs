using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App10
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEditar : ContentPage
    {
        public PageEditar()
        {
            InitializeComponent();
        }

        private void Guardar(object sender, EventArgs e)
        {
            App.Personas.RemoveAll(n => n.Nombre == App.temp_nombre);
            App.Persona nuevaPersona = new App.Persona() { Nombre = txtNombre.Text, Correo = txtCorreo.Text };
            App.Personas.Add(nuevaPersona);
            Navigation.PopAsync();
        }

        private void Cancelar(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}