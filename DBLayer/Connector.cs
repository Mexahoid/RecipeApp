using System;
using System.Data;
using System.Data.SqlClient;

namespace DBLayer
{
    public class Connector
    {
        private readonly string _connectionString;
        public Connector()
        {
            _connectionString = Properties.Settings.Default.RecipeConnectionString;
        }
        

        public DataTable GetTable(string selectCommand, params Tuple<string, string>[] tuples)
        {
            using (var conn = new SqlConnection(_connectionString))  //Заменяет трай кэтч
            {
                var cmd = new SqlCommand(selectCommand, conn);

                foreach (var tuple in tuples)
                {
                    cmd.Parameters.AddWithValue(tuple.Item1, tuple.Item2);
                }
                
                try
                {
                    conn.Open();
                    SqlDataReader rd = cmd.ExecuteReader();

                    var table = new DataTable
                    {
                        Locale = System.Globalization.CultureInfo.InvariantCulture
                    };
                    table.Load(rd);
                    return table;

                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
