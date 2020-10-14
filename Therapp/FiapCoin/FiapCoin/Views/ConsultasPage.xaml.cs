using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THERAPP.Layers.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace THERAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultasPage : ContentPage
    {
        public ConsultasPage()
        {
            InitializeComponent();
            timePicker.Time = DateTime.Now.TimeOfDay;
        }

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<Model.Evento>(this, "ConsultaDetalhePageAbrir",
                        (sender) =>
                        {
                            Model.Global.Evento = sender;
                            this.Navigation.PushAsync(new ConsultaDetalhePage());
                        });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Model.Evento>(this, "ConsultaDetalhePageAbrir");
        }

        public void Agendar_Clicked(object o, EventArgs e)
        {
            var date = datePicker.Date;
            var time = timePicker.Time;

            //construindo data com os componentes
            String collectData = date.ToString().Substring(0, 10) + " " + time.ToString().Substring(0, 5);
            DateTime oDate = DateTime.ParseExact(collectData, "MM/dd/yyyy HH:mm",
                                           CultureInfo.InvariantCulture);

            if (oDate <= DateTime.Now)
            {
                App.MensagemAlerta("Desculpe.", "Não possuimos atendimento neste horário, tente uma outra data!");
            }
            else { 
                //convertendo data para timestamp
                var timeStamp = new DateTimeOffset(oDate).ToUnixTimeSeconds();

                if(new EventoService().newEvent(new Model.Evento(0,0,"Consulta", "Atendimento", "Atendimento", timeStamp.ToString())))
                {
                    DisplayAlert("Tudo certo!", "Sua consulta foi agendada.", "OK");
                    InitializeComponent();
                }   
            }
        }

        public BindableProperty Teste { get; private set; }

        public void CallClicked(object o, EventArgs e)
        {
            MessagingCenter.
                Send<CallPage>(
                    new CallPage(),
                    "CallPageAbrir");
        }

    }
}