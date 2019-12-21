using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Dominio;
using EFCore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {

       private readonly HeroiContexto _context;

        public HeroiController(HeroiContexto context)
        {
            _context = context;
        }
        // GET: api/Heroi
        [HttpGet]
        public ActionResult Get()
        {

            try
            {
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // GET: api/Heroi/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST: api/Heroi
        [HttpPost]
        public ActionResult Post()
        {
            try
            {
                var heroi = new Heroi() { 
                Nome = "Homem de Ferro",
                Armas = new List<Arma>(){ 
                    new Arma() { Nome = "Mark 03" } ,
                    new Arma() { Nome = "Mark 05" } 
                }
                };

                _context.Herois.Add(heroi);
                _context.SaveChanges();

                return Ok("BAZINGA");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Heroi/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Heroi value)
        {
            try
            {

                _context.Herois.AsNoTracking().FirstOrDefault(h => h.Id == Convert.ToInt32(id));
                //var heroi = (from h in _context.Herois
                //             where h.Id == Convert.ToInt32(id) select h).FirstOrDefault();


                //armas = value.Armas;

                _context.Update(value);

                _context.SaveChanges();

                return Ok("BAZINGA");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        private void AtualizaCampo(string valorCampo, string valorNovo)
        {
            valorCampo = valorNovo;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
