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
    public partial class CharityPage : ContentPage
    {
        public CharityPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var item = (UserData)e.Item;
                Navigation.PushAsync(new SuperMarketDetilasPage(item));
            }
        }

        private void SearchBarHandler(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                CharityListView.ItemsSource = Charity.UserCollcetion;
            else
                CharityListView.ItemsSource = Charity.UserCollcetion.Where(i => i.UserName.ToLower().Contains(e.NewTextValue.ToLower()));

        }

    }
}