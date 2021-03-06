﻿using CharketApp.Model;
using CharketApp.Pages.DetailsPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharketApp.Pages.HomePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Household : ContentPage
    {
        public Household()
        {
            InitializeComponent();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var item = (UserData)e.Item;
                Navigation.PushAsync(new HouseHoldDetailsPage(item));
            }
        }

        private void SearchBarHandler(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                HouseholdListView.ItemsSource = HouseHold.UserCollcetion;
            else
                HouseholdListView.ItemsSource = HouseHold.UserCollcetion.Where(i => i.UserName.ToLower().Contains(e.NewTextValue.ToLower()));
        }
    }
}