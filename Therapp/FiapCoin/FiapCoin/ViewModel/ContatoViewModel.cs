using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using THERAPP.Model;
using THERAPP.Views;
using THERAPP.Views.Components;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace THERAPP.ViewModel
{
    public class ContatoViewModel {
        public ICommand CadastrarClickedCommand { get; private set; }
        private Cliente _cliente;
        public Cliente Cliente
        {
            get
            {
                return _cliente;
            }
            set
            {
                _cliente = value;
                Global.Cliente = _cliente;
            }
        }

        public ContatoViewModel()
        {
            _cliente = Global.Cliente;
            
            CadastrarClickedCommand = new Command(() =>
            {
                App.MensagemAlerta(_cliente.name + " obrigado pelo contato.", "Em breve retornaremos no seu email " + _cliente.email);
                MessagingCenter.
                            Send<ConsultasPage>(
                                new ConsultasPage(),
                                "ConsultasPageAbrir");
            });


        }

    }
}
