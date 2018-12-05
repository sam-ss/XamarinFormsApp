using System;
using System.IO;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsApp.Data;
using XamarinFormsApp.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinFormsApp
{
    public partial class App : Application
    {
        static UserItemDatabase database;

       
        public App()
        {
           // InitializeComponent();

            // MainPage = new MainPage();
            Resources = new ResourceDictionary();
            Resources.Add("primaryGreen", Color.FromHex("91CA47"));
            Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

            var nav = new NavigationPage(new UserListPageCS());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }
        public static UserItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new UserItemDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeAtTodoId { get; set; }

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
