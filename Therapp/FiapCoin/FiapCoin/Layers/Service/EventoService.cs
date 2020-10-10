using System;
using System.Collections.Generic;
using System.Net.Http;
using THERAPP.Model;
using Newtonsoft.Json;

namespace THERAPP.Layers.Service
{
    public class EventoService
    {
        public IList<Evento> Get()
        {
            var uri = String.Format("https://freetos.ml/api/getEvents/{0}", Global.Cliente.id);

            System.Net.Http.HttpClient client = new HttpClient();
            var resposta = client.GetAsync(uri).Result;

            if (resposta.IsSuccessStatusCode)
            {
                var resultado = resposta.Content.ReadAsStringAsync().Result;
                var eventos = JsonConvert.DeserializeObject<IList<Evento>>(resultado);
                return eventos;
            }
            else
            {
                throw new Exception("Eventos não encontrados!");
            }

        }
    }
}
