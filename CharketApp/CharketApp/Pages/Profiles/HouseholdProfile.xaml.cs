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


    }
}