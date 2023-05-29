using EmergencyApplication.Services;
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
    public partial class RegistrationPage : ContentPage
    {        
        public RegistrationPage()
        {
            var service = new HttpClientService<RegistrationViewModel>();
            var vm = new RegistrationViewModel();
            this.BindingContext = vm;
            vm.DisplayInvalidRegistrationPrompt += () => DisplayAlert("Error", "Invalid Email, try again", "OK");
            InitializeComponent();

            FirstName.Completed += (object sender, EventArgs e) =>
            {
                MiddleName.Focus();
            };
            MiddleName.Completed += (object sender, EventArgs e) =>
            {
                LastName.Focus();
            };
            LastName.Completed += (object sender, EventArgs e) =>
            {
                PhoneNumber.Focus();
            };
            PhoneNumber.Completed += (object sender, EventArgs e) =>
            {
                Email.Focus();
            };
            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };
            Password.Completed += (object sender, EventArgs e) =>
            {
                ConfirmPassword.Focus();
            };
            ConfirmPassword.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
            };
        }
        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {

            //await 
            await Navigation.PushAsync(new LoginPage());
        }
        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IndexPage());
        }
    }
}