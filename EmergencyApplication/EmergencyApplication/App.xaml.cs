using EmergencyApplication.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmergencyApplication
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public static int UserId { get; set; }
        public static string UserRole { get; set; }
        public App()
        {
            Device.SetFlags(new[] { "Brush_Experimental" });
            InitializeComponent();
            //bool isLoggedIn = Current.Properties.ContainsKey("IsLoggedIn") ? Convert.ToBoolean(Current.Properties["IsLoggedIn"]) : false;
            //if (!isLoggedIn)
            //{
            //    //Load if Not Logged In
            //    MainPage = new NavigationPage(new IndexPage());
            //}
            //else
            //{
            //    //Load if Logged In
            //    MainPage = new NavigationPage(new EmergencyRequestPage());
            //}
            MainPage = new NavigationPage(new IndexPage());


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
