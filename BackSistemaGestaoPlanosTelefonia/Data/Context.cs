using BackSistemaGestaoPlanosTelefonia.Models;
using Microsoft.EntityFrameworkCore;

namespace BackSistemaGestaoPlanosTelefonia.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
                : base(options)
        { }

        public DbSet<PlanoTelefone> PlanosDeSaude { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClientePlano> ClientePlanos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientePlano>()
                .HasOne(cp => cp.Cliente)
                .WithMany(c => c.ClientePlanos)
                .HasForeignKey(cp => cp.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);  // Configurar exclusão em cascata, caso necessário

            modelBuilder.Entity<ClientePlano>()
                .HasOne(cp => cp.Plano)
                .WithMany(p => p.ClientePlanos)
                .HasForeignKey(cp => cp.PlanoId)
                .OnDelete(DeleteBehavior.Cascade);  // Configurar exclusão em cascata, caso necessário
        }
    }
}

