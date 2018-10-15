using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Web;

namespace WebServiceVoo3.Models
{
    public class DALTrajeto
    {
        public static List<Trajeto> ListarTrajetos()
        {
            int n = 0;
            List<Trajeto> Trajetos = new List<Trajeto>();
            XElement xml = XElement.Load("DesafioXML.xml");
            foreach (XElement x in xml.Elements().Elements("trajeto"))
            {
                Trajeto t = new Trajeto()
                {
                    Id = n + 1,
                    DataPartida = DateTime.Parse(x.Attributes("datapartida").ToString()),
                    Origem = x.Attributes("origem").ToString(),
                    Destino = x.Attributes("destino").ToString()
                };

                List < Seguimento > SeguimentosTrajeto  = new List<Seguimento>();
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


                    Seguimento st = new Seguimento()
                    {
                        Id = n + 1,
                        Trajeto = x.Attributes("id").ToString() + x.Attributes("taj").ToString(),
                        Cia = x.Attributes("cia").ToString(),
                        NumeroVoo = int.Parse(x.Attributes("numerovoo").ToString()),
                        DataHoraSaida = DateTime.Parse(x.Attributes("datasaida").ToString() + x.Attributes("horasaida")),
                        DataHoraChegada = DateTime.Parse(x.Attributes("datachegada").ToString() + x.Attributes("horachegada")),
                    };
                    st.Tarifas = Tarifas;
                    SeguimentosTrajeto.Add(st);
                    n = n + 1;
                }
                t.Seguimentos = SeguimentosTrajeto;
                Trajetos.Add(t);
                n = n + 1;
            }
            return Trajetos;
        }
    }
}