using Api.Database;
using Api.Views.AccessApp;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Api
{
    public partial class App : Application
    {
        #region Database
        static DataConect database;

        public static DataConect Database
        {
            get
            {
                if (database == null)
                {
                    database = new DataConect(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBname.db"));
                }
                return database;
            }
        }
        #endregion

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new RegisterPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
