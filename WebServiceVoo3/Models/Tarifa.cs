using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceVoo3.Models
{
    public class Tarifa
    {
        public int Id { get; set; }
        public String TarifaNome { get; set; }
        public String Moeda { get; set; } 
        public float Cambio { get; set; } 
        public float ValorBase { get; set; }
        public String Equiv { get; set; }
        public float ValorDesconto { get; set; } 
        public float TaxaEmbarque { get; set; }
        public int NumeroDeBagagem { get; set; }         
    }
}