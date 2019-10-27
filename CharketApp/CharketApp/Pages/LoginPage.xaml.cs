using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharketApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            UsernameEnty.Completed += (sender,e) => PasswordEntry.Focus();
            PasswordEntry.Completed += (sender,e) => loginVM.OnLoginCommand.Execute(null);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //Go to Sign Up page
            await App.Current.MainPage.Navigation.PushAsync(new TypeSignup.Signup());
        }
    }
}