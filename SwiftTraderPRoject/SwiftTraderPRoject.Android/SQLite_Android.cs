using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SwiftTraderPRoject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly:Dependency(typeof(SwiftTraderPRoject.Droid.SQLite_Android))]
namespace SwiftTraderPRoject.Droid
{
    public class SQLite_Android : ISqlite
    {
        public SQLiteConnection GetConnection()
        {
            var SqlFile = "Mydatabase.db3";
            string docPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(docPath, SqlFile);
            var cn = new SQLiteConnection(path);

            return cn;
        }
    }
}