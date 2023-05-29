using EmergencyApplication.Services;
using EmergencyApplication.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmergencyApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private HttpClientService<LoginViewModel> _clientService = new HttpClientService<LoginViewModel>();
        public LoginPage()
        {
            var vm = new LoginViewModel();
            this.BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
            InitializeComponent();           
        }
        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IndexPage());
        }
    }
}