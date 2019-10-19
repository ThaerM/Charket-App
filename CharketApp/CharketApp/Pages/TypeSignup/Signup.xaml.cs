using CharketApp.Pages.Signup;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharketApp.Pages.TypeSignup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signup : ContentPage
    {
        public Signup()
        {
            InitializeComponent();
        }

        private async void GoToLoginHandler(object sender, EventArgs e)
        {
           await Navigation.PopAsync();
        }

        private void GoToDonorHandler(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DonorSignup());
        }

        private void GoToCharityHandler(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CharityRegistration());
        }
    }
}