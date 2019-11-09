using CharketApp.Pages.Profiles;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharketApp.Pages.Signup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HouseholdRegistration : ContentPage
    {
        public HouseholdRegistration()
        {
            InitializeComponent();
            ContentNameEntry.Completed += (sender, e) => EmailAddressEntry.Focus();
            EmailAddressEntry.Completed += (sender, e) => EmailAddressEntry.Focus();
            ContactNumberEntry.Completed += (sender, e) => AddressEntry.Focus();
            //AddressEntry.Completed += (sender, e) =>
                }

        private async void HouseHoldHandler(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ContentNameEntry.Text))
            {
                await DisplayAlert("", "Please fill the contact name", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(EmailAddressEntry.Text))
            {
                await DisplayAlert("", "Please fill the email address", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(ContactNumberEntry.Text))
            {
                await DisplayAlert("", "Please fill the contact number", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(AddressEntry.Text))
            {
                await DisplayAlert("", "Please fill the address", "Ok");
                return;
            }
            await Navigation.PushAsync(new HouseholdProfile(HouseViewModel));
        }

        private void HouseholdeCheckHnadler(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                if (HouseholdCheckBox.IsChecked)
                {
                    otherHouseholdCheckBox.IsChecked = false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
            }
        }

        private void otherHouseholdCheckHandler(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                if (otherHouseholdCheckBox.IsChecked)
                {
                    HouseholdCheckBox.IsChecked = false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
            }
        }
    }
}