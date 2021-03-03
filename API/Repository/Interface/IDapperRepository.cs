using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IDapperRepository<Entity>
        where Entity : class     
    {
        Entity ExecSP(string spName, DynamicParameters parameters);
        IEnumerable<Entity> ExecSPList(string spName, DynamicParameters parameters);
    }
}

