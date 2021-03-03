using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class PersonRepository : GeneralRepository<MyContext, Person, string>
    {
        public PersonRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}