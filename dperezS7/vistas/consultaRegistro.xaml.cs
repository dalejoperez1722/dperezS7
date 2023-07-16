using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dperezS7.vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class consultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> tabla;
        public consultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            obtener();
        }
        public async void obtener()
        {
            var Resultado = await con.Table<Estudiante>().ToListAsync();
            tabla = new ObservableCollection<Estudiante>(Resultado);
            listaEstudiantes.ItemsSource = tabla;
        }

        private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoestudiante = (Estudiante)e.SelectedItem;
            Navigation.PushAsync(new elemento(objetoestudiante));

        }

        
    }
}