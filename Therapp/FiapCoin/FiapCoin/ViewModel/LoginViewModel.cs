using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using THERAPP.Model;
using THERAPP.Views;
using THERAPP.Views.Components;
using System;

namespace THERAPP.ViewModel
{
    public class LoginViewModel
    {
        public Usuario Usuario { get; set; }
        public ICommand EntrarClickedCommand { get; private set; }
        public ICommand CadastrarClickedCommand { get; private set; }

        public LoginViewModel()
        {
            Usuario = new Usuario();

            // -- erro -- TypeError("'NoneType' object is not subscriptable",) -- 28/09
            // Corrigido -- 30/09
            Usuario.email = "fdasilva@mail";
            Usuario.password = "12345";

            //Usuario.Email = "testegab@gmail.com";
            //Usuario.Senha = "testegabr";

            // -- erro -- AssertionError('Error login incorreto!',)
            //Usuario.Email = "testegab@gmail.com";
            //Usuario.Senha = "testegab";

            //Usuario.Email = "admin";
            //Usuario.Senha = "1234";

            //Usuario.Email = "admin@fiap.com.br";
            //Usuario.Senha = "123456";


            EntrarClickedCommand = new Command(() => {
                try
                {
                    var cliente =
                        new Layers.Business.UsuarioBusiness().Login(Usuario.email, Usuario.password);

                    //descomentar
                    App.LoadGlobalVariables();

                    MessagingCenter.Send<LoginViewModel>(this, "LoginSucesso");
                }
                catch (Exception ex)
                {
                    App.MensagemAlerta("Erro", "Usuário ou senha inválidos" + ex.Message);
                }
            });

            /*if (cliente.IdUsuario != 0)
            {
                Global.Cliente = cliente;
                MessagingCenter.Send<LoginViewModel>(this, "LoginSucesso");
            }
            else
            {
                App.MensagemAlerta("Login ou senha inválida");
            }
        }
        catch (Exception ex)
        {
            App.MensagemAlerta("Login ou senha inválida. Detalhe: " + ex.Message);
        }
    });*/

            CadastrarClickedCommand = new Command(() => {
                MessagingCenter.Send<LoginViewModel>(this, "Cadastrar");
            });


        }

    }
}
