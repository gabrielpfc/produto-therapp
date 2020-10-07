using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace THERAPP.Layers.Business
{
    public class AtendimentoBusiness
    {
        public IList<Model.ChatModel> ListaAtendimentosUsuario()
        {
                return new List<Model.ChatModel>(){
                new Model.ChatModel(1,"Dr. Ricardo", "20/05/2020"),
                new Model.ChatModel(1,"Dra. Nilce",  "22/06/2020"),
                new Model.ChatModel(1,"Dr. Fernando",  "20/07/2020"),
                new Model.ChatModel(1,"Dra. Nilce ",  "14/08/2020"),
                new Model.ChatModel(1,"Dr. Fernando",  "30/08/2020"),
                new Model.ChatModel(1,"Dra. Nilce",  "01/10/2020")
            };
        }
    }
}
