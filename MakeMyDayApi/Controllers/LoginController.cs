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


        public string Login([FromBody]Account account)
        {
            if (ModelState.IsValid)
            {
                if(!string.IsNullOrEmpty(account.Login) && !string.IsNullOrEmpty(account.Password))
                    if (AccountService.LoginWithAccesData(new AccesData() { Login = account.Login, Password = account.Password }) != null)
                        return $"Zalogowano, token: {SesionAuthService.GetNewToken()}";

                if (account.Guid != null)
                    if (AccountService.LoginWithGuid(account.Guid) != null)
                        return $"Zalogowano, token: {SesionAuthService.GetNewToken()}";
            }
            return "Błędne dane logowania";
        }

        public string CreateAccount([FromBody]AccesData accesData)
        {
            try
            {
                Account account = AccountService.CreateAccount(accesData);
                return account.Guid.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
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
