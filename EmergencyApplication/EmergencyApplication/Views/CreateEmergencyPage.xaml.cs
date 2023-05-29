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
    public partial class CreateEmergencyPage : ContentPage
    {
        public CreateEmergencyPage(int sectoId, string sectorName)
        {
            var vm = new CreateEmergencyRequestViewModel(sectoId,sectorName);
            this.BindingContext = vm;
            vm.DisplaySubmissionPrompt = () => DisplayAlert("Submitted Successfully", "Help is on the way", "OK");
            InitializeComponent();
        }
        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}