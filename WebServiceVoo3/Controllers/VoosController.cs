using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceVoo3.Models;

namespace WebServiceVoo3.Controllers
{
    public class VoosController : ApiController
    {
        public List<Trajeto> TrajetosExistentes()   
        {
            return DALTrajeto.ListarTrajetos();
        }

        public List<Seguimento> VoosParaTrajeto(string Origem, string Destino)
        {
            return DALSelecionaSegimentos.DALSelecionaSegimento(Origem, Destino);
        }


    }
}
