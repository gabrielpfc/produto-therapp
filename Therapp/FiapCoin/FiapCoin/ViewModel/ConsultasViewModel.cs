﻿using System;
using System.Collections.Generic;
using System.Windows.Input;
using THERAPP.Views.Components;
using Xamarin.Forms;


namespace THERAPP.ViewModel
{
    public class ConsultasViewModel
    {
        public ConsultasViewModel()
        {
            ListaConsultas = new Layers.Business.EventosBusiness().GetList();

            ConsultaTappedCommand = new Command(() =>
            {
                MessagingCenter.Send<Model.Evento>(ConsultaSelecionada, "ConsultaDetalhePageAbrir");
            });
        }

        private IList<Model.Evento> listaConsultas;
        public IList<Model.Evento> ListaConsultas
        {
            get
            {
                return listaConsultas;
            }
            set
            {
                listaConsultas = value;
            }
        }


        private Model.Evento consultaSelecionada;
        public Model.Evento ConsultaSelecionada
        {
            get
            {
                return consultaSelecionada;
            }
            set
            {
                consultaSelecionada = value;
            }
        }

        public ICommand ConsultaTappedCommand { get; private set; }

    }
}
