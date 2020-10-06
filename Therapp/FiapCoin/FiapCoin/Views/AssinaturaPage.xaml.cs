using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THERAPP.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace THERAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssinaturaPage : ContentPage
    {
        private Cliente _cliente;
        public Cliente Cliente
        {
            get
            {
                return _cliente;
            }
            set
            {
                _cliente = value;
                Global.Cliente = _cliente;
            }
        }
        
        public AssinaturaPage()
        {
            InitializeComponent();
            _cliente = Global.Cliente;

        }
    }
}