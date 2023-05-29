using Android.Content.Res;
using EmergencyApplication.Constant;
using EmergencyApplication.Models.AuthenticationModels;
using EmergencyApplication.Services;
using EmergencyApplication.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EmergencyApplication.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        private HttpClientService<LoginRequestModel> _clientService = new HttpClientService<LoginRequestModel>();

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        private string loginError;
        public string LoginError
        {
            get { return loginError; }
            set
            {
                loginError = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LoginError"));
            }
        }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
               {
                   if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || !email.Contains("@"))
                       LoginError = "Invalid Input";
                   else
                   {
                       var res = await _clientService.PostAsync(new LoginRequestModel { Email = email, Password = password }, AppSettings.LoginUrl);
                       if (res.StatusCode == 200)
                       {
                           var result = JsonConvert.DeserializeObject<LoginResponseModel>(res.Data);
                           App.IsUserLoggedIn = true;
                           App.UserId = result.UserId;
                           App.UserRole = result.UserRole;
                           Application.Current.Properties["IsLoggedIn"] = Boolean.TrueString;
                           await Application.Current.MainPage.Navigation.PushAsync(new EmergencyRequestPage());
                       }
                       else
                       {
                           LoginError = "Invalid Login attempt";
                       }
                   }


               });
            }
        }
        public LoginViewModel()
        {

        }

    }
}
