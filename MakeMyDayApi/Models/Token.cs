using MakeMyDayApi.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMyDayApi.Models
{
    public class Token
    {
        public string Value { get; private set; }
        public DateTime DeadTime { get; private set; }

        
        public Token(string token)
        {
            Value = token;
            DeadTime = DateTime.Now.AddSeconds(SessionProperties.SessionTimeInSecound);
        }


        public bool IsOverdue()
        {
            if (DeadTime > DateTime.Now)
                return true;
            else
                return false;
        }

        public void RenowExpirationTime()
        {
            DeadTime = DateTime.Now.AddSeconds(SessionProperties.SessionTimeInSecound);
        }

        public override bool Equals(object obj)
        {
            return ((Token)obj).Value == Value;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Value.GetHashCode();
            hash = (hash * 7) + DeadTime.GetHashCode();
            return hash;
        }      
    }
}
