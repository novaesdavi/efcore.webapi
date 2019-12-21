using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EFCore.Dominio;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        readonly HeroiContexto _contexto;

        public ValuesController(HeroiContexto heroiContexto)
        {
            _contexto = heroiContexto;
        }

        [HttpGet("filtro/{nome}")]
        public ActionResult Get(string nome)
        {
            var listaRetono = (from heroi in _contexto.Herois
                               where EF.Functions.Like(heroi.Nome,$"%{nome}%") // /  heroi.Nome.Contains(nome)
                               select heroi).Single();

            //var listaRetono = new List<Heroi>();

            //foreach (var item in _contexto.Herois)
            //{

            //    listaRetono.Add(item);
            //}





            return Ok(listaRetono);
        }



        [HttpGet("{nomeheroi}")]
        public ActionResult GetFiltro(string nomeheroi)
        {
            Heroi heroi = new Heroi();
            heroi = new Heroi() { Nome = nomeheroi };
            
            _contexto.Herois.Add(heroi);
            _contexto.SaveChanges();


            return Ok();
        }


        [HttpGet("Atualizar/{id}")]
        public ActionResult Atualizar(string id)
        {
            Heroi heroi = (from h in _contexto.Herois
                           where h.Id == Convert.ToInt32(id)
                           select h).FirstOrDefault();

            heroi.Nome = "Homem Aranha Atualizado";

            _contexto.SaveChanges();

            return Ok();
        }


        [HttpGet("Delete/{id}")]
        public ActionResult Delete(string id)
        {
            Heroi heroi = (from h in _contexto.Herois
                           where h.Id == Convert.ToInt32(id)
                           select h).FirstOrDefault();

            _contexto.Remove(heroi);

            _contexto.SaveChanges();

            return Ok();
        }


        [HttpGet("AddRange")]
        public ActionResult AddRange()
        {
            _contexto.Herois.AddRange(
                new Heroi() { Nome = "Hulk" },
                new Heroi() { Nome = "Mulher Maravilha" },
                new Heroi() { Nome = "Pantera Negra" },
                new Heroi() { Nome = "Homem Formiga" }
            );

            _contexto.SaveChanges();

            return Ok();
        }
    }
}
