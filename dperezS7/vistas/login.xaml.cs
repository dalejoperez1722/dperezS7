using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dperezS7.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        private SQLiteAsyncConnection con;
        public login()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }
        public static IEnumerable<Estudiante> select_where(SQLiteConnection db, string usuario, string contraseña)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where usuario=? and contraseña =?", usuario, contraseña);
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = select_where(db, txtUsuario.Text, txtContraseña.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new consultaRegistro());

                }
                else
                {
                    DisplayAlert("error", "usuario o contraseña incorrecta", "cerrar");

                }

            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "cerrar");
            }

        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new registro());
        }
    }
}