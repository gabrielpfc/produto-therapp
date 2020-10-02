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
                new Model.ChatModel(1,"Dr. Ricardo", "20/10/2020"),
                new Model.ChatModel(1,"Dra Nilce",  "22/10/2020"),
                new Model.ChatModel(1,"Dr Fernando",  "20/11/2020"),
                new Model.ChatModel(1,"Dra Nilce ",  "24/11/2020"),
                new Model.ChatModel(1,"Dr Fernando",  "30/11/2020"),
                new Model.ChatModel(1,"Dra Nilce",  "10/12/2020")
            };
        }
    }
}
