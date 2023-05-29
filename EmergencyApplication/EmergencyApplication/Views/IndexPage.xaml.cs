using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmergencyApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IndexPage : ContentPage
    {
        public IndexPage()
        {
            InitializeComponent();
            AnimateCarousel();
        }
        Timer timer;
        private void AnimateCarousel()
        {
            timer = new Timer(5000) { AutoReset = true, Enabled = true };
            timer.Elapsed += (s, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (cvPageContent.Position == 1)
                    {
                        cvPageContent.Position = 0;
                        return;
                    }
                    cvPageContent.Position += 1;
                });
            };
        }
        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }        

    }
}