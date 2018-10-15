using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Web;

namespace WebServiceVoo3.Models
{
    public class DALSeguimento
    {
        public static List<Seguimento> ListarSeguimentos()
        {
            int n = 0;
            List<Seguimento> Seguimentos = new List<Seguimento>();
            
            XElement xml = XElement.Load("DesafioXML.xml");
            foreach (XElement x in xml.Elements().Elements("trajeto"))
            {
                foreach (XElement y in xml.Elements().Elements("viagem"))
                {
                    List<Tarifa> Tarifas = new List<Tarifa>();
                    foreach (XElement z in xml.Elements().Elements("tafifa"))
                    {
                        
                        if (z.Element("nome").Value == "LIGHT") 
                        {
                            Tarifa ta = new Tarifa()
                            {
                                Id = 1,
                                TarifaNome = x.Attributes("nome").ToString(),
                                Moeda = x.Attributes("moeda").ToString(),
                                Cambio = float.Parse(x.Attributes("cambio").ToString()),
                                ValorBase = float.Parse(x.Attributes("valorbase").ToString()),
                                Equiv = x.Attributes("equiv").ToString(),
                                ValorDesconto = float.Parse(x.Attributes("valordesconto").ToString()),
                                TaxaEmbarque = float.Parse(x.Attributes("taxa").ToString()),
                                NumeroDeBagagem = int.Parse(x.Attributes("bagage").ToString())
                            };
                            Tarifas.Add(ta);
                        };
                        if (z.Element("nome").Value == "PLUS")
                        {
                            Tarifa ta = new Tarifa()
                            {
                                Id = 2,
                                TarifaNome = x.Attributes("nome").ToString(),
                                Moeda = x.Attributes("moeda").ToString(),
                                Cambio = float.Parse(x.Attributes("cambio").ToString()),
                                ValorBase = float.Parse(x.Attributes("valorbase").ToString()),
                                Equiv = x.Attributes("equiv").ToString(),
                                ValorDesconto = float.Parse(x.Attributes("valordesconto").ToString()),
                                TaxaEmbarque = float.Parse(x.Attributes("taxa").ToString()),
                                NumeroDeBagagem = int.Parse(x.Attributes("bagage").ToString())
                            };
                            Tarifas.Add(ta);
                        }
                        
                    }

                    
                    Seguimento t = new Seguimento()
                    {
                        Id = n + 1,
                        Trajeto = x.Attributes("id").ToString() + x.Attributes("taj").ToString(),
                        Cia = x.Attributes("cia").ToString(),
                        NumeroVoo = int.Parse(x.Attributes("numerovoo").ToString()),
                        DataHoraSaida = DateTime.Parse(x.Attributes("datasaida").ToString() + x.Attributes("horasaida")),
                        DataHoraChegada = DateTime.Parse(x.Attributes("datachegada").ToString() + x.Attributes("horachegada")),
                    };
                    t.Tarifas = Tarifas;
                    Seguimentos.Add(t);
                    n = n + 1;
                }
            }
            return Seguimentos;

        }
        
    }
    public class DALSelecionaSegimentos
    {
        public static List<Seguimento> DALSelecionaSegimento(string origem, string destino)
        {
            List<Seguimento> Seguimentos = new List<Seguimento>();
            List<Trajeto> TrajetoEscolido = new List<Trajeto>();
            DALSeguimento dals = new DALSeguimento();
            var K = DALTrajeto.ListarTrajetos().Where(P => P.Origem == origem && P.Destino == destino);
            TrajetoEscolido = K.ToList<Trajeto>();
            Seguimentos = TrajetoEscolido.FirstOrDefault().Seguimentos;
            return Seguimentos;
        }
    }
    
}