﻿using CharketApp.Pages.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharketApp.Pages.Signup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupermarketRegistration : ContentPage
    {
        public SupermarketRegistration()
        {
            InitializeComponent();
        }

        private async void SupermarketSumitHandler(object sender, EventArgs e)
        {
        await    Navigation.PushAsync(new SupermarketProfile());
        }
    }
}