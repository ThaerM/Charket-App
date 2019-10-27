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
            OrginazationNameEntry.Completed += (sender,e) => StreetAddressEntry.Focus();
            StreetAddressEntry.Completed += (sender, e) => StreetAddress2Entry.Focus();
            StreetAddress2Entry.Completed += (sender, e) => ContactNumberEntry.Focus();
            ContactNumberEntry.Completed += (sender, e) => OfficePhoneNumberEntry.Focus();
            OfficePhoneNumberEntry.Completed += (sender, e) => MobileNumberEntry.Focus();
            MobileNumberEntry.Completed += (sender, e) => ContactEmailEntry.Focus();
           // ContactEmailEntry.Completed += (sender, e) => ContactEmailEntry.Focus();
        }

        private async void CharitySubmittHandler(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharityProfile());
        }
    }
}