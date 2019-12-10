using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.Projeto02.Dados
{
    public abstract class Dao<T> where T: class
    {
        private EventosContext Context { get; set; }

        public Dao(EventosContext context)
        {
            this.Context = context;
        }

        public void ProcessarBD(T item, TipoOperacaoBD tipo)
        {
            Context.Entry<T>(item).State = (EntityState)tipo;
            Context.SaveChanges();
        }

        public void Incluir(T item)
        {
            Context.Entry<T>(item).State = EntityState.Added;
            Context.SaveChanges();
        }
        public void Alterar(T item)
        {
            Context.Entry<T>(item).State = EntityState.Modified;
            Context.SaveChanges();
        }
        public void Remover(T item)
        {
            Context.Entry<T>(item).State = EntityState.Deleted;
            Context.SaveChanges();
        }

        public IEnumerable<T> Listar()
        {
            return Context.Set<T>().ToList();
        }

        public T BuscarPorId(int id)
        {
            return Context.Set<T>().Find(id);
        }


    }
}
