using CharketApp.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharketApp.Pages.Profiles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HouseholdProfile : ContentPage
    {
        public HouseholdProfile(ViewModel.SignupViewModel.HouseHoldRegViewModel houseViewModel)
        {
            InitializeComponent();
            this.BindingContext = houseViewModel;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DBFirebase dBFirebase = new DBFirebase();
            dBFirebase.OnUploadFile(cmaera);
        }
    }
}