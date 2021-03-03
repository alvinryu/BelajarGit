using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class RoleAccountRepository : GeneralRepository<MyContext, RoleAccount, string>
    {
        public RoleAccountRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
