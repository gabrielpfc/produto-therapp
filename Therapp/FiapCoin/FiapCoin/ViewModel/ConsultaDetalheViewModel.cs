using System;
using System.Collections.Generic;
using System.Windows.Input;
using THERAPP.Views.Components;
using Xamarin.Forms;

namespace THERAPP.ViewModel
{
    public class ConsultaDetalheViewModel
    {
        public ConsultaDetalheViewModel()
        {
            Evento = Model.Global.Evento;
        }
        public ConsultaDetalheViewModel(Model.Evento _evento)
        {
            Evento = _evento;
        }

        private Model.Evento evento;
        public Model.Evento Evento
        {
            get
            {
                return evento;
            }
            set
            {
                evento = value;
            }
        }
    }
}