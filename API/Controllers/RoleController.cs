using API.Base.Controller;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : BaseController<Role, RoleRepository, string>
    {
        public RoleController(RoleRepository roleRepository) : base(roleRepository)
        {

        }
    }
}