using CharketApp.Model;
using CharketApp.Pages;
using CharketApp.Services;
using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace CharketApp.ViewModel.SignupViewModel
{
    public class CharityRegViewModel : BaseViewModel
    {
        private UserData _UserDataCollection;
        public UserData UserDataCollection
        {
            get { return _UserDataCollection; }
            set { SetProperty(ref _UserDataCollection, value); }
        }
        //************** Supermarket Data ******************
        #region SuperMarket data
        private string _OrginazationName;
        public string OrginazationName { get { return _OrginazationName; } set { SetProperty(ref _OrginazationName, value); } }

        private string _StreetAddress;
        public string StreetAddress { get { return _StreetAddress; } set { SetProperty(ref _StreetAddress, value); } }

        private string _StreetAddress2;
        public string StreetAddress2 { get { return _StreetAddress2; } set { SetProperty(ref _StreetAddress2, value); } }

        private string _Postcode;
        public string Postcode { get { return _Postcode; } set { SetProperty(ref _Postcode, value); } }

        private string _OfficePhoneNumber;
        public string OfficePhoneNumber { get { return _OfficePhoneNumber; } set { SetProperty(ref _OfficePhoneNumber, value); } }

        private string _MobileNumber;
        public string MobileNumber { get { return _MobileNumber; } set { SetProperty(ref _MobileNumber, value); } }

        private string _ContactEmail;
        public string ContactEmail { get { return _ContactEmail; } set { SetProperty(ref _ContactEmail, value); } }

        private bool _IsCharity;
        public bool IsCharity { get { return _IsCharity; } set { SetProperty(ref _IsCharity, value); } }

        private string _WhayCharity;
        public string WhayCharity { get { return _WhayCharity; } set { SetProperty(ref _WhayCharity, value); } }

        private bool _IsFoodDonationCharity;
        public bool IsFoodDonationCharity { get { return _IsFoodDonationCharity; } set { SetProperty(ref _IsFoodDonationCharity, value); } }

        private string _IsOtherFoodDonationCharity;
        public string IsOtherFoodDonationCharity { get { return _IsOtherFoodDonationCharity; } set { SetProperty(ref _IsOtherFoodDonationCharity, value); } }

        #endregion

        //**********************User Data********************

        private string _Username;
        public string Username { get { return _Username; } set { SetProperty(ref _Username, value); } }

        private string _Password;
        public string Password { get { return _Password; } set { SetProperty(ref _Password, value); } }

        public ICommand OnCharityCommand { private set; get; }
        //Instance with firebase "Database"
        FirebaseClient firebase;
        public CharityRegViewModel()
        {
            firebase = new FirebaseClient(AppConstant.URLData);
            OnCharityCommand = new Command(CharityRegiestration);
            UserDataCollection = new UserData();
        }

        private async void CharityRegiestration()
        {
            if (UserDataCollection != null)
            {
                UserDataCollection.UserType = 3;
                UserDataCollection.UserName = Username;
                UserDataCollection.Password = Password;
                UserDataCollection.CharityModel = new CharityModel
                {
                    OrginazationName = OrginazationName,
                    StreetAddress = StreetAddress,
                    StreetAddress2 = StreetAddress2,
                    PostalCode = Postcode,
                    OfficePhoneNumber = OfficePhoneNumber,
                    MobilePhoneNumber = MobileNumber,
                    ContactEmailAddress = ContactEmail,
                    DescriptionService = new FoodFromCharity { isCharity = IsCharity, OtherTypeCharity = WhayCharity },
                    foodDonationCharity = new FoodDonationCharity { isFoodDontationCharity = IsFoodDonationCharity, IsOtherFoodDontationCharit = IsOtherFoodDonationCharity }
                };
                try
                {
                    await firebase.Child("Users").PostAsync(JsonConvert.SerializeObject(UserDataCollection));
                    App.Current.MainPage = new LoginPage();
                }
                catch (Exception ex) { Debug.WriteLine("Error " + ex.Message); }
            }
        }
    }
}
