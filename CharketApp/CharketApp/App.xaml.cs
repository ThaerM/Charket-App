using CharketApp.Pages;
using Com.OneSignal;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharketApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            Device.SetFlags(new[] { "CarouselView_Experimental", "IndicatorView_Experimental", "SwipeView_Experimental" });
            MainPage = new StartPage();
#if !DEBUG
            if (Device.OS != TargetPlatform.iOS)
            OneSignal.Current.StartInit("f560a128-8312-4937-bbe2-9aba86e2b640")
                            .EndInit();
#endif
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
