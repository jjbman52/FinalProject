using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FinalProject.Services;
using FinalProject.Views;
using System.IO;

namespace FinalProject
{
    public partial class App : Application
    {
        private static DataStore database;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<DataStore>();
            MainPage = new MainPage();
        }

        public static DataStore Database
        {
            get
            {
                if (database == null)
                {
                    database = new DataStore(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CharacterSQLite.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}