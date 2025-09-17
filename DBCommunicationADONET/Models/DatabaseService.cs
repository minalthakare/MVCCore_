using System.Data;
using System.Reflection;
using Microsoft.Data.SqlClient;

namespace DBCommunicationADONET.Models
{
    public class DatabaseService : IDatabaseService
    {
        private readonly String _connectionString;

        public DatabaseService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("B25ADONETCOREDB");
        }
    
        public int ExecuteNonQuery(string command,  SqlParameter[] parameters,
            CommandType commandType = CommandType.Text)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {

               
                SqlCommand cmd = new SqlCommand(command, con);

                cmd.CommandType = commandType;

                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());  
                }

                con.Open();

              return cmd.ExecuteNonQuery();

              
            }
        }

        public List<T> ExecuteReader<T>(string command,  SqlParameter[] parameters,
             CommandType commandType = CommandType.Text) where T : new() 
        {
            var resultList = new List<T>();
            // string cs = "server=.\\SQLEXPRESS;database=B25ADONETCOREDB;Integrated Security = true;encrypt=false;";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {

              
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.CommandType = commandType;

                if (parameters != null)
                    cmd.Parameters.AddRange(parameters.ToArray());

                    con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

               var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                while (reader.Read())
                {
                    T obj = new();

                    foreach(var prop in props)
                    {
                        if ( reader[prop.Name] is DBNull)
                            continue;

                        var value = reader[prop.Name];
                        //prop.SetValue(obj, Convert.ChangeType(value, prop.PropertyType));
                        prop.SetValue(obj, value);
                    }
                    resultList.Add(obj);
                }

                return resultList;

            }
        }
    }
}
