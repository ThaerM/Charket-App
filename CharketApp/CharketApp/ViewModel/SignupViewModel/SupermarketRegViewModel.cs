using CharketApp.Model;
using CharketApp.Pages;
using CharketApp.Services;
using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace CharketApp.ViewModel
{
    public class SupermarketRegViewModel : BaseViewModel
    {
        private UserData _UserDataCollection;
        public UserData UserDataCollection
        {
            get { return _UserDataCollection; }
            set { SetProperty(ref _UserDataCollection, value); }
        }
        //************** Supermarket Data ******************
        #region SuperMarket data
        private string _NameBusiness;
        public string NameBusiness
        {
            get { return _NameBusiness; }
            set { SetProperty(ref _NameBusiness, value); }
        }
        private string _ContentName;
        public string ContentName
        {
            get { return _ContentName; }
            set { SetProperty(ref _ContentName, value); }
        }

        private string _EmailAddress;
        public string EmailAddress
        {
            get { return _EmailAddress; }
            set { SetProperty(ref _EmailAddress, value); }
        }
        private string _ContactNumber;
        public string ContactNumber
        {
            get { return _ContactNumber; }
            set { SetProperty(ref _ContactNumber, value); }
        }
        private string _Address;
        public string Address
        {
            get { return _Address; }
            set { SetProperty(ref _Address, value); }
        }
        private bool _IsSuperMarket;
        public bool IsSuperMarket
        {
            get { return _IsSuperMarket; }
            set { SetProperty(ref _IsSuperMarket, value); }
        }

        private string _OtherSuperarket;
        public string OtherSupermarket
        {
            get { return _OtherSuperarket; }
            set { SetProperty(ref _OtherSuperarket, value); }
        }
        private bool _IsCannedFood;
        public bool IsCannedFood
        {
            get { return _IsCannedFood; }
            set { SetProperty(ref _IsCannedFood, value); }
        }
        private bool _IsDryFood;
        public bool IsDryFood
        {
            get { return _IsDryFood; }
            set { SetProperty(ref _IsDryFood, value); }
        }
        private bool _IsFruits;
        public bool IsFruits
        {
            get { return _IsFruits; }
            set { SetProperty(ref _IsFruits, value); }
        }
        private bool _IsVegetables;
        public bool IsVegetables
        {
            get { return _IsVegetables; }
            set { SetProperty(ref _IsVegetables, value); }
        }
        private string _IsOtherFoodType;
        public string IsOtherFoodType
        {
            get { return _IsOtherFoodType; }
            set { SetProperty(ref _IsOtherFoodType, value); }
        }
        private string _AverageFood;
        public string AverageFood
        {
            get { return _AverageFood; }
            set { SetProperty(ref _AverageFood, value); }
        }

        private string _ExpiryDate;
        public string ExpiryDate
        {
            get { return _ExpiryDate; }
            set { SetProperty(ref _ExpiryDate, value); }
        }
        private string _OtherExpiryDate;
        public string OtherExpiryDate
        {
            get { return _OtherExpiryDate; }
            set { SetProperty(ref _OtherExpiryDate, value); }
        }
        private string _FrequentlyFood;
        public string FrequentlyFood
        {
            get { return _FrequentlyFood; }
            set { SetProperty(ref _FrequentlyFood, value); }
        }
        private string _OtherFrequentlyFood;
        public string OtherFrequentlyFood
        {
            get { return _OtherFrequentlyFood; }
            set { SetProperty(ref _OtherFrequentlyFood, value); }
        }

        private string _TimePeriodFood;
        public string TimePeriodFood
        {
            get { return _TimePeriodFood; }
            set { SetProperty(ref _TimePeriodFood, value); }
        }
        private string _OtherTimePeriodFood;
        public string OtherTimePeriodFood
        {
            get { return _OtherTimePeriodFood; }
            set { SetProperty(ref _OtherTimePeriodFood, value); }
        }
        #endregion
        //**********************User Data********************

        private string _Username;
        public string Username { get { return _Username; } set { SetProperty(ref _Username, value); } }
        private string _Password;
        public string Password { get { return _Password; } set { SetProperty(ref _Password, value); } }

        private string _FirstName;
        public string FirstName { get { return _FirstName; } set { SetProperty(ref _FirstName, value); } }

        private string _LastName;
        public string LastName { get { return _LastName; } set { SetProperty(ref _LastName, value); } }

        private string _Email;
        public string Email { get { return _Email; } set { SetProperty(ref _Email, value); } }
        private string _Location;
        public string Location { get { return _Location; } set { SetProperty(ref _Location, value); } }
        private string _PickUpTime;
        public string PickUpTime { get { return _PickUpTime; } set { SetProperty(ref _PickUpTime, value); } }



        public ICommand OnSupermarketCommand { private set; get; }
        //Instance with firebase "Database"
        FirebaseClient firebase;





        public SupermarketRegViewModel()
        {
            firebase = new FirebaseClient(AppConstant.URLData);
            OnSupermarketCommand = new Command(SupermarketRegiestration);
            UserDataCollection = new UserData();
        }

        private async void SupermarketRegiestration()
        {
            if (UserDataCollection != null)
            {
                UserDataCollection.UserType = 1;
                UserDataCollection.UserName = Username;
                UserDataCollection.Password = Password;
                UserDataCollection.FirstName = FirstName;
                UserDataCollection.LastName = LastName;
                UserDataCollection.Email = Email;
                UserDataCollection.Location = Location;
                UserDataCollection.PickUpTime = PickUpTime;
                UserDataCollection.SuperMarket = new SuperMarketModel
                {
                    NameOfBusiness = NameBusiness,
                    ContentName = ContentName,
                    EmailAddress = EmailAddress,
                    ContactNumber = ContactNumber,
                    Address = Address,
                    FoodBeCollectedFrom = new FoodFrom { IsSuperMarket = IsSuperMarket, OtherTypeMarket = OtherSupermarket },
                    FoodDescription = new FoodDescription { CannedFood = IsCannedFood, Dryfood = IsDryFood, FuritsFood = IsFruits, Vegetables = IsVegetables, OtherFoodCollection = IsOtherFoodType },
                    AverageFood = AverageFood,
                    EstimateExpiryFood = ExpiryDate + "," + OtherExpiryDate,
                    FrequentlyFood = FrequentlyFood + "," + OtherFrequentlyFood,
                    DuringDate = TimePeriodFood + "," + OtherTimePeriodFood
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
