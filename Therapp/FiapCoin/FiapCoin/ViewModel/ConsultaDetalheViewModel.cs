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

            CancelarClickedCommand = new Command(() =>
            {
                App.MensagemAlerta("Ainda não é possivel cancelar consultas.", "Mas fique tranquilo você não pagara nenhuma taxa caso falte na consulta.");
                //MessagingCenter.Send<CadastroViewModel>(this, "Voltar");
            });

            AlterarClickedCommand = new Command(() =>
            {
                App.MensagemAlerta("Ainda não é possivel alterar consultas.", "Mas fique tranquilo você pode agendar uma nova consulta.");
            });

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

        public ICommand EntrarClickedCommand { get; private set; }

        public ICommand AlterarClickedCommand { get; private set; }

        public ICommand CancelarClickedCommand { get; private set; }

    }
}