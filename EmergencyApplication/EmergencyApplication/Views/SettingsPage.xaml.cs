using EmergencyApplication.ViewModels;
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
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            var vm = new SettingsViewModel();
            this.BindingContext = vm.PageContent;
            InitializeComponent();
        }

        private async void OnUpdateButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new UpdateProfilePage());
        }
        private async void OnLogOutButton_Clicked(object sender , EventArgs e)
        {
            Application.Current.Properties["IsLoggedIn"] = Boolean.FalseString;
            await Navigation.PushAsync(new IndexPage());
        }
        
    }
}