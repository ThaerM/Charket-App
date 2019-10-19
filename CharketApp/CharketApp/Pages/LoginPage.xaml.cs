using CharketApp.Model;
using CharketApp.Pages.HomePage;
using CharketApp.Services;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharketApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        FirebaseClient firebase;
        public LoginPage()
        {
            InitializeComponent();
            firebase = new FirebaseClient(AppConstant.URLData);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //Go to Sign Up page
            await App.Current.MainPage.Navigation.PushAsync(new TypeSignup.Signup());
        }
        private async void CheckUserName()
        {
            UserLogin userLogin = await GetUserService();
            if (userLogin != null)
            {
                //check the user type
                //If use is supermarket
                if (userLogin.UserType == 1)
                {
                    //Go to supermarket page
                    await Navigation.PushAsync(new SupermarketPage());
                }
                //If user is household
                else if (userLogin.UserType == 2)
                {
                    //Go to Household page
                    await Navigation.PushAsync(new Household());
                }
                //if use is charity
                else if (userLogin.UserType == 3)
                {
                    //Go to Charity page
                    await Navigation.PushAsync(new CharityPage());

                }
                //if the user type is missing
                else
                {
                    await DisplayAlert("", "Wrong user rule", "OK");
                }
            }
            else
            {
                //Show message if username or password wrong
                await DisplayAlert("", "Wrong username or password", "OK");
            }
        }
          async Task<List<UserLogin>> GetAllPersons()
        {

            return (await firebase
              .Child("Persons")
              .OnceAsync<UserLogin>()).Select(item => new UserLogin
              {
                  UserName = item.Object.UserName,
                  Password = item.Object.Password
              }).ToList();
        }

        public async Task<UserLogin> GetUserService()
        {
            //Integrateion with database
            FirebaseClient firebase = new FirebaseClient(AppConstant.URLData);
            //Retrun data from database as username or password
            var allPersons = await GetAllPersons();
            await firebase
                .Child("Persons")
                .OnceAsync<UserLogin>();
            return allPersons.Where(a => a.UserName == UsernameEnty.Text && a.Password == PasswordEntry.Text).FirstOrDefault();
        }
    }
}