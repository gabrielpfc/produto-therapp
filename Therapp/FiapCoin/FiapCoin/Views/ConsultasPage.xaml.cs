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
    public partial class ConsultasPage : ContentPage
    {
        public ConsultasPage()
        {
            InitializeComponent();
            timePicker.Time = DateTime.Now.TimeOfDay;
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