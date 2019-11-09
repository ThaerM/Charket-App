using CharketApp.Pages.Profiles;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharketApp.Pages.Signup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupermarketRegistration : ContentPage
    {
        public SupermarketRegistration()
        {
            InitializeComponent();
            NameBusinessEntry.Completed += (sender, e) => ContentNameEntry.Focus();
            ContentNameEntry.Completed += (sender, e) => EmailAddressEntry.Focus();
            EmailAddressEntry.Completed += (sender, e) => ContactNumberEntry.Focus();
            ContactNumberEntry.Completed += (sender, e) => AddressEntry.Focus();
            //AddressEntry.Completed += (sender, e) => AddressEntry.Focus();
        }

        private async void SupermarketSumitHandler(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameBusinessEntry.Text))
            {
                await DisplayAlert("", "Please fill the name of business", "Ok");
                return;
            }
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
            await Navigation.PushAsync(new SupermarketProfile(SupermarketVM));
        }

        private void SupermarketCheckHnadler(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                if (SupermarketCheckBox.IsChecked)
                {
                    otherSupermarketCheckBox.IsChecked = false;
                }
            }catch(Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
            }
        }

        private void OtherSupermarketCheckHandler(object sender, CheckedChangedEventArgs e)
        {
            try{if (otherSupermarketCheckBox.IsChecked)
            {
                SupermarketCheckBox.IsChecked = false;
            }
             }catch(Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
            }
        }
    }
}