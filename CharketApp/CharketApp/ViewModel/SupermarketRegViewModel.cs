using CharketApp.Model;
using CharketApp.Services;
using Firebase.Database;
using System.Windows.Input;
using Xamarin.Forms;

namespace CharketApp.ViewModel
{
    public class SupermarketRegViewModel : BaseViewModel
    {
        private UserData _UserData;
        public UserData UserData
        {
            get { return _UserData; }
            set { SetProperty(ref _UserData, value); }
        }
        public ICommand OnSupermarketCommand { private set; get; }
        //Instance with firebase "Database"
        FirebaseClient firebase;
        public SupermarketRegViewModel()
        {
            firebase = new FirebaseClient(AppConstant.URLData);
            OnSupermarketCommand = new Command(SupermarketRegiestration);
        }

        private async void SupermarketRegiestration(object obj)
        {
            if (UserData != null)
            {
                UserData.UserType = 1;
            }
        }
    }
}
