using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;

namespace WindowsFormsApp4.DAL
{
    internal class SqlLiteBaseRepository
    {
        public SqlLiteBaseRepository()
        {
        }

        public static SqliteConnection DbConnectionFactory()
        {
            return new SqliteConnection(@"DataSource=CountryDB.sqlite");
        }

        protected static bool DatabaseExists()
        {
            return File.Exists(@"CountryDB.sqlite");
        }

        protected static void CreateDatabase()
        {
            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                connection.Execute(
                    @"CREATE TABLE Country
                    (
                    Id                         INTEGER PRIMARY KEY AUTOINCREMENT,
                    Code                       VARCHAR(2) UNIQUE,
                    Name                       VARCHAR(100)
                    )");
            }
        }
    }
}
