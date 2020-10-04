using System;
using System.Collections.Generic;
using System.Windows.Input;
using THERAPP.Views;
using THERAPP.Views.Components;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace THERAPP.ViewModel
{
    public class AtendimentoViewModel
    {
        public AtendimentoViewModel()
        {
            ListaChats =
                new Layers.Business.AtendimentoBusiness().ListaAtendimentosUsuario();

            ChatTappedCommand = new Command(() =>
            {
                //DependencyService.Get<IMessage>().LongAlert(ChatSelecionado.NomeDr);
                MessagingCenter.Send<Model.ChatModel>(ChatSelecionado, "ChatPageAbrir");
            });
        }

        private IList<Model.ChatModel> listaChats;
        public IList<Model.ChatModel> ListaChats
        {
            get
            {
                return listaChats;
            }
            set
            {
                listaChats = value;
            }
        }


        private Model.ChatModel chatSelecionado;
        public Model.ChatModel ChatSelecionado
        {
            get
            {
                return chatSelecionado;
            }
            set
            {
                chatSelecionado = value;
            }
        }

        public ICommand ChatTappedCommand { get; private set; }

    }
}
