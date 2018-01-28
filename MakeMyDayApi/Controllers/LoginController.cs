using MakeMyDayApi.Models;
using MakeMyDayApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        // POST: api/Login
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Login/5
        public string Put(int id, [FromBody]Account account)
        {
            var userValid = account.LoginValid();

            if (userValid)
                return $"Zalogowano, token: {SesionAuth.GetNewToken()}";
            else
                return "Błędne dane logowania";
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
