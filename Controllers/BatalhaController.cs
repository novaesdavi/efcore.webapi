using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Dominio;
using EFCore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : ControllerBase
    {
        private readonly HeroiContexto _context;
        public BatalhaController(HeroiContexto context)
        {
            _context = context;
        }
        // GET: api/Batalha
        [HttpGet]
        public ActionResult GetBatalhas()
        {
            return Ok(_context.Batalhas);
        }

        // GET: api/Batalha/5
        [HttpGet("{id}")]
        public ActionResult GetBatalha(int id)
        {
            var batalhas = (from b in _context.Batalhas
                            where b.Id == id
                            select b).ToList();

            return Ok(batalhas);
        }

        // POST: api/Batalha
        [HttpPost]
        public void Post(Batalha value)
        {
            _context.Batalhas.Add(value);

            _context.SaveChanges();

            Ok();

        }

        // PUT: api/Batalha/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Batalha value)
        {

            if ((from b in _context.Batalhas where b.Id == id select b).Any())
            {
                _context.Update(value);

                _context.SaveChanges();

                return Ok();
            }
            else {
                return BadRequest("Batalha não localizada");
            }



        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
