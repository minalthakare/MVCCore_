
using System.Reflection;
using System.Xml;
using DBCommunicationADONET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DBCommunicationADONET.Models
{
    public class UserService : IUserService
    {

        private readonly string _connectionString;

        private readonly IDatabaseService _dbService;

        public UserService(IConfiguration config, IDatabaseService dbService)
        {
            _connectionString = config.GetConnectionString("B25ADONETCOREDB");
            _dbService = dbService;
        }
        public bool Create(Users model)
        {
            #region end code
            //// string cs = "server=.\\SQLEXPRESS;database=B25ADONETCOREDB;Integrated Security = true;encrypt=false;";
            //using (SqlConnection con = new SqlConnection(_connectionString))
            //{
            //    string query =
            //                          //$"insert into users values ('{model.Name}','{model.Email}',{model.Age}," +
            //                          //$" '{model.DateOfBirth}', '{DateTime.Now}',null,null)";
            //                          $"insert into users values ('{model.Name}', '{model.Email}', {model.Age}," +
            //        $"'{model.DateOfBirth}', '{DateTime.Now}', null, null)";



            //    SqlCommand cmd = new SqlCommand(query, con);

            //    con.Open();

            //    int rows = cmd.ExecuteNonQuery();

            //    return rows > 0;
            //}


            // string query =
            //$"insert into users values ('{model.Name}', '{model.Email}', {model.Age}," +
            //      $"'{model.DateOfBirth}', '{DateTime.Now}', null, null)";

            #endregion end code

            string query =
                $"insert into users values (@Name,@Email,@Age," +
                $"@DateOfBirth,@AddedDate,@Modifieddate,@DeletedDate)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(){ParameterName="@Name", Value=model.Name},
                 new SqlParameter(){ParameterName="@Email", Value=model.Email},
                  new SqlParameter(){ParameterName="@Age", Value=model.Age},
                   new SqlParameter(){ParameterName="@DateOfBirth", Value=model.DateOfBirth},
                    new SqlParameter(){ParameterName="@AddedDate", Value=model.AddedDate},
                     new SqlParameter(){ParameterName="@Modifieddate", Value=DBNull.Value},
                      new SqlParameter(){ParameterName="@DeletedDate", Value=DBNull.Value}
            };

            int rows = _dbService.ExecuteNonQuery(query, parameters);

            return rows > 0;

        }

        public bool Delete(int id)
        {
            #region end code
            //using (SqlConnection con = new SqlConnection(_connectionString))
            //{
            //    string query = $"update Users set DeletedDate = '{DateTime.Now}' where Id = {id}";

            //    SqlCommand command = new SqlCommand(query, con);

            //    con.Open();

            //    int rows = command.ExecuteNonQuery();

            //    return rows > 0;


            //}
            #endregion end code

            string query = $"update Users set DeletedDate = @DeletedDate where Id = @Id";

            SqlParameter[] parameters = new SqlParameter[]
         {
                 new SqlParameter(){ParameterName="@Id", Value=id},
                     new SqlParameter(){ParameterName="@DeletedDate", Value=DateTime.Now}
         };

            int rows = _dbService.ExecuteNonQuery(query, parameters);

            return rows > 0;
        }
        

        public List<Users> GetAll()
        {
            #region end code
            //List<Users> users = new List<Users>();

            //// string cs = "server=.\\SQLEXPRESS;database=B25ADONETCOREDB;Integrated Security = true;encrypt=false;";
            //using (SqlConnection con = new SqlConnection(_connectionString))
            //{

            //    string query = "select * from users where DeletedDate is null";
            //    SqlCommand cmd = new SqlCommand(query, con);

            //    con.Open();

            //    SqlDataReader reader = cmd.ExecuteReader();

            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            Users user = new Users()
            //            {
            //                Id = (int)reader["id"],
            //                Name = (string)reader["name"],
            //                Email = (string)reader["email"],
            //                Age = (reader["Age"] == DBNull.Value) ? null : (int?)reader["Age"],
            //                DateOfBirth = (reader["DateOfBirth"] == DBNull.Value) ? null : (DateTime)reader["DateOfBirth"],
            //                AddedDate = (reader["AddedDate"] == DBNull.Value) ? null : (DateTime)reader["AddedDate"],
            //                Modifieddate = (reader["ModifiedDate"] == DBNull.Value) ? null : (DateTime)reader["ModifiedDate"],
            //                DeletedDate = (reader["DeletedDate"] == DBNull.Value) ? null : (DateTime)reader["DeletedDate"]

            //            };
            //            users.Add(user);
            //        }
            //    }

            //}

            #endregion end code

            string command = "select * from users";

            List<Users> users = _dbService.ExecuteReader<Users>(command, null);


            return users;
        }

        public Users GetById(int id)
        {
            #region end code
            //Users user = new Users();

            ////string cs = "server=.\\SQLEXPRESS;database=B25ADONETCOREDB;Integrated Security = true;encrypt=false;";
            //using (SqlConnection con = new SqlConnection(_connectionString))
            //{

            //    string query = $"select * from users where Id = {id}";
            //    SqlCommand cmd = new SqlCommand(query, con);

            //    con.Open();

            //    SqlDataReader reader = cmd.ExecuteReader();

            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            user = new Users()
            //            {
            //                Id = (int)reader["id"],
            //                Name = (string)reader["name"],
            //                Email = (string)reader["email"],
            //                Age = (reader["Age"] == DBNull.Value) ? null : (int?)reader["Age"],
            //                DateOfBirth = (reader["DateOfBirth"] == DBNull.Value) ? null : (DateTime)reader["DateOfBirth"],
            //                AddedDate = (reader["AddedDate"] == DBNull.Value) ? null : (DateTime)reader["AddedDate"],
            //                Modifieddate = (reader["ModifiedDate"] == DBNull.Value) ? null : (DateTime)reader["ModifiedDate"],
            //                DeletedDate = (reader["DeletedDate"] == DBNull.Value) ? null : (DateTime)reader["DeletedDate"]

            //            };
            //            break;
            //        }
            //    }

            //  return user;

            #endregion end code


            string command = "select * from users where Id = @Id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(){ParameterName = "@Id", Value=id},
            };

            List<Users> users = _dbService.ExecuteReader<Users>(command, parameters);

            return users?.FirstOrDefault();

        }

        public bool Update(Users user)
        {
            #region end code
            //using (SqlConnection con = new SqlConnection(_connectionString))
            //{

            //    string cmdText = $"update users set Name = '{user.Name}',Email='{user.Email}'," +
            //        $"Age={user.Age},DateOfBirth = '{user.DateOfBirth}',ModifiedDate = '{DateTime.Now}' where Id = {user.Id}";

            //    SqlCommand cmd = new SqlCommand(cmdText, con);

            //    con.Open();

            //    int rows = cmd.ExecuteNonQuery();

            //    return rows > 0;
            //}

            #endregion end code

            string cmdText = $"update users set Name = @Name,Email=@Email," +
                   $"Age=@Age,DateOfBirth = @DateOfBirth,ModifiedDate = @Modifieddate where Id = @Id";


            SqlParameter[] parameters = new SqlParameter[]
           {
                 new SqlParameter(){ParameterName="@Id", Value=user.Id},
                new SqlParameter(){ParameterName="@Name", Value=user.Name},
                 new SqlParameter(){ParameterName="@Email", Value=user.Email},
                  new SqlParameter(){ParameterName="@Age", Value=user.Age},
                   new SqlParameter(){ParameterName="@DateOfBirth", Value=user.DateOfBirth},
                     new SqlParameter(){ParameterName="@Modifieddate", Value=DateTime.Now}
           };

            int rows = _dbService.ExecuteNonQuery(cmdText, parameters);

            return rows > 0;
        }
    }
}
