using MakeMyDayApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMyDayApi.Services
{
    public static class SesionAuthService
    {
        private static TokenList _tokenList = new TokenList();
        
        public static void AddUserToSesion(Account account)
        {           
            if (_tokenList.Contains(account.Guid))
            {
                _tokenList.RenowExpirationTime(account.Guid);
            }
            else
            {
                _tokenList.Add(account.Guid);
            }
        }

        public static bool CheckIfUserIsLoggedAndRenowExpirationTime(string token)
        {
            if (_tokenList.Contains(token))
            {
                _tokenList.RenowExpirationTime(token);
                return true;
            }

            return false;
        }

        public static int AcctualUserCount() => _tokenList.Count();
    }
}
