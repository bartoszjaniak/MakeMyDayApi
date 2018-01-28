using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMyDayApi.Services.DataServices
{
    public static class AccountServices
    {
        public static bool LoginWithGuid(Guid guid)
        {
            using(var db = new DataBase.DataConext())
            {
                return db.Accounts.Select(A => A.Guid == guid.ToString()).Count() > 0;
            }
        } 

    }
}