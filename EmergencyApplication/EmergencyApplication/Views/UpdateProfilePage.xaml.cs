using EmergencyApplication.Models;
using EmergencyApplication.Models.AuthenticationModels;
using EmergencyApplication.Services;
using EmergencyApplication.ViewModels;
using Newtonsoft.Json;
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
    public partial class UpdateProfilePage : ContentPage
    {
        private HttpClientService<CitizenMobileVm> _clientService = new HttpClientService<CitizenMobileVm>();
        public CitizenMobileVm UserProfile = new CitizenMobileVm();
        public UpdateProfilePage()
        {
            InitializeComponent();

           
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var res = await _clientService.GetAsync(AppSettings.GetUserProfileEndpoint(App.UserId));
            if(res.StatusCode== 200)
            {
                UserProfile = JsonConvert.DeserializeObject<CitizenMobileVm>(res.Data);
            }
            BindingContext = UserProfile;
        }
        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        private async void UpdateProfileButton_Clicked(object sender, EventArgs e)
        {
            var res = await _clientService.PostAsync(UserProfile, AppSettings.UpdateProfile);
            if (res.StatusCode == 200)
            {
               
                await DisplayAlert("Success", "Profile Updated Successfully", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Profile Update Failed", "OK");
            }
            
        }
    }
}