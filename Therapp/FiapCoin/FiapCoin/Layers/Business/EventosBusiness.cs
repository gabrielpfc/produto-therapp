using System;
using System.Collections.Generic;
using THERAPP.Model;


namespace THERAPP.Layers.Business
{
    public class EventosBusiness
    {
        public IList<Evento> GetList()
        {

            IList<Evento> listaEventos;

            listaEventos = new Service.EventoService().Get();

            /*Data.EventoData eventosData = new Data.EventoData();
            listaEventos = eventosData.GetList();

            if (listaEventos == null || listaEventos.Count < 1)
            {
                listaEventos = new Service.EventoService().Get();

                foreach (var evento in listaEventos)
                {
                    eventosData.Insert(evento);
                }
            }
            */

            return listaEventos;
        }


        public Boolean newEvento(Evento newEvento)
        {
            //gerar timestamp com newEvento.date (data->timestamp)

            var Timestamp = new DateTimeOffset(newEvento.date).ToUnixTimeSeconds();
            newEvento.start = Timestamp.ToString();



             /* -- só testando variaveis de tempo
            DateTime Agora = DateTime.UtcNow;
            Agora = Agora.AddHours(-3);
            var timeSpan = DateTime.Now.TimeOfDay;


            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Timestamp).ToLocalTime();
            string formattedDate = dt.ToString("dd/MM/yyyy - hh:mm");

            String teste = Agora.ToString();
            teste = teste.Substring(0, 2);
             ---------------------------


            backup variaveis data - testar */


            var status = new Service.EventoService().newEvent(newEvento);
            return status;
        }
    }
}
