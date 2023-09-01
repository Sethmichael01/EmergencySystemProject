using EmergencyApplication.Constant;
using EmergencyApplication.Helper;
using EmergencyApplication.Models;
using EmergencyApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmergencyApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmergencyRequestDetailsPage : ContentPage
    {
        private HttpClientService<EmergencyRequest> _clientService = new HttpClientService<EmergencyRequest>();
        private EmergencyRequest request;
        private bool isPageVisible;
        public EmergencyRequestDetailsPage(EmergencyRequest model)
        {
            request = model;
            BindingContext = model;
            InitializeComponent();
            if (model.Status != RequestStatus.Completed.ToString() && App.UserRole == RoleName.Staff) 
            {
                AssignButton.IsVisible = true;

                if (model.Status.Equals(RequestStatus.Pending.ToString()))
                {
                    AssignButton.BackgroundColor = Color.Red;
                    AssignButton.Text = "Accept Request";

                }
                else 
                {
                    AssignButton.BackgroundColor = Color.Blue;
                    AssignButton.Text = "Completed";
                }
            }
        }
        private async void OnDismissButton_Clicked(object sender, EventArgs args)
        {
            //await Navigation.PopModalAsync();
            var newPage = new EmergencyRequestListPage();
            await Navigation.PushModalAsync(newPage);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var location = await GeoLocation.GetEmergencyLocationAsync();
            request.StaffId = App.UserId;
            request.StaffLatitude = location.StaffLatitude;
            request.StaffLongitude = location.StaffLongitude;
            request.StaffAltitude = location.StaffAltitude;
            request.Status = request.Status == RequestStatus.Pending.ToString() ? RequestStatus.InProgress.ToString() : RequestStatus.Completed.ToString();
            if(request.Status == RequestStatus.Completed.ToString())
            {
                request.CompletedAt = DateTime.Now;
            }
            var res = await _clientService.PostAsync(request, AppSettings.AddOrUpdateEmergencyRequest);
            if (res.StatusCode == 200)
            {
                await ReloadPage();
                await DisplayAlert("Success", "Emergency Request Updated Successfully", "OK");

                //AssignError.Text = "Emergency Request Assigned to you Successfully.";
                //AssignError.TextColor = Color.Green;

            }
            else
            {
                await DisplayAlert("Failed", "Assigning this Request to you Failed", "OK");
                //AssignError.Text = "Emergency Request Not Assigned, Contact admin";
                //AssignError.TextColor = Color.Red;
            }
        }
        private async void Button_Clicked_Timer()
        {
            var location = await GeoLocation.GetEmergencyLocationAsync();
            request.StaffId = App.UserId;
            request.StaffLatitude = location.StaffLatitude;
            request.StaffLongitude = location.StaffLongitude;
            request.StaffAltitude = location.StaffAltitude;
            //request.Status = request.Status == RequestStatus.Pending.ToString() ? RequestStatus.InProgress.ToString() : RequestStatus.Completed.ToString();
            if (request.Status == RequestStatus.Completed.ToString())
            {
                request.CompletedAt = DateTime.Now;
            }
            var res = await _clientService.PostAsync(request, AppSettings.AddOrUpdateEmergencyRequest);
        }

        private async Task ReloadPage()
        {
            /// Create a new instance of the EmergencyRequestDetailsPage and present it modally
            var newPage = new EmergencyRequestDetailsPage(request);
            await Navigation.PushModalAsync(newPage);
        }
        private async void NavigateTo(object sender, EventArgs e)
        {
            if(App.UserRole == RoleName.Staff)
            {
                var location = new Location(request.Latitude, request.Longitude);
                var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };
                await Map.OpenAsync(location, options);
            }
            else
            {
                var location = new Location(request.StaffLatitude, request.StaffLongitude);
                var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };
                await Map.OpenAsync(location, options);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            isPageVisible = true;

            Device.StartTimer(TimeSpan.FromSeconds(30), () =>
            {
                if (isPageVisible)
                {
                    Button_Clicked_Timer();
                    return true; // keeps the timer running
                }

                return false; // stops the timer
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            isPageVisible = false;
        }

        protected override bool OnBackButtonPressed()
        {
            if (request.Status != RequestStatus.Completed.ToString())
            {
                // The request is not completed, so we prevent the back button from closing the page.
                return true;
            }

            // The request is completed, so we allow the back button to close the page.
            return base.OnBackButtonPressed();
        }
    }
}