using System;
using System.Collections.Generic;
using System.Text;

namespace THERAPP.Model
{
    public class Global
    {
        public static Cliente Cliente{ get; set; }

        public static IList<Evento> Eventos { get; set; }

        public static Evento Evento { get; set; }

        public static ChatModel ChatDetalhe { get; set; }
    }
}


