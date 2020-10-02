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
	public partial class MenuPage : ContentPage
	{
		public MenuPage ()
		{
			InitializeComponent ();
		}


        public void ContatoClicked(object o, EventArgs e)
        {
            MessagingCenter.Send<ContatoPage>(new ContatoPage(), "ContatoPageAbrir");
        }

        public void QuemSomosClicked(object o, EventArgs e)
        {
            MessagingCenter.
                Send<QuemSomosPage>(
                    new QuemSomosPage(),
                    "QuemSomosPageAbrir");
        }

        public void MeusDadosClicked(object o, EventArgs e)
        {
            MessagingCenter.
                Send<MeusDadosPage>(
                    new MeusDadosPage(),
                    "MeusDadosPageAbrir");
        }

        public void ConsultasClicked(object o, EventArgs e)
        {
            MessagingCenter.
                Send<ConsultasPage>(
                    new ConsultasPage(),
                    "ConsultasPageAbrir");
        }

        public void AtendimentoClicked(object o, EventArgs e)
        {
            MessagingCenter.
                Send<AtendimentoPage>(
                    new AtendimentoPage(),
                    "AtendimentoPageAbrir");
        }


        public void SairClicked(object o, EventArgs e)
        {

            MessagingCenter.Send<String>("", "Logoff");

        }

    }
}