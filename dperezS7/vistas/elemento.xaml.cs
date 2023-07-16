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
    public partial class elemento : ContentPage
    {
        private SQLiteAsyncConnection con;
        public int IdSeleccionado;
        IEnumerable<Estudiante> rActualizar;
        IEnumerable<Estudiante> rEliminar;
        public elemento(Estudiante datos)
        {
            InitializeComponent();
            txtNombre.Text = datos.Nombre;
            txtUsuario.Text = datos.Usuario;
            txtContraseña.Text = datos.Contraseña;
            IdSeleccionado = datos.Id;

            con = DependencyService.Get<DataBase>().GetConnection();
        }

        public static IEnumerable<Estudiante> Eliminar(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("delete from Estudiante where Id = ?", id);
        }

        public static IEnumerable<Estudiante> Actualizar(SQLiteConnection db, int id, string nombre, string usuario, string contraseña)
        {
            return db.Query<Estudiante>("update Estudiante set Nombre=?,Usuario=?,Contraseña=? where Id = ?", nombre, usuario, contraseña, id);
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                rActualizar = Actualizar(db, IdSeleccionado, txtNombre.Text, txtUsuario.Text, txtContraseña.Text);
                Navigation.PushAsync(new consultaRegistro());
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                rEliminar = (IEnumerable<Estudiante>)Eliminar(db, IdSeleccionado);
                Navigation.PushAsync(new consultaRegistro());
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}