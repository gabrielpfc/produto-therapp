using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using THERAPP.Model;
using THERAPP.Views;
using THERAPP.Views.Components;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace THERAPP.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Usuario Usuario { get; set; }
        public ICommand EntrarClickedCommand { get; private set; }
        public ICommand CadastrarClickedCommand { get; private set; }

        public LoginViewModel()
        {
            Usuario = new Usuario();

            Usuario.email = "";
            Usuario.password = "";

            EntrarClickedCommand = new Command(() => {
                try
                {
                    var cliente =
                        new Layers.Business.UsuarioBusiness().Login(Usuario.email, Usuario.password);

                    //App.LoadGlobalVariables();
                    if (cliente.id != 0)
                    {
                        Global.Cliente = cliente;
                        MessagingCenter.Send<LoginViewModel>(this, "LoginSucesso");
                    }
                }
                catch (Exception ex)
                {
                    App.MensagemAlerta("Erro", "Usuário ou senha inválidos");
                }
            });

            CadastrarClickedCommand = new Command(() => {
                MessagingCenter.Send<LoginViewModel>(this, "Cadastrar");
            });


        }

    }
}
