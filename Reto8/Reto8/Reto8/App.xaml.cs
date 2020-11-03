using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Reto8.Views;
using Reto8.Data;

namespace Reto8
{
    public partial class App : Application
    {
        static ContactDataBase database;

        public static ContactDataBase DataBase
        {
            get
            {
                if (database == null)
                {
                    database = new ContactDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Contacts.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
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
