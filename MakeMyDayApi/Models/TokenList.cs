using MakeMyDayApi.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MakeMyDayApi.Models
{
    public class TokenList
    {
        private List<Token> Tokens = new List<Token>();
        private bool CleanerIsRunning;

        public TokenList()
        {
            CleanerIsRunning = false;
        }

        public void Add(Token token)
        {
            Tokens.Add(token);
            RunCleaner();
        }

        public int Count()
        {
            return Tokens.Count();
        }

        public bool Contains(Token token)
        {
            return Tokens.Contains(token);
        }

        public bool Contains(string tokenString)
        {
            return Tokens.Exists(A => A.Value.ToString() == tokenString);
        }

        private void RunCleaner()
        {
            if (!CleanerIsRunning)
            {
                CleanerIsRunning = true;
                Task.Run(() =>
                {
                    ClearTokenListFromOldTokens();
                });
            }
        }

        private void ClearTokenListFromOldTokens()
        {
            while (CleanerIsRunning)
            {
                Tokens.RemoveAll(A => A.DeadTime < DateTime.Now);
                if (Tokens.Count > SessionProperties.MaximumUsers)
                    Tokens.OrderByDescending(A => A.DeadTime).ToList().RemoveRange(SessionProperties.MaximumUsers, 100);
                CleanerIsRunning = Tokens.Count > 0;
                Thread.Sleep(1000);
            }
        }


    }
}
