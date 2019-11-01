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