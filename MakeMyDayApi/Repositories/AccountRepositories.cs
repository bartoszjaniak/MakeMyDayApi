using MakeMyDayApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace MakeMyDayApi.Repositories
{
    public static class AccountRepositories
    {
        private static string connectionString = "data source=mssql4.webio.pl,2401;initial catalog=bjaniak_makemyday;persist security info=True;user id=bjaniak_makemyday;password=Qewasdzxc1!;multipleactiveresultsets=True;";
 

        public static Account GetAccountByGuid(string guid)
        {
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT acc.Login, acc.Password, acc.Guid, p.ID, p.Name, p.Lastname, p.InviteKey FROM Accounts acc JOIN Persons p on p.ID = acc.Person WHERE acc.Guid = @guid", sqlCon);
                    sqlCommand.Parameters.AddWithValue("@guid", guid);                    

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

        public static Account CreateAccount(Account account)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                account.User.InviteKey = RandomInviteKey();
                sqlCon.Open();
                string command = @"
                    INSERT INTO Persons (Name, Lastname, Invitekey)
                    OUTPUT Inserted.Id
                    VALUES (@name, @lastname, @invitekey);";
                
                SqlCommand sqlCommand = new SqlCommand(command, sqlCon);
                sqlCommand.Parameters.AddWithValue("@name", account.User.Name);
                sqlCommand.Parameters.AddWithValue("@lastname", account.User.Lastname);
                sqlCommand.Parameters.AddWithValue("@invitekey", account.User.InviteKey);

                var reader = sqlCommand.ExecuteReader();      
                while (reader.Read())
                {
                    account.User.Id = int.Parse(reader[0].ToString());                    
                }

                 command = @"
                    SET IDENTITY_INSERT Accounts ON;
                    INSERT INTO Accounts (Person, Guid, Login, Password) 
                    OUTPUT Inserted.Guid
                    VALUES (@personId, NEWID(), @login, @password);
                    SET IDENTITY_INSERT Accounts OFF";

                sqlCommand = new SqlCommand(command, sqlCon);
                sqlCommand.Parameters.AddWithValue("@personId", account.User.Id);     
                sqlCommand.Parameters.AddWithValue("@login", account.Login);
                sqlCommand.Parameters.AddWithValue("@password", account.Password);

                reader = sqlCommand.ExecuteReader();
               
                while (reader.Read())
                {
                    account.Guid = reader[0].ToString();
                }
            }
            return account;
        }

        private static string RandomInviteKey()
        {
            var rand = new Random();
            string result = "";
            for (int i = 0; i < 6; i++)
            {
                string letter = Encoding.ASCII.GetString(new byte[] { (byte)rand.Next(65, 91) });
                string number = rand.Next(10).ToString();
                var ifNumber = rand.Next(2);
                result += ifNumber == 1 ? number : letter;
            }
            return result;
        }
    }
}