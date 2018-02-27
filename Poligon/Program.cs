using MakeMyDayApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poligon
{
    class Program
    {
        private static string connectionString = "data source=mssql4.webio.pl,2401;initial catalog=bjaniak_makemyday;persist security info=True;user id=bjaniak_makemyday;password=Qewasdzxc1!;multipleactiveresultsets=True;";


        static void Main(string[] args)
        {
            Account account = GetAccountByAccesData(new AccesData() { Login = "Bjaniak", Password = "12345" });

            Console.WriteLine($"{account.User.Id} {account.User.Name} {account.User.Lastname} {account.User.InviteKey}");
            Console.ReadKey();

        }

        public static Account GetAccountByAccesData(AccesData accesData)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT acc.Login, acc.Password, acc.Guid, p.ID, p.Name, p.Lastname, p.InviteKey FROM Accounts acc JOIN Persons p on p.ID = acc.Person WHERE acc.Login = @login AND acc.Password = @password", sqlCon);
                sqlCommand.Parameters.AddWithValue("@Login", accesData.Login);
                sqlCommand.Parameters.AddWithValue("@Password", accesData.Password);

                var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    return new Account()
                    {
                        Login = reader[0].ToString(),
                        Password = reader[1].ToString(),
                        Guid = reader[2].ToString(),
                        User = new User()
                        {
                            Id = int.Parse(reader[3].ToString()),
                            Name = reader[4].ToString(),
                            Lastname = reader[5].ToString(),
                            InviteKey = reader[6].ToString()
                        }
                    };
                }
            }
            return null;
        }

    }
}
