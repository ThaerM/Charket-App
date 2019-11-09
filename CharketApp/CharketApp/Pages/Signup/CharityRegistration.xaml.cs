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
            if (string.IsNullOrEmpty(OrginazationNameEntry.Text))
            {
                await DisplayAlert("", "Please fill the orginazation name", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(StreetAddressEntry.Text))
            {
                await DisplayAlert("", "Please fill the street address", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(PostcodeEntry.Text))
            {
                await DisplayAlert("", "Please fill the post code", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(OfficePhoneNumberEntry.Text))
            {
                await DisplayAlert("", "Please fill the office phone number", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(MobileNumberEntry.Text))
            {
                await DisplayAlert("", "Please fill the mobile phone number", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(ContactEmailEntry.Text))
            {
                await DisplayAlert("", "Please fill the contact email address", "Ok");
                return;
            }
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