using DesenvolvimentoWeb.WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.WebApi.Data
{
    public class PagamentoContext : DbContext
    {
        public PagamentoContext(DbContextOptions<PagamentoContext> options) : base(options) { }
        public DbSet<Pagamento> Pagamentos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pagamento>().ToTable("TbPagamentos");
            modelBuilder.Entity<Pagamento>().Property(p => p.Cpf).HasMaxLength(11).IsRequired();
            modelBuilder.Entity<Pagamento>().Property(p => p.NumeroCartao).HasMaxLength(16).IsRequired();
            modelBuilder.Entity<Pagamento>().Property(p => p.Valor).IsRequired();
            modelBuilder.Entity<Pagamento>().Property(p => p.IdEvento).IsRequired();

        }
    }
}
