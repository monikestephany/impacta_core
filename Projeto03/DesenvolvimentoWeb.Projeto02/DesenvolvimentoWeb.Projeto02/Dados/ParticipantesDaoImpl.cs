using DesenvolvimentoWeb.Projeto02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.Projeto02.Dados
{
    public class ParticipantesDaoImpl : Dao<Participante>
    {
        private EventosContext Context { get; set; }
        public ParticipantesDaoImpl(EventosContext context)
            : base(context)
        {
            this.Context = context;
        }

        //método para listar os participantes por evento
        public IEnumerable<Participante> ListarPorEvento(int idEvento)
        {
            return Context.Participantes
                .Where(p => p.IdEvento == idEvento)
                .ToList();
        }
    }
}
