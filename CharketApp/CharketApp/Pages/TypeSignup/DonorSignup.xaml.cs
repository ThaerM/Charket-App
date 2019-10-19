using CharketApp.Pages.Signup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharketApp.Pages.TypeSignup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DonorSignup : ContentPage
    {
        public DonorSignup()
        {
            InitializeComponent();
        }

        private void GoToLoginHandler(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }

        private void GoToHouseHoldHandler(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HouseholdRegistration());
        }

        private void GoToSupermarketHandler(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SupermarketRegistration());
        }
    }
}