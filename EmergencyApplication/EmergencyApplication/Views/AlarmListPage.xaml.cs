using EmergencyApplication.Models;
using EmergencyApplication.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmergencyApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlarmListPage : ContentPage
    {
        private HttpClientService<List<AlarmVm>> _clientService = new HttpClientService<List<AlarmVm>>();
        ObservableCollection<AlarmVm> alarms = new ObservableCollection<AlarmVm>();
        public ObservableCollection<AlarmVm> AlarmList { get { return alarms; } }

        public AlarmListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            var result = new List<AlarmVm>();
            base.OnAppearing();
            var res = await _clientService.GetAsync(AppSettings.GetSectors);
            if (res.StatusCode == 200)
            {
                result  = JsonConvert.DeserializeObject<List<AlarmVm>>(res.Data);
                foreach (var item in result)
                {
                    alarms.Add(item);
                }

            }
            AlarmListView.ItemsSource = result;
        }
        private async void AlarmButton_Clicked(object sender, ItemTappedEventArgs e)
        {
            //var index = alarmList.IndexOf(e.Item as AlarmVm);
            var item = e.Item as AlarmVm;
            await Navigation.PushAsync(new CreateEmergencyPage(item.SectorId, item.SectorName));
        }

        private async void AlarmListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as AlarmVm;
            await Navigation.PushAsync(new CreateEmergencyPage(item.SectorId, item.SectorName));
        }
    }
}