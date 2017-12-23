using System;
using System.Data;
using System.Data.SqlClient;

namespace DBLayer
{
    public static class Connector
    {
        private static readonly string _connectionString 
            = Properties.Settings.Default.RecipeConnectionString;
        private static readonly QueryFactory _qf = new QueryFactory();
        
        
        public static DataTable GetTable(QueryFactory.Queries query, params Tuple<string, string>[] tuples)
        {
            using (var conn = new SqlConnection(_connectionString))  //Заменяет трай кэтч
            {
                var cmd = new SqlCommand(_qf.GetQuery(query), conn);

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
