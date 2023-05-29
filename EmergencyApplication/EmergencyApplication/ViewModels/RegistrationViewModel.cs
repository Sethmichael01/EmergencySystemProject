using EmergencyApplication.Models;
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
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        private HttpClientService<RegisterRequestModel> _clientService = new HttpClientService<RegisterRequestModel>();
        public Action DisplayInvalidRegistrationPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string firstName;
        private string middletName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private string password;
        private string confirmPassword;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
            }
        }
        public string MiddleName
        {
            get { return middletName; }
            set
            {
                middletName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MiddleName"));
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PhoneNumber"));
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ConfirmPassword"));
            }
        }
        private string registerError;
        public string RegisterError
        {
            get { return registerError; }
            set
            {
                registerError = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RegisterError"));
            }
        }
        public ICommand SubmitCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || !email.Contains("@") || string.IsNullOrEmpty(firstName)||string.IsNullOrEmpty(lastName)||string.IsNullOrEmpty(middletName)||string.IsNullOrEmpty(phoneNumber))
                        RegisterError = "Invalid Input";
                    else
                    {
                        var res = await _clientService.PostAsync(new RegisterRequestModel {Email = email, FirstName = firstName, LastName = lastName, MiddleName = middletName, PhoneNumber = phoneNumber, Password = password, ConfirmPassword = confirmPassword }, AppSettings.RegisterUrl);
                        if (res.StatusCode == 200)
                        {
                            var result = JsonConvert.DeserializeObject<AddOrUpdateResponseVm>(res.Data);
                            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                        }
                        else
                        {
                            var error = res.ErrorMessage.ToString();
                            RegisterError = "Invalid Registration attempt";
                        }
                    }
                });
            }

        }
        public RegistrationViewModel()
        {
            //SubmitCommand = new Command(OnSubmit);
        }
        public void OnSubmit()
        {
            if (!email.Contains(".com"))
            {
                DisplayInvalidRegistrationPrompt();
            }
        }
    }
}
