using CharketApp.Pages.Profiles;
using System;
using System.Diagnostics;
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
            OrginazationNameEntry.Completed += (sender, e) => StreetAddressEntry.Focus();
            StreetAddressEntry.Completed += (sender, e) => StreetAddress2Entry.Focus();
            StreetAddress2Entry.Completed += (sender, e) => PostcodeEntry.Focus();
            PostcodeEntry.Completed += (sender, e) => OfficePhoneNumberEntry.Focus();
            OfficePhoneNumberEntry.Completed += (sender, e) => MobileNumberEntry.Focus();
            MobileNumberEntry.Completed += (sender, e) => ContactEmailEntry.Focus();
            // ContactEmailEntry.Completed += (sender, e) => ContactEmailEntry.Focus();
        }

        private async void CharitySubmittHandler(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharityProfile(HouseViewModel));
        }

        private void FoodServiceCheckHnadler(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                if (FoodServiceCheckBox.IsChecked)
                {
                    otherFoodServiceCheckBox.IsChecked = false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
            }
        }

        private void OtherFoodServiceCheckHandler(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                if (otherFoodServiceCheckBox.IsChecked)
                {
                    FoodServiceCheckBox.IsChecked = false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
            }
        }
    }
}