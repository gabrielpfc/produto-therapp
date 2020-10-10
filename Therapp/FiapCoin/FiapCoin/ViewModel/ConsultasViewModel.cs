using System;
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

            // -- só testando variaveis de tempo
            DateTime Agora = DateTime.UtcNow;
            Agora = Agora.AddHours(-3);
            var timeSpan = DateTime.Now.TimeOfDay;

            var Timestamp = new DateTimeOffset(Agora).ToUnixTimeSeconds();


            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Timestamp).ToLocalTime();
            string formattedDate = dt.ToString("dd/MM/yyyy - hh:mm");

            String teste = Agora.ToString();
            teste = teste.Substring(0, 2);
            // ---------------------------


            ConsultaTappedCommand = new Command(() =>
            {
                //DependencyService.Get<IMessage>().LongAlert(ConsultaSelecionada.DescConsulta);
                //deletar consulta -> var ConsultaSelecionada
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
