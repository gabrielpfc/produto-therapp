using System;
using THERAPP.Layers.Business;
using THERAPP.ViewModel;
using THERAPP.Views;
using Xamarin.Forms;

namespace THERAPP
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            // Método Interno que carrega variáveis (Objetos) Globais
            LoadGlobalVariables();

            var a = new Layers.Data.ClienteData();

            //MainPage = new AssinaturaPage();

            if (Model.Global.Cliente != null)
            {
                MainPage = new THERAPP.Views.PrincipalPage();
            }
            else
            {
                MainPage = new THERAPP.Views.LoginPage();
            }

        }

        protected override void OnStart()
        {
            // Handle when your app starts
            MessagingCenter.Subscribe<LoginViewModel>(this, "LoginSucesso",
                (sender) =>
                {
                    MainPage = new PrincipalPage();
                    //Model.Global.usuario = new Layers.Service.UsuarioService().Get();
                });

            MessagingCenter.Subscribe<LoginViewModel>(this, "Cadastrar",
               (sender) =>
               {
                   MainPage = new CadastroPage();
                });

            MessagingCenter.Subscribe<CadastroViewModel>(this, "Voltar",
                (sender) =>
                {
                    MainPage = new LoginPage();
                });

            MessagingCenter.Subscribe<CadastroViewModel>(this, "Cadastrar",
               (sender) =>
               {
                   MainPage = new LoginPage();
               });

            MessagingCenter.Subscribe<String>("", "Logoff",
                (sender) =>
                {

                    new LogoffBusiness().Logoff();

                    MainPage = new LoginPage();
                });
            /*MessagingCenter.Subscribe<String>("", "Logoff",
                (sender) =>
                {
                    MainPage = new LoginPage();
                    //Model.Global.usuario = new Layers.Service.UsuarioService().Get();
                });*/

        }

        internal static void LoadGlobalVariables()
        {
            // Carregando a lista de Consultas para acesso Global
            //Model.Global.Eventos = new EventosBusiness().GetList();

            // Carregando os dados do usuário Logado
            Model.Global.Cliente = new ClienteBusiness().GetClienteLogged();

        }

        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}


        internal static void MensagemAlerta(string titulo, string texto)
        {
            App.Current.MainPage.DisplayAlert(titulo, texto, "Ok");
        }

	}
}
