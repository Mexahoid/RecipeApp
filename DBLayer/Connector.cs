using System;
using System.Data;
using System.Data.SqlClient;

namespace DBLayer
{
    public class Connector
    {
        private readonly string connectionString;
        public Connector()
        {
            connectionString = Properties.Settings.Default.RecipeConnectionString;
        }
        public DataTable GetTable(string selectCommand)
        {
            try
            {
                var dataAdapter = new SqlDataAdapter(selectCommand, connectionString);


                var table = new DataTable
                {
                    Locale = System.Globalization.CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(table);
                return table;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
