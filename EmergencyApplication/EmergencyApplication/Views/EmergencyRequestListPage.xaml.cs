using EmergencyApplication.Constant;
using EmergencyApplication.Models;
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
    public partial class EmergencyRequestListPage : ContentPage
    {
        private HttpClientService<List<EmergencyRequest>> _clientService = new HttpClientService<List<EmergencyRequest>>();

        public EmergencyRequestListPage()
        {
            InitializeComponent();

        }
        protected async override void OnAppearing()
        {
            var vm = new EmergencyRequestListViewModel();
            base.OnAppearing();
            var res = await _clientService.GetAsync(AppSettings.GetUserEmergencyRequestListEndpoint(App.UserId, App.UserRole));

            if (res.StatusCode == 200)
            {
                vm.EmergencyRequests = JsonConvert.DeserializeObject<List<EmergencyRequest>>(res.Data);
            }
            BindingContext = vm;

        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var selectedRequest = e.SelectedItem as EmergencyRequest;

                if (selectedRequest.Status != RequestStatus.Completed.ToString())
                {
                    await Navigation.PushModalAsync(new EmergencyRequestDetailsPage(selectedRequest), true);
                }
            }

            //if (e.SelectedItem != null)
            //    await Navigation.PushModalAsync(new EmergencyRequestDetailsPage(e.SelectedItem as EmergencyRequest), true);
        }
    }
}