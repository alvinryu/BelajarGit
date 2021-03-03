using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var data = repository.Get();

            if (data != null)
            {
                return Ok(new { status = HttpStatusCode.OK, data, message = "Data Ditemukan" });
            }
            else
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, data, message = "Terjadi Kesalahan" });
            }
        }

        [HttpGet("{key}")]
        public ActionResult<Entity> Get(Key key)
        {
            var data = repository.Get(key);

            if (data != null)
            {
                return Ok(new { status = HttpStatusCode.OK, data, message = "Data Ditemukan" });
            }
            else
            {
                return NotFound(new { status = HttpStatusCode.NotFound, message = "Data Tidak Ditemukan" });
            }
        }

        [HttpPost]
        public ActionResult<Entity> Create(Entity entity)
        {
            var data = repository.Create(entity);

            if (data != 0)
            {
                return Ok(new { status = HttpStatusCode.OK, data, message = "Berhasil Membuat Data Baru" });
            }
            else
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Gagal Membuat Data Baru" });
            }
        }

        [HttpPut]
        public ActionResult<Entity> Update(Entity entity)
        {
            if (entity == null)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data Yang Di-Input Salah / Tidak Lengkap" });
            }

            var data = repository.Update(entity);

            if (data != 0)
            {
                return Ok(new { status = HttpStatusCode.OK, data, message = "Berhasil Update Data" });
            }
            else
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Gagal Update Data" });
            }
        }

        [HttpDelete("{key}")]
        public ActionResult<Entity> Delete(Key key)
        {
            var data = repository.Delete(key);

            return (data != 0) ? Ok(new { status = HttpStatusCode.OK, message = "Berhasil Delete Data" }) :
                StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Gagal Delete Data" });
        }
    }
}