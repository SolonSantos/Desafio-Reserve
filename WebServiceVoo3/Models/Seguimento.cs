using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceVoo3.Models
{
    public class Seguimento

    {
       public int Id { get; set; }
       public string Trajeto { get; set; }    
       public string Cia { get; set; }
       public int NumeroVoo { get; set; }
       public DateTime DataHoraSaida { get; set; }
       public DateTime DataHoraChegada { get; set; }
       public List<Tarifa> Tarifas;
    }
}