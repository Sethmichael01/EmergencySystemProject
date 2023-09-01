using EmergencyApplication.Helper;
using EmergencyApplication.Models;
using EmergencyApplication.Services;
using EmergencyApplication.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EmergencyApplication.ViewModels
{
    public class CreateEmergencyRequestViewModel 
    {
        public Action DisplaySubmissionPrompt;
        private HttpClientService<EmergencyRequest> _clientService = new HttpClientService<EmergencyRequest>();
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private int requestId;
        private int sectorId;
        private string title;
        private string comment;
        private string sectorName;


        public int SectorId
        {
            get { return sectorId; }
            set
            {
                sectorId = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SectorId"));
            }
        }
        public string SectorName
        {
            get { return sectorName; }
            
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Title"));
            }
        }
        public string Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Comment"));
            }
        }

        public CreateEmergencyRequestViewModel(int sectorId, string sectorName )
        {
            this.sectorId = sectorId;
            this.sectorName = $"Create {sectorName} Alarm".ToUpper();
            //SubmitRequestCommand = new Command(OnSubmitEmergencyRequest);
        }
        private string createEmergencyError;
        public string CreateEmergencyError
        {
            get { return createEmergencyError; }
            set
            {
                createEmergencyError = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CreateEmergencyError"));
            }
        }
        public ICommand SubmitRequestCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var location = await GeoLocation.GetLocationAsync();
                    var res = await _clientService.PostAsync(new EmergencyRequest
                    {
                        Title = title,
                        Comment = comment,
                        CitizenId = App.UserId,
                        SectorId = sectorId,
                        Longitude = location.Longitude,
                        Latitude = location.Latitude,
                        Altitude = location.Latitude,
                        RequestTime = DateTime.Now
                    }, AppSettings.AddOrUpdateEmergencyRequest);
                    if (res.StatusCode == 200)
                    {
                        var result = JsonConvert.DeserializeObject<AddOrUpdateResponseVm>(res.Data);
                        await Application.Current.MainPage.Navigation.PushAsync(new /*EmergencyRequestPage*/EmergencyRequestListPage());
                    }
                    else
                    {
                        var error = res.ErrorMessage.ToString();
                        CreateEmergencyError = "Invalid Emergecny Request attempt";
                    }
                });
            }
        }
        public void OnSubmitEmergencyRequest()
        {
            DisplaySubmissionPrompt();
        }
    }
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitide { get; set; }
        public double? Altitude { get; set; }

    }
}
