
using System.Data;
using Microsoft.Data.SqlClient;

namespace DBCommunicationADONET.Models
{
    public class CategoryService : ICategoryService
    {
        private readonly IDatabaseService _dbService;

        public CategoryService(IDatabaseService dbService)
        {
            _dbService = dbService;
        }

        public bool Create(Category category)
        {
            string command = "uspCreateCategory";
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter(){ParameterName = "@Name", Value = category.Name },
                    new SqlParameter(){ParameterName = "@Rating", Value = category.Rating },
            };
            int rows = _dbService.ExecuteNonQuery(command, parameters, System.Data.CommandType.StoredProcedure);

            return rows > 0;
        }

        public bool Delete(int id)
        {
            string command = "uspDeleteCategory";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(){ParameterName = "@Id", Value = id},
            };

            int rows = _dbService.ExecuteNonQuery(command, parameters, CommandType.StoredProcedure);

            return rows > 0;
        }

        public List<Category> GetAll()
        {
           return _dbService.ExecuteReader<Category>("uspGetAll", null);
        }

        public Category GetById(int id)
        {
            string command = "uspGetById";
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter(){ParameterName = "@Id", Value =id},
            };

            Category category =
                  _dbService.ExecuteReader<Category>(command, parameter, CommandType.StoredProcedure)?.FirstOrDefault();

            return category;
        }

        public bool Update(Category category)
        {
            string command = "uspUpdateCategory";
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter() { ParameterName = "@Id", Value = category.Id },
                    new SqlParameter() { ParameterName = "@Name", Value = category.Name },
                    new SqlParameter() { ParameterName = "@Rating", Value = category.Rating }
            };
            int rows = _dbService.ExecuteNonQuery(command, parameters, CommandType.StoredProcedure);

            return rows > 0;
        }
    }
}
