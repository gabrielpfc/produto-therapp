using System;
using System.Collections.Generic;
using System.Windows.Input;
using THERAPP.Views;
using THERAPP.Views.Components;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using THERAPP.Model;
using THERAPP.Layers.Service;

namespace THERAPP.ViewModel
{
    public class MeusDadosViewModel
    {
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

        public MeusDadosViewModel()
        {
            _cliente = Global.Cliente;

            GravarTappedCommand = new Command(() => {
                if (Cliente.gender != "Masculino" && Cliente.gender != "Feminino")
                {
                    Cliente.gender = "nb";
                }

                var mensagem = "Seus dados foram alterados com sucesso!";
                try
                {
                    //new ClienteService().Save(_cliente);
                }
                catch (Exception ex)
                {
                    mensagem = "Não foi possível alterar os dados do cliente. Verifique sua conexão! \n Detalhe: " +
                        ex.Message;
                }

                App.MensagemAlerta("Tudo certo!",mensagem);
            });
        }

        public ICommand GravarTappedCommand { get; private set; }

    }
}
