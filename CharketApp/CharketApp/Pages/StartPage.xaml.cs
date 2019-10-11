using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharketApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        //List for save images from Android and IOS Files 
        ObservableCollection<FileImageSource> imageSources = new ObservableCollection<FileImageSource>();

        public StartPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Sign the name of image
            imageSources.Add("Carsoul1");
            //Sign the name of image
            imageSources.Add("Carsoul2");
            //Sign the name of image
            imageSources.Add("Carsoul3");
            //Sign the list on Carousel image for view 
            carouselImages.ItemsSource = imageSources;
            //Start from image number 0 on the list
            carouselImages.Position = 0;
        }

        private void ContinueHandler(object sender, EventArgs e)
        {
            //Check if the postion of list now is 2 as max or not
            if (carouselImages.Position == 2)
            {

                //Show the loading bar
                activityIndicator.IsVisible = true;
                activityIndicator.IsRunning = true;
                //Go to Next page "Login Page" 
                App.Current.MainPage = new NavigationPage(new LoginPage());
                //Hide the loading
                activityIndicator.IsVisible = false;
                activityIndicator.IsRunning = false;
            }
            else
            {
                //Go to next image from list 
                carouselImages.Position++;
            }
        }
    }
}