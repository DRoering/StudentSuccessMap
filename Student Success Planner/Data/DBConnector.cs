using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace Student_Success_Planner.Data
{
    public class DBConnector
    {
        public IEnumerable<IDataRecord> QueryDatabase(String Query)
        {
            List<MySqlDataReader> readerList = new List<MySqlDataReader>();

            string connStr = "server=localhost;user=root;database=SMDatabase;port=3306;password=1234";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = Query;
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        readerList.Add(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");

            return readerList;
        }

        public void QueryDatabaseAdd(String Query)
        {
            List<MySqlDataReader> readerList = new List<MySqlDataReader>();

            string connStr = "server=localhost;user=root;database=SMDatabase;port=3306;password=1234";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = Query;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");

        }
    }
}
