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

                foreach (var evento in eventos)
                {
                    System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    evento.date = dtDateTime.AddSeconds(Convert.ToDouble(evento.start)).ToLocalTime();

                }

                return eventos;
            }
            else
            {
                throw new Exception("Eventos não encontrados!");
            }

        }
    }
}
