using System;
using System.Collections.Generic;
using System.Text;

namespace CharketApp.Model
{
    //Use this to get data from data base as model
    public class UserData
    {
        //Username
        public string UserName { get; set; }
        //Password
        public string Password { get; set; }
        //Type user 1=suepermarket / 2=household / 3=charity
        public int UserType { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string PickUpTime { get; set; }
        public string ImageName { get; set; }

        public SuperMarketModel SuperMarket { get; set; }
        public HouseHoldModel HouseHoldModel { get; set; }
        public CharityModel CharityModel { get; set; }
    }

    //SuperMarket Data
    public class SuperMarketModel
    {
        public string NameOfBusiness { get; set; }
        public string ContentName { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public FoodFrom FoodBeCollectedFrom { get; set; }
        public FoodDescription FoodDescription { get; set; }
        public string AverageFood { get; set; }
        public string EstimateExpiryFood { get; set; }
        public string FrequentlyFood { get; set; }
        public string DuringDate { get; set; }

    }

    public class FoodFrom
    {
        public bool IsSuperMarket { get; set; }
        public string OtherTypeMarket { get; set; }
    }
    public class FoodDescription
    {
        public bool CannedFood { get; set; }
        public bool Dryfood { get; set; }
        public bool FuritsFood { get; set; }
        public bool Vegetables { get; set; }
        public string OtherFoodCollection { get; set; }
    }
    //Household Data
    public class HouseHoldModel
    {
        public string ContentName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public FoodFromHouse FoodBeCollectedFrom { get; set; }
        public FoodDescription FoodDescription { get; set; }
        public string AverageFood { get; set; }
        public string EstimateExpiryFood { get; set; }
        public string FrequentlyFood { get; set; }
        public string DuringDate { get; set; }
    }
    public class FoodFromHouse
    {
        public bool IsHouse { get; set; }
        public string OtherTypeHouse { get; set; }
    }


    //Charity Data
    public class CharityModel
    {
        public string OrginazationName { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddress2 { get; set; }
        public string PostalCode { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string ContactEmailAddress { get; set; }
        public FoodFromCharity DescriptionService { get; set; }
        public FoodDonationCharity foodDonationCharity { get; set; }
    }
    public class FoodDonationCharity
    {
        public bool isFoodDontationCharity { get; set; }
        public string IsOtherFoodDontationCharit { get; set; }
    }
    public class FoodFromCharity
    {
        public bool isCharity { get; set; }
        public string OtherTypeCharity { get; set; }
    }
}
