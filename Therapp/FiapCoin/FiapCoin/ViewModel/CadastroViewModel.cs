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

                Cliente cliente = new Layers.Business.ClienteBusiness().Cadastrar(new Cliente(Cliente.email, Cliente.username, Cliente.name, Cliente.password, Cliente.number, Cliente.age, Cliente.idade, Cliente.cep, Cliente.gender, Cliente.peso));

                if (cliente!=null)
                {
                    MessagingCenter.Send<CadastroViewModel>(this, "Cadastrar");
                    App.MensagemAlerta("Estamos prontos para te atender", "\n Com base em sua ficha técnica você já foi associado ao Doutor mais próximo e especializado em seu perfil.");
                }
            });

            VoltarClickedCommand = new Command(() =>
            {
                MessagingCenter.Send<CadastroViewModel>(this, "Voltar");
            });


        }

    }
}
