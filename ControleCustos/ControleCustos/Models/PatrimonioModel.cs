using ControleCustos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleCustos.Models
{
    public class PatrimonioModel : RecursoModel
    {
        public string Modelo { get; set; }

        public string Marca { get; set; }

        public PatrimonioModel(Patrimonio patrimonio)
            : base (patrimonio)
        {
            this.Modelo = patrimonio.Modelo;
            this.Marca = patrimonio.Marca;
        }
    }
}