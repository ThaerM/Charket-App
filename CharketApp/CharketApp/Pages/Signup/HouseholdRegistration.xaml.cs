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
            await Navigation.PushAsync(new HouseholdProfile());
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