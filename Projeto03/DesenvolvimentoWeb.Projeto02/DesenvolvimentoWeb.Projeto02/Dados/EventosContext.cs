using DesenvolvimentoWeb.Projeto02.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.Projeto02.Dados
{
    public class EventosContext: DbContext
    {
        //construtor
        public EventosContext(DbContextOptions<EventosContext> options)
            : base(options)
        { }

        //coleções de entidades
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Participante> Participantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>().ToTable("TBEventos");
            modelBuilder.Entity<Evento>()
                .Property(p => p.Descricao)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Evento>()
                .Property(p => p.Local)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Evento>()
                .Property(p => p.Data)
                .IsRequired();

            modelBuilder.Entity<Evento>()
                .Property(p => p.Preco)
                .IsRequired();

            modelBuilder.Entity<Evento>()
                .Property(p => p.MimeType)
                .HasMaxLength(20);

            modelBuilder.Entity<Participante>().ToTable("TBParticipantes");
            modelBuilder.Entity<Participante>().Property(p => p.Cpf)
                .HasMaxLength(11)
                .IsRequired();
            modelBuilder.Entity<Participante>().Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Participante>().Property(p => p.Email)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Participante>().Property(p => p.DataNascimento)
                .IsRequired();

        }

    }
}
