using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using dperezS7.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(clienteAndroid))]

namespace dperezS7.Droid
{
    public class clienteAndroid : DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var rutaBase = Path.Combine(ruta, "uisrael.db3");
            return new SQLiteAsyncConnection(rutaBase);
        }
    }
}