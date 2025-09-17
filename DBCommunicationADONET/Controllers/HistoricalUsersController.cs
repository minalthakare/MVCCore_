using DBCommunicationADONET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DBCommunicationADONET.Controllers
{
    public class HistoricalUsersController : Controller
    {
        private readonly string _connectionString;

        public HistoricalUsersController(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("B25ADONETCOREDB");
        }
        public IActionResult Index()
        {
            List<Users> users = new List<Users>();

            // string cs = "server=.\\SQLEXPRESS;database=B25ADONETCOREDB;Integrated Security = true;encrypt=false;";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                string query = "select * from users where DeletedDate is not null";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Users user = new Users()
                        {
                            Id = (int)reader["id"],
                            Name = (string)reader["name"],
                            Email = (string)reader["email"],
                            Age = (reader["Age"] == DBNull.Value) ? null : (int?)reader["Age"],
                            DateOfBirth = (reader["DateOfBirth"] == DBNull.Value) ? null : (DateTime)reader["DateOfBirth"],
                            AddedDate = (reader["AddedDate"] == DBNull.Value) ? null : (DateTime)reader["AddedDate"],
                            Modifieddate = (reader["ModifiedDate"] == DBNull.Value) ? null : (DateTime)reader["ModifiedDate"],
                            DeletedDate = (reader["DeletedDate"] == DBNull.Value) ? null : (DateTime)reader["DeletedDate"]

                        };
                        users.Add(user);
                    }
                }

            }
       
            return View(users);
        }
    }
}
