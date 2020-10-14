using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace THERAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaDetalhePage : ContentPage
    {
        public ConsultaDetalhePage()
        {
            InitializeComponent();
        }
        public void CallClicked(object o, EventArgs e)
        {
            if (Model.Global.Evento.date > DateTime.Now)
            {
                //
                App.MensagemAlerta("Por favor aguarde a data da sua consulta.", "Em caso de urgência você pode utilizar uma consulta emergencial.");
            }
            else
            {
                MessagingCenter.
                    Send<CallAgendadaPage>(
                        new CallAgendadaPage(),
                        "CallAgendadaPageAbrir");
            }
        }
    }
}