using System;
using System.Collections.Generic;
using System.Text;

namespace CharketApp.Model
{
    //Use this to get data from data base as model
    public class UserLogin
    {
        //Username
        public string UserName { get; set; }
       //Password
        public string Password { get; set; }
        //Type user suepermarket / household / charity
        public int UserType { get; set; }
    }
}
