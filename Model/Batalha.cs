using System;
using System.Collections.Generic;

namespace EFCore.WebApi.Model
{
    public class Batalha
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime InicioBatalha { get; set; }
        public DateTime  FimBatalha { get; set; }

        public List<HeroiBatalha> HeroisBatalhas { get; set; }
    }
}