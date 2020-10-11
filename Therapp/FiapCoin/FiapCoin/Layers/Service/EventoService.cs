using System;
using System.Collections.Generic;
using System.Net.Http;
using THERAPP.Model;
using Newtonsoft.Json;
using System.Text;

namespace THERAPP.Layers.Service
{
    public class EventoService
    {
        string message = string.Empty;
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

                    evento.dateText = evento.date.ToString("dd/MM/yyyy hh:mm");
                }

                return eventos;
            }
            else
            {
                throw new Exception("Eventos não encontrados!");
            }

        }

        public Boolean newEvent(Evento newEvento)
        {
            var uri = String.Format("https://freetos.ml/api/newEvent/{0}", Global.Cliente.id);

            var conteudoJson = Newtonsoft.Json.JsonConvert.SerializeObject(newEvento);
            var conteudoJsonString = new StringContent(conteudoJson, Encoding.UTF8, "application/json");

            System.Net.Http.HttpClient client = new HttpClient();
            HttpResponseMessage resposta = client.PostAsync(uri, conteudoJsonString).Result;

            if (resposta.IsSuccessStatusCode)
            {
                try { 
                    var resultado = resposta.Content.ReadAsStringAsync().Result;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    App.MensagemAlerta("Erro", "Não foi possivel agendar a consulta " + ex);
                    return false;
                }

                return true;

            }


            return false;

        }
    }
}
