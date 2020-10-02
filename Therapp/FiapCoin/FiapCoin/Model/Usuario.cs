using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace THERAPP.Model
{
    public class Usuario : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private String _username;
        public String username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private String _email;
        public String email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private String _password;
        public String password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    NotifyPropertyChanged();
                }
            }

        }


        public Usuario()
        {

        }

        public Usuario(string _email, string _senha)
        {
            this.email = _email;
            this.password = _senha;
        }

        public Usuario(string _email, string _senha, string _username)
        {
            this.email = _email;
            this.username = _username;
            this.password = _senha;
        }
    }
}
