using Foundation;
using SQLite;
using SwiftTraderPRoject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SwiftTraderPRoject.iOS.SQLite_IOS))]

namespace SwiftTraderPRoject.iOS
{
    public class SQLite_IOS : ISqlite
    {
        public SQLiteConnection GetConnection()
        {
            var SqlFile = "Mydatabase.db3";
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string LibraryPath = Path.Combine(docPath, "..", "Library");
            var path = Path.Combine(LibraryPath, SqlFile);
            var cn = new SQLiteConnection(path);

            return cn;
        }
    }
}