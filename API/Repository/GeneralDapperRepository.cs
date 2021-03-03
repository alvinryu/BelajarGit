using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class GeneralDapperRepository<Entity> : IDapperRepository<Entity>
         where Entity : class
    {
        private readonly IConfiguration _config;
        private readonly IDbConnection _connection;

        public GeneralDapperRepository(IConfiguration config) 
        {
            _config = config; 
            _connection = new SqlConnection(_config.GetConnectionString("MyContext"));
        }

        public Entity ExecSP(string spName, DynamicParameters parameters = null)
        {
            return _connection.Query<Entity>(spName, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public IEnumerable<Entity> ExecSPList(string spName, DynamicParameters parameters = null)
        {
            return _connection.Query<Entity>(spName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
