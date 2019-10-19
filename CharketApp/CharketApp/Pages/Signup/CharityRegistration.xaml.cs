using CharketApp.Pages.Profiles;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharketApp.Pages.Signup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharityRegistration : ContentPage
    {
        public CharityRegistration()
        {
            InitializeComponent();
        }

        private async void CharitySubmittHandler(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharityProfile());
        }
    }
}