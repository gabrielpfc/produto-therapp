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
            DateTime today = DateTime.Now;
            today = today.AddHours(-3);
            DateTime answer = today.AddMinutes(21);

            DateTime dataConsulta = Model.Global.Evento.date;
            dataConsulta = dataConsulta.AddMinutes(+1);

            if (dataConsulta > today)
            {
                App.MensagemAlerta("Por favor aguarde até a data da consulta.", "Em caso de urgência você pode utilizar uma consulta emergencial.");
            }
            else if (dataConsulta > answer)
            {
                App.MensagemAlerta("Esta consulta já expirou.", "Em caso de urgência você pode utilizar uma consulta emergencial.");
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