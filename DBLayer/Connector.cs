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

        public DataTable GetTable(string selectCommand)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var dataAdapter = new SqlDataAdapter(selectCommand, conn);
                var table = new DataTable
                {
                    Locale = System.Globalization.CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(table);
                return table;
            }
        }
    }
}
