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

            Data.EventoData eventosData = new Data.EventoData();
            listaEventos = eventosData.GetList();

            if (listaEventos == null || listaEventos.Count < 1)
            {
                listaEventos = new Service.EventoService().Get();

                foreach (var evento in listaEventos)
                {
                    eventosData.Insert(evento);
                }
            }

            return listaEventos;
        }
    }
}
