using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace THERAPP.Model
{
    public class ChatModel : INotifyPropertyChanged
    {
        public ChatModel()
        {

        }

        public ChatModel(int _id, String _nome, String _data)
        {
            this.IdChat = _id;
            this.NomeDr = _nome;
            this.Data = _data;
        }


        private int idChat;
        public int IdChat
        {
            get { return idChat; }
            set
            {
                if (idChat != value)
                {
                    idChat = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private String nomeDr;
        public String NomeDr
        {
            get { return nomeDr; }
            set
            {
                if (nomeDr != value)
                {
                    nomeDr = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private String data;
        public String Data
        {
            get { return data; }
            set
            {
                if (data != value)
                {
                    data = value;
                    NotifyPropertyChanged();
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}