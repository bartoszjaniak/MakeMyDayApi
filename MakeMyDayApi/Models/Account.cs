
namespace MakeMyDayApi.Models
{
    public class Account
    {      
        public string Login { get; set; }
        public string Password { get; set; }
        public string Guid { get; set;  }
        public User User { get; set; }

        public Account()
        {

        }

        public Account(string login, string password)
        {
            Login = login;
            Password = password;
            Guid = GenerateGuid();
        }

        public Account(string login, string password, string guid)
        {
            Login = login;
            Password = password;
            Guid = guid;
        }       

        private string GenerateGuid()
        {            
            return System.Guid.NewGuid() .ToString();
        } 
    }
}
