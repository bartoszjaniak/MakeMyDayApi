using MakeMyDayApi.Models;
using MakeMyDayApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMyDayApi.Services
{
    public static class AccountService
    {
        public static Account LoginWithGuid(string guid) => AccountRepositories.GetAccountByGuid(guid);

        public static Account LoginWithAccesData(AccesData accesData) => AccountRepositories.GetAccountByAccesData(accesData);

        public static Account CreateAccount(AccesData accesData) => AccountRepositories.CreateAccount(accesData);
    }
}