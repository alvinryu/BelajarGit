using API.Context;
using API.Models;

namespace API.Repository.Data
{
    public class RoleRepository : GeneralRepository<MyContext, Role, string>
    {
        public RoleRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}