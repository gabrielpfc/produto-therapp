using System;
using System.Collections.Generic;
using System.Windows.Input;
using THERAPP.Views.Components;
using Xamarin.Forms;

namespace THERAPP.ViewModel
{
    public class ChatViewModel
    {
        public ChatViewModel()
        {
            Chat = Model.Global.ChatDetalhe;
        }
        public ChatViewModel(Model.ChatModel _chat)
        {
            Chat = _chat;
        }

        private Model.ChatModel chat;
        public Model.ChatModel Chat
        {
            get
            {
                return chat;
            }
            set
            {
                chat = value;
            }
        }
    }
}