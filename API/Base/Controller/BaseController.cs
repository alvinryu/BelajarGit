using API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace API.Base.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repository;
        public BaseController(Repository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult<Entity> Get()
        {
            var result = repository.Get();
            return (result != null) ? (ActionResult)Ok(new { status = HttpStatusCode.OK, messages = "Data Is Found!", data = result, }) : StatusCode(500, new { data = result, status = HttpStatusCode.InternalServerError, errorMessage = "Cannot get the data" });
        }
        [HttpPost]
        public ActionResult Post(Entity entity)
        {
            if (entity == null)
                return BadRequest(new { status = HttpStatusCode.BadRequest, errorMessage = "All input data need to be inserted" });
            var result = repository.Create(entity);
            return (result != 0) ? (ActionResult)Ok(new { status = HttpStatusCode.OK }) : StatusCode(500, new { status = HttpStatusCode.InternalServerError, errorMessage = "Failed to input the data" });
        }
        [HttpDelete("{key}")]
        public ActionResult Delete(Key key)
        {
            try
            {
                var result = repository.Delete(key);
                return (result != 0) ? (ActionResult)Ok(new { status = HttpStatusCode.OK }) : StatusCode(500, new { status = HttpStatusCode.InternalServerError });
            }
            catch
            {
                return NotFound("ID Not Found");
            }
        }
        [HttpPut]
        public ActionResult Put(Entity entity)
        {
            try
            {
                var result = repository.Update(entity);
                return Ok(new { status = HttpStatusCode.OK });
            }
            catch (Exception)
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, errorMessage = "Failed to input the data" });
            }
        }
        [HttpGet("{key}")]
        public ActionResult Get(Key key)
        {
            var result = repository.Get(key);
            return (result != null) ? (ActionResult)Ok(new { data = result, status = HttpStatusCode.OK }) : NotFound(new { data = result, status = HttpStatusCode.NotFound, errorMessage = "ID is not identified" });
        }
    }
}