﻿using System;
using System.Collections.Generic;
using THERAPP.Model;


namespace THERAPP.Layers.Business
{
    public class EventosBusiness
    {
        public IList<Evento> GetList()
        {
            IList<Evento> listaEventos;
            List<Evento> listaProxEventos = new List<Evento>();
            List<Evento> listaHistorico = new List<Evento>();

            listaEventos = new Service.EventoService().Get();
            DateTime today = DateTime.Now;
            today = today.AddHours(-3);

            foreach (Evento evento in listaEventos)
            {
                if (evento.date < today) { 
                    listaHistorico.Add(evento);
                }
            }
            Model.Global.Historico = listaHistorico;

            today = today.AddHours(-1);
            foreach (Evento evento in listaEventos)
            {
                if (evento.date > today)
                {
                    listaProxEventos.Add(evento);
                }
            }

            return listaProxEventos;
        }


        public Boolean newEvento(Evento newEvento)
        {
            //gerar timestamp
            var Timestamp = new DateTimeOffset(newEvento.date).ToUnixTimeSeconds();
            newEvento.start = Timestamp.ToString();

            var status = new Service.EventoService().newEvent(newEvento);
            return status;
        }
    }
}
