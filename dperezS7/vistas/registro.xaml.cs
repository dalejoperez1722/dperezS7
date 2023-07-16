using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dperezS7.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class registro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public registro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var datoRegistro = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contraseña = txtContraseña.Text };
                con.InsertAsync(datoRegistro);
                Navigation.PushAsync(new login());

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "cerrar");
            }

        }
    }
}