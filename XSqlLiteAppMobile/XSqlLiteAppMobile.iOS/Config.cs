using System;
using SQLite.Net.Interop;
using XSqlLiteAppMobile.Classes;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(XSqlLiteAppMobile.iOS.Config))]

namespace XSqlLiteAppMobile.iOS
{
    public class Config : IConfig
    {

        private string directoryDB;
        private ISQLitePlatform platform;

        public string DirectoryDB
        {
            get
            {
                if (string.IsNullOrEmpty(directoryDB))
                {
                    var directory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    directoryDB = Path.Combine(directory, "..", "Library");


                }

                return directoryDB;

            }


        }

        public ISQLitePlatform Platform
        {
            get
            {
                if (platform == null)
                {
                    platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }

                return platform;
            }
        }
    }
}