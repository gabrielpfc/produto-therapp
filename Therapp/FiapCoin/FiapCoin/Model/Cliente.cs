using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace THERAPP.Model
{
    public class Cliente : INotifyPropertyChanged
    {
        //colocar o calendar_id ou eventos(id)
        /*[ForeignKey(typeof(Evento))]
        public int IdEvento
        {
            get; set;
        }*/

        private int _of_list;
        //[OneToOne(foreignKey: "IdEvento")]
        public int of_list
        {
            get { return _of_list; }
            set
            {
                if (_of_list != value)
                {
                    _of_list = value;
                    NotifyPropertyChanged();
                }
            }
        }



        private int _id;

        [PrimaryKey]
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

        private String _name;
        public String name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
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


        private String _number;
        public String number
        {
            get { return _number; }
            set
            {
                if (_number != value)
                {
                    _number = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private String _gender;
        public String gender
        {
            get { return _gender; }
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private String _cep;
        public String cep
        {
            get { return _cep; }
            set
            {
                if (_cep != value)
                {
                    _cep = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private double _peso;
        public double peso
        {
            get { return _peso; }
            set
            {
                if (_peso != value)
                {
                    _peso = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int _age;
        public int age
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
                    _age = value;
                    NotifyPropertyChanged();
                }
            }
        }





        public Cliente()
        {
        }

        public Cliente(int _id)
        {
            this.id = _id;
        }

        public Cliente(int _id, String _email, String _nome, String _fone, int _age, String _cep, String _sexo, double _peso, int _evento)
        {
            this.id = _id;
            this.name = _nome;
            this.email = _email;
            this.number = _fone;
            this.age = _age;
            this.cep = _cep;
            this.gender = _sexo;
            this.peso = _peso;
            this.of_list = _evento;
        }

        public Cliente(String _email, string _username, String _nome, String _senha, String _fone, int _age, String _cep, String _sexo, double _peso)
        {
            this.name = _nome;
            this.email = _email;
            this.number = _fone;
            this.username = _username;
            this.age = _age;
            this.cep = _cep;
            this.gender = _sexo;
            this.peso = _peso;
            this.password = _senha;
        }

        public Cliente(int _id, String _email, string _username, String _senha)
        {
            this.id = _id;
            this.email = _email;
            this.username = _username;
            this.password = _senha;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}