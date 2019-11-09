using CharketApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharketApp.Pages.Profiles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupermarketProfile : ContentPage
    {
        public SupermarketProfile(ViewModel.SupermarketRegViewModel supermarketVM)
        {
            InitializeComponent();
            this.BindingContext = supermarketVM;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DBFirebase dBFirebase = new DBFirebase();
            dBFirebase.OnUploadFile(cmaera);
        }
    }
}