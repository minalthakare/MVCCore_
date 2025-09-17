using System.Data;
using Microsoft.Data.SqlClient;

namespace DBCommunicationADONET.Models
{
    public interface IDatabaseService
    {
        int ExecuteNonQuery(string command,  SqlParameter[] parameters,
            CommandType commandType = CommandType.Text);

        List<T> ExecuteReader<T>(string command,  SqlParameter[] parameters,
             CommandType commandType = CommandType.Text) where T : new();


    }
}
