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
        public string FoodBeCollectedFrom { get; set; }
        public string FoodDescription { get; set; }
        public string EstimateQualityFood { get; set; }
        public string FoodToDonate { get; set; }
        public string AcceptFromCharity { get; set; }
    }

    //Household Data
    public class HouseHoldModel
    {
        public string HouseholdOwner { get; set; }
        public string ContentName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string FoodBeCollectedFrom { get; set; }
        public string FoodDescription { get; set; }
        public string EstimateQualityFood { get; set; }
        public string ExpiryDateFood { get; set; }
        public string FoodToDonate { get; set; }
        public string AcceptFromCharity { get; set; }
    }

    //Charity Data
    public class CharityModel
    {
        public string OrginazationName { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddress2 { get; set; }
        public string ContactNumber { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string ContactEmailAddress { get; set; }
        public string IsCharity { get; set; }
        public string PresentEvidence { get; set; }
        public string DescriptionService { get; set; }
        public string PrimaryServicesUser { get; set; }

    }
}
