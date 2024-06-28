using Dapper;
using Domain.Interface;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Infra.Repositories.Base
{
    public class BaseRepository : IBaseRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration["ConnectionStrings:SQLServer"];
        }

        public T QueryFirst<T>(string procedure, DynamicParameters parameters)
        {
            int commandTimeoutSeconds = 180;

            try
            {
                var command = new Dapper.CommandDefinition(procedure, parameters, commandTimeout: commandTimeoutSeconds, commandType: CommandType.StoredProcedure);
                return Dapper.SqlMapper.QueryFirst<T>(new SqlConnection(_connectionString), command);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<T> Query<T>(string procedure, DynamicParameters parameters)
        {
            int commandTimeoutSeconds = 180;

            try
            {
                var command = new Dapper.CommandDefinition(procedure, parameters, commandTimeout: commandTimeoutSeconds, commandType: CommandType.StoredProcedure);
                return Dapper.SqlMapper.Query<T>(new SqlConnection(_connectionString), command).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Execute(string procedure, DynamicParameters parameters)
        {
            int commandTimeoutSeconds = 180;

            try
            {
                var command = new Dapper.CommandDefinition(procedure, parameters, commandTimeout: commandTimeoutSeconds, commandType: CommandType.StoredProcedure);
                int result = Dapper.SqlMapper.Execute(new SqlConnection(_connectionString), command);
                return result.Equals(0) ? false : true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}