using DesenvolvimentoWeb.Projeto02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.Projeto02.Dados
{
    public class ParticipantesDaoImpl : Dao<Participante>
    {
        public readonly EventosContext context;
        public ParticipantesDaoImpl(EventosContext context)
            : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Participante> ListarPorEvento(int idEvento)
        {
            return context.Participantes.Where(p => p.IdEvento == idEvento).ToList();
        }

    }
}
