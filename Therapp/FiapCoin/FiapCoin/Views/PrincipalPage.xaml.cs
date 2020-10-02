using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace THERAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrincipalPage : MasterDetailPage
    {
        public PrincipalPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Abrindo tela de Contato
            MessagingCenter.Subscribe<ContatoPage>(this, 
                    "ContatoPageAbrir",
                    (sender) =>
                    {
                        this.Detail = new NavigationPage(new ContatoPage());
                        this.IsPresented = false;
                    });


            // Abrindo tela de QuemSomos
            MessagingCenter.Subscribe<QuemSomosPage>(this, "QuemSomosPageAbrir",
                (sender) =>
                {
                    this.Detail = new NavigationPage(new QuemSomosPage());
                    this.IsPresented = false;
                });

            MessagingCenter.Subscribe<MeusDadosPage>(this, "MeusDadosPageAbrir",
                (sender) =>
                {
                    this.Detail = new NavigationPage(new MeusDadosPage());
                    this.IsPresented = false;
                });

            MessagingCenter.Subscribe<ConsultasPage>(this, "ConsultasPageAbrir",
                (sender) =>
                {
                    this.Detail = new NavigationPage(new ConsultasPage());
                    this.IsPresented = false;
                });

            MessagingCenter.Subscribe<AtendimentoPage>(this, "AtendimentoPageAbrir",
                (sender) =>
                {
                    this.Detail = new NavigationPage(new AtendimentoPage());
                    this.IsPresented = false;
                });

            MessagingCenter.Subscribe<CallPage>(this, "CallPageAbrir",
                (sender) =>
                {
                    this.Detail = new NavigationPage(new CallPage());
                    this.IsPresented = false;
                });


        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<ContatoPage>(this, "ContatoPageAbrir");
            MessagingCenter.Unsubscribe<ConsultasPage>(this, "ConsultasPageAbrir");
            MessagingCenter.Unsubscribe<AtendimentoPage>(this, "AtendimentoPageAbrir");
            MessagingCenter.Unsubscribe<ContatoPage>(this, "MeusDadosPageAbrir");
            MessagingCenter.Unsubscribe<QuemSomosPage>(this, "QuemSomosPageAbrir");
            MessagingCenter.Unsubscribe<CallPage>(this, "CallPageAbrir");
        }
    }
}