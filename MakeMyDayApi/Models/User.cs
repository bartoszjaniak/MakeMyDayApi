using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MakeMyDayApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string InviteKey { get; set; }
              
       
    }
}