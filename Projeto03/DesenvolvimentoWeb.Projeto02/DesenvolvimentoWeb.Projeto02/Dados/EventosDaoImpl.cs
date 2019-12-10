using DesenvolvimentoWeb.Projeto02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.Projeto02.Dados
{
    public class EventosDaoImpl : Dao<Evento>
    {
        public EventosDaoImpl(EventosContext context)
            : base(context)
        { }
    }
}
