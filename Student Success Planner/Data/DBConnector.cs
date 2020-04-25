using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace Student_Success_Planner.Data
{
    public class DBConnector
    {
        public DataTable QueryDatabase(String Query)
        {
            DataTable dataTable = null;

            string connStr = "server=localhost;user=root;database=SuccessMapDatabase;port=3306;password=1234";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");

                //adapter automatically opens connection
                MySqlDataAdapter adapter = new MySqlDataAdapter(Query, conn);
                adapter.SelectCommand.CommandType = CommandType.Text;

                //Fill data table with result of query
                dataTable = new DataTable();
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");

            return dataTable;
        }

        public void QueryDatabaseModify(String Query)
        {
            string connStr = "server=localhost;user=root;database=SuccessMapDatabase;port=3306;password=1234";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = Query;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
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
