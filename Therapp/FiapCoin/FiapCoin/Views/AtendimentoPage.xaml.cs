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
    public partial class AtendimentoPage : ContentPage
    {
        public AtendimentoPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<Model.ChatModel>(this, "ChatPageAbrir",
                        (sender) =>
                        {
                            Model.Global.ChatDetalhe = sender;
                            //this.Detail.Navigation.PushAsync(new ChatPage());
                            this.Navigation.PushAsync(new ChatPage());
                        });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Model.ChatModel>(this, "ChatPageAbrir");
        }
    }
}