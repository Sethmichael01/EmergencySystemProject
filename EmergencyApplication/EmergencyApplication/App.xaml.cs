using EmergencyApplication.Constant;
using EmergencyApplication.Services;
using EmergencyApplication.Views;
using Xamarin.Forms;

namespace EmergencyApplication
{
    public partial class App : Application
    {
        private ApiCallServiceTimer apiCallService;
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
            if(UserRole == RoleName.Staff)
            {
                apiCallService = new ApiCallServiceTimer();
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
