using CharketApp.Model;
using CharketApp.Pages.HomePage;
using CharketApp.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace CharketApp.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        //Private view Model Username
        private string _UserName;
        //Public view Model Username from Private
        public string UserName
        {
            get { return _UserName; }
            set { SetProperty(ref _UserName, value); }
        }
        //Private View Model Password
        private string _Password;
        //Public View Model Password from Private
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }
        //Command to Run after click on login button
        public ICommand OnLoginCommand { private set; get; }
        //Instance with firebase "Database"
        DBFirebase firebase;
        //Constructer
        public LoginViewModel()
        {
            firebase = new DBFirebase();
            OnLoginCommand = new Command(Login);
        }
        //After Click Command Call this method
        private async void Login( )
        {
            //Check the username is null or empty
            if (string.IsNullOrEmpty(UserName))
            {
                //Show message if the username is empty
                await App.Current.MainPage.DisplayAlert("", "Please fill the username", "Ok");
                //stop the code here
                return;
            }
            //Check the password is null or empty
            if (string.IsNullOrEmpty(Password))
            {
                //Show message if the password is empty
                await App.Current.MainPage.DisplayAlert("", "Please fill the password", "Ok");
                //Stop the code here
                return;
            }
            //After check the username and password check the data from firebase "Database"
            CheckUserName();
        }
        //Check the username and password on firebase
        async void CheckUserName()
        {
            //Call the user from database
            var UserData = await firebase.LoginUser(UserName, Password);
            //Check if database return the user or not
            if (UserData != null)
            {
                //Check the user type 

                //If user is supermarket
                if (UserData.UserType == 1)
                {
                    DataInfo.UserDataInfo = UserData;
                    //Go to supermarket page
                    App.Current.MainPage = new NavigationPage(new SupermarketPage());
                }
                //if User is household
                else if (UserData.UserType == 2)
                {
                    DataInfo.UserDataInfo = UserData;
                    //Go to household page 
                    App.Current.MainPage = new NavigationPage(new Household());
                }
                //if user is charity
                else if (UserData.UserType == 3)
                {
                    DataInfo.UserDataInfo = UserData;
                    //Go to Charity page
                    App.Current.MainPage = new NavigationPage(new CharityPage());
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("", "Wrong user rule", "Ok");
                }
            }
            else
            {
                //Show the message if the user is null or not return 
                await App.Current.MainPage.DisplayAlert("", "The Username or password is wrong", "Ok");
            }
        }
    }
}
