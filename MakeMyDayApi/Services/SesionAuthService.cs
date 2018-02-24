using MakeMyDayApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMyDayApi.Services
{
    public static class SesionAuthService
    {
        private static TokenList TokenList = new TokenList();

        public static Token GetNewToken()
        {
            return GenerateTokenAndCleerTokenList();
        }

        public static bool CheckTokenValidAndReneweExpirationTime(Token token)
        {
            if (TokenList.Contains(token))
            {
                RenowExpirationTime(token);
                return true;
            }
            return false;
        }



        public static int AcctualUserCount()
        {
            return TokenList.Count();
            //return CleanerIsRunning ? 1 : 0;
        }

        private static Token GenerateTokenAndCleerTokenList()
        {
            Token generatedToken;

            do
            {
                generatedToken = new Token();
            } while (TokenList.Contains(generatedToken));

            AddNewTokenToTokenList(generatedToken);

            return generatedToken;
        }

        private static void AddNewTokenToTokenList(Token token)
        {
            TokenList.Add(token);
        }

        private static void RenowExpirationTime(Token token)
        {
            token.RenowExpirationTime();
        }


    }
}
