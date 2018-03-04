using MakeMyDayApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MakeMyDayApi.Controllers
{
    public class DoSomethingController : ApiController
    {
        // GET: api/DoSomething
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DoSomething/5
        public string Get(string id)
        {
            //if (SesionAuthService.CheckTokenValidAndReneweExpirationTime(new Models.Token(id)))
            //    return $"Aktualna liczba użytkowników: {SesionAuthService.AcctualUserCount()}";
            //else
                return "Nie zalogowano";
        }

        public string DoSomething([FromBody]string token)
        {
            //if (SesionAuthService.CheckIfUserIsLoggedAndRenowExpirationTime(token))
            //{
            //    return $"Jesteś zalogowany wśród {SesionAuthService.AcctualUserCount()} użytkowników";
            //}
            //else
                return "Nie jesteś zalogowany";

        }


            // POST: api/DoSomething
            public void Post([FromBody]string value)
        {
        }

        // PUT: api/DoSomething/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DoSomething/5
        public void Delete(int id)
        {
        }
    }
}
