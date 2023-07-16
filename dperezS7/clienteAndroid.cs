using dperezS7;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(clienteAndroid))]

namespace dperezS7
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
