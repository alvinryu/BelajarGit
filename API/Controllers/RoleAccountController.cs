using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Base.Controller;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleAccountController : BaseController<RoleAccount, RoleAccountRepository, string>
    {
        public RoleAccountController(RoleAccountRepository roleAccountRepository) : base(roleAccountRepository)
        {
        }
    }
}