using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WindowsFormsApp4.Models;

namespace WindowsFormsApp4.DAL
{
    internal class CountryRepository : SqlLiteBaseRepository
    {
        public CountryRepository()
        {
            if (!DatabaseExists())
            {
                CreateDatabase();
            }
        }
        public int InsertCountry (Country country)
        {
            string sql = "INSERT INTO Country (Code, Name) Values (@Code, @Name);";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, country);
            }
        }
    }
}
