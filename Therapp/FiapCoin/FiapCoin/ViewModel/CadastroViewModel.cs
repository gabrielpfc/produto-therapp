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
    public class CadastroViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Cliente Cliente { get; set; }
        public ICommand VoltarClickedCommand { get; private set; }
        public ICommand CadastrarClickedCommand { get; private set; }

        public Boolean validaCampos(Cliente cliente)
        {
            if (cliente.email.Length < 4)
            {
                App.MensagemAlerta("Não foi possivel cadastrar.", "Insira um e-mail");
                return false;
            }
            if (cliente.password.Length < 6)
            {
                App.MensagemAlerta("Não foi possivel cadastrar.", "Senha muito fraca!");
                return false;
            }
            if (cliente.name.Length < 2)
            {
                App.MensagemAlerta("Não foi possivel cadastrar.", "Insira um nome!");
                return false;
            }
            if (cliente.idade < 1 || cliente.idade > 140)
            {
                App.MensagemAlerta("Não foi possivel cadastrar.", "Idade inválida!");
                return false;
            }
            if (cliente.peso < 1 || cliente.peso > 740)
            {
                App.MensagemAlerta("Não foi possivel cadastrar.", "Insira seu Peso!");
                return false;
            }
            if (cliente.cep.Length < 7)
            {
                App.MensagemAlerta("Não foi possivel cadastrar.", "Cep inválido!");
                return false;
            }
            if (cliente.cep == "01234567" || cliente.cep == "012345678" || cliente.cep == "0123456789" || cliente.cep == "0123456" || cliente.cep == "123456" || cliente.cep == "1234567" || cliente.cep == "12345678" || cliente.cep == "123456789")
            {
                App.MensagemAlerta("Não foi possivel cadastrar.", "Cep inválido!");
                return false;
            }
            if (cliente.number.Length < 8)
            {
                App.MensagemAlerta("Não foi possivel cadastrar.", "Telefone inválido!");
                return false;
            }

            return true;
        }

        public CadastroViewModel()
        {
            Cliente = new Cliente();

            Cliente.email = "";
            Cliente.password = "";
            Cliente.name = "";
            Cliente.number = "";
            Cliente.cep = "";
            Cliente.age = 0;
            Cliente.peso = 0;
            Cliente.gender = "";
            Cliente.idade = 0;

            CadastrarClickedCommand = new Command(() =>
            {
                if (Cliente.gender != "Masculino" && Cliente.gender != "Feminino")
                {
                    Cliente.gender = "nb";
                }
                //Adaptações
                Cliente.email = Cliente.email.ToLower();
                Cliente.username = Cliente.email;
                Cliente.idade = Cliente.age;
                if (validaCampos(new Cliente(Cliente.email, Cliente.username, Cliente.name, Cliente.password, Cliente.number, Cliente.age, Cliente.idade, Cliente.cep, Cliente.gender, Cliente.peso)))
                {

                    Cliente cliente = new Layers.Business.ClienteBusiness().Cadastrar(new Cliente(Cliente.email, Cliente.username, Cliente.name, Cliente.password, Cliente.number, Cliente.age, Cliente.idade, Cliente.cep, Cliente.gender, Cliente.peso));

                    if (cliente != null)
                    {
                        MessagingCenter.Send<CadastroViewModel>(this, "Cadastrar");
                        DependencyService.Get<IMessage>().ShortAlert("Estamos prontos para te atender!\n Com base em sua ficha técnica você já foi associado ao Doutor mais próximo e especializado em seu perfil.");
                    }
                }
            });

            VoltarClickedCommand = new Command(() =>
            {
                MessagingCenter.Send<CadastroViewModel>(this, "Voltar");
            });


        }

    }
}
