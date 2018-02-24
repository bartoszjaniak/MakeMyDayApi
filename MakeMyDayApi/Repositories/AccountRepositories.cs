using MakeMyDayApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMyDayApi.Repositories
{
    public static class AccountRepositories
    {
        public static Account GetAccountByGuid(Guid guid)
        {
            using (var db = new DataBase.bjaniak_makemydayEntities())
            {
                return new Account(db.Accounts.Where(A => A.Guid.Equals(guid)).Select(A => A).FirstOrDefault());
            }
        }

        public static Account GetAccountByAccesData(AccesData accesData)
        {
            using (var db = new DataBase.bjaniak_makemydayEntities())
            {
                var dbAccount = db.Accounts.Where(A => A.Login.Equals(accesData.Login) && A.Password.Equals(accesData.Password)).Select(A => A).FirstOrDefault();
                if(dbAccount != null)
                    return new Account(dbAccount);
                else
                    return null;
            }
        }

        public static Account CreateAccount(AccesData accesData)
        {
            using (var db = new DataBase.bjaniak_makemydayEntities())
            {
          
                if (!db.Accounts.Where(A => A.Login.Equals(accesData.Login)).Any())
                {
                    Account account;                    
                    {
                        account = new Account(accesData.Login, accesData.Password);
                    } while (!db.Accounts.Where(A => A.Guid.Equals(account.Guid.ToString())).Any())

                    db.Accounts.Add(new DataBase.Accounts() { Login = account.Login, Password = account.Password, Guid = account.Guid.ToString() });
                    db.SaveChanges();
                    return account;
                }
                else
                    throw new Exception("Nazwa zajęta");
            }
        }
    }
}