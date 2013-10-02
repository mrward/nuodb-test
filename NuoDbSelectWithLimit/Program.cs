
using System;
using System.Data;
using System.Data.Common;

namespace NuoDbSelectWithLimit
{
    class Program
    {
        public static void Main(string[] args)
        {
            SelectRecentWinnersWithLimit_Fails();
            SelectRecentWinnersWithoutLimit_Success();
            SelectRecentWinnersWithLimitOnly_Success();
            
            Console.Write("Press any key to continue ...");
            Console.ReadKey(true);
        }
        
        static void SelectRecentWinnersWithLimit_Fails()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory("NuoDb.Data.Client");
            using (DbConnection cn = factory.CreateConnection())
            {
                DbConnectionStringBuilder builder = factory.CreateConnectionStringBuilder();
                builder["Server"] = "localhost";
                builder["User"] = "dba";
                builder["Password"] = "goalie";
                builder["Schema"] = "hockey";
                builder["Database"] = "test";
                
                cn.ConnectionString = builder.ConnectionString;
                cn.Open();
                
                DbCommand cmd = factory.CreateCommand();
                cmd.Connection = cn;
                cmd.CommandText = 
                    "SELECT id, game_name, amount, won_at, site_id FROM recent_winners " +
                    "WHERE site_id = ? AND amount >= ? " +
                    "ORDER BY won_at desc LIMIT ? ";
                
                DbParameter parameter = cmd.CreateParameter();
                parameter.DbType = DbType.Int32;
                parameter.Value = 1;
                cmd.Parameters.Add(parameter);
                
                parameter = cmd.CreateParameter();
                parameter.DbType = DbType.Decimal;
                parameter.Value = 5;
                cmd.Parameters.Add(parameter);
                
                parameter = cmd.CreateParameter();
                parameter.DbType = DbType.Int32;
                parameter.Value = 10;
                cmd.Parameters.Add(parameter);
                
                DbDataReader reader = cmd.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                }
                reader.Close();
                
                Console.WriteLine("SelectRecentWinnersWithLimit_Fails\r\n");
                Console.WriteLine("SQL: {0}", cmd.CommandText);
                Console.WriteLine("\r\n\tExpected 2 rows. Actual: {0}\r\n", count);
                Console.WriteLine("------------------------------------------");
            }
        }
        
        static void SelectRecentWinnersWithoutLimit_Success()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory("NuoDb.Data.Client");
            using (DbConnection cn = factory.CreateConnection())
            {
                DbConnectionStringBuilder builder = factory.CreateConnectionStringBuilder();
                builder["Server"] = "localhost";
                builder["User"] = "dba";
                builder["Password"] = "goalie";
                builder["Schema"] = "hockey";
                builder["Database"] = "test";
                
                cn.ConnectionString = builder.ConnectionString;
                cn.Open();
                
                DbCommand cmd = factory.CreateCommand();
                cmd.Connection = cn;
                cmd.CommandText = 
                    "SELECT id, game_name, amount, won_at, site_id FROM recent_winners " +
                    "WHERE site_id = ? AND amount >= ? " +
                    "ORDER BY won_at desc ";
                
                DbParameter parameter = cmd.CreateParameter();
                parameter.DbType = DbType.Int32;
                parameter.Value = 1;
                cmd.Parameters.Add(parameter);
                
                parameter = cmd.CreateParameter();
                parameter.DbType = DbType.Decimal;
                parameter.Value = 5;
                cmd.Parameters.Add(parameter);
                
                DbDataReader reader = cmd.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                }
                reader.Close();
                
                Console.WriteLine("SelectRecentWinnersWithoutLimit_Success\r\n");
                Console.WriteLine("SQL: {0}", cmd.CommandText);
                Console.WriteLine("\r\n\tExpected 2 rows. Actual: {0}\r\n", count);
                Console.WriteLine("------------------------------------------");
            }
        }
        
        static void SelectRecentWinnersWithLimitOnly_Success()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory("NuoDb.Data.Client");
            using (DbConnection cn = factory.CreateConnection())
            {
                DbConnectionStringBuilder builder = factory.CreateConnectionStringBuilder();
                builder["Server"] = "localhost";
                builder["User"] = "dba";
                builder["Password"] = "goalie";
                builder["Schema"] = "hockey";
                builder["Database"] = "test";
                
                cn.ConnectionString = builder.ConnectionString;
                cn.Open();
                
                DbCommand cmd = factory.CreateCommand();
                cmd.Connection = cn;
                cmd.CommandText = 
                    "SELECT id, game_name, amount, won_at, site_id FROM recent_winners " +
                    "ORDER BY won_at desc LIMIT ? ";
                
                DbParameter parameter = cmd.CreateParameter();
                parameter.DbType = DbType.Int32;
                parameter.Value = 10;
                cmd.Parameters.Add(parameter);
                
                DbDataReader reader = cmd.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                }
                reader.Close();
                
                Console.WriteLine("SelectRecentWinnersWithLimitOnly_Success\r\n");
                Console.WriteLine("SQL: {0}", cmd.CommandText);
                Console.WriteLine("\r\n\tExpected 2 rows. Actual: {0}\r\n", count);
                Console.WriteLine("------------------------------------------");
            }
        }
    }
}