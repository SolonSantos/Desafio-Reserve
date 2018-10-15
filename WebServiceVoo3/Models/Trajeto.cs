using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceVoo3.Models
{
    public class Trajeto
    {
        public int Id { get; set; }
        public DateTime DataPartida { get; set; }
        public String Origem { get; set; }
        public String Destino { get; set; }
        public List<Seguimento> Seguimentos;
    }
}