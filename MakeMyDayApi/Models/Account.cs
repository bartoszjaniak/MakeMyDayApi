﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMyDayApi.Models
{
    public class Account
    {
        public enum CreateStatus
        {
            OK,
            EXISTS,
            ERROR
        };

        public string Login { get; }
        public string Password { get; }
        public Guid Guid { get; }

        public Account(DataBase.Accounts account)
        {
            this.Login = account.Login;
            this.Password = account.Password.ToString();
            if(account.Guid != null) 
                this.Guid = Guid.Parse(account.Guid);
        }

        //public CreateStatus Account(string login, string password)
        //{
        //    Login = login;
        //    Password = password;
        //    SuperToken = GenerateSuperToken();

        //    return CreateStatus.OK;
        //}

        private string GenerateSuperToken()
        {
            return Guid.NewGuid().ToString();
        }

        public bool LoginValid()
        {
            //TODO: check in database if user is exists and check password
            if (this.Guid != null)
                return Services.DataServices.AccountServices.LoginWithGuid(this.Guid);

            return false;
        }

        
    }
}
