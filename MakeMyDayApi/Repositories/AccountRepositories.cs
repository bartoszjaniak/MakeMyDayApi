using MakeMyDayApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MakeMyDayApi.Repositories
{
    public static class AccountRepositories
    {
        private static string connectionString = "data source=mssql4.webio.pl,2401;initial catalog=bjaniak_makemyday;persist security info=True;user id=bjaniak_makemyday;password=Qewasdzxc1!;multipleactiveresultsets=True;";
 

        public static Account GetAccountByGuid(string guid)
        {
            throw new NotImplementedException();
        }

        public static void Test()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT Login FROM Accounts", sqlCon);

                var reader = sqlCommand.ExecuteReader();

                List<string> usery = new List<string>();
                while (reader.Read())
                {
                    usery.Add(reader[0].ToString());
                }
            }             

        }

        public static Account GetAccountByAccesData(AccesData accesData)
        {
            throw new NotImplementedException();
        }

        public static Account CreateAccount(AccesData accesData)
        {
            throw new NotImplementedException();
        }
    }
}