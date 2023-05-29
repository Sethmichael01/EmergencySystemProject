using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmergencyApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmergencyRequestPage : TabbedPage
    {
        public EmergencyRequestPage()
        {
            var navigation = new NavigationPage(new AlarmListPage())
            {
                Title = "RAISE ALARM",
                IconImageSource = "baseline_campaign_black_18",
            };
            var emergencyRequestListNav = new NavigationPage(new EmergencyRequestListPage())
            {
                Title = "MY REQUESTS",
                IconImageSource = "baseline_format_list_numbered_rtl_black_18",

            };
            Children.Add(navigation);
            Children.Add(emergencyRequestListNav);
            Children.Add(new SettingsPage());
            InitializeComponent();
        }
    }
}