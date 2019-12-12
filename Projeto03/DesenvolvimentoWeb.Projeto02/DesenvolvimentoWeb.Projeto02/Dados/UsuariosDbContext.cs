using DesenvolvimentoWeb.Projeto02.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.Projeto02.Dados
{
    public class UsuariosDbContext :IdentityDbContext<Usuario>
    {
        public UsuariosDbContext(DbContextOptions<UsuariosDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
