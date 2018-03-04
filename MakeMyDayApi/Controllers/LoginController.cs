using MakeMyDayApi.Models;
using MakeMyDayApi.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace MakeMyDayApi.Controllers
{
    public class LoginController : ApiController
    {

        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }

        public string Login(string accesData)
        {
            return accesData;
        }


        public Account Login([FromBody]Account loginData)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(loginData.Login) && !string.IsNullOrEmpty(loginData.Password)) {
                    var account = AccountService.GetAccountByAccesData(new AccesData() { Login = loginData.Login, Password = loginData.Password });
                    if (account != null)
                    {
                        SesionAuthService.AddUserToSesion(account);
                        return account;                        
                    }
                }

                if (loginData.Guid != null)
                {
                    var account = AccountService.GetAccountByGuid(loginData.Guid);
                    if (account != null)
                    {
                        SesionAuthService.AddUserToSesion(account);
                        return account;
                    }
                }
            }
            return null;
        }

        public Account CreateAccount([FromBody]Account account)
        {
            try
            {
                Account newAccount = AccountService.CreateAccount(account);
                return newAccount;
            }
            catch(System.Data.SqlClient.SqlException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
      
        // PUT: api/Login/5
        public void Put(int id, [FromBody]string accountS)
        {
           
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
