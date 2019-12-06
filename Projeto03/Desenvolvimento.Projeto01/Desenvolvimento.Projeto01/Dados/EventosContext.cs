using Desenvolvimento.Projeto01.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desenvolvimento.Projeto01.Dados
{
    public class EventosContext :DbContext
    {
        public EventosContext(DbContextOptions<EventosContext> options) : base(options)
        {}
        public DbSet<Eventos> MyProperty { get; set; }
    }
}
