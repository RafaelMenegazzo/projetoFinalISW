using Microsoft.EntityFrameworkCore;
using projetoFinalISW.Components.Models;

namespace projetoFinalISW.Components.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Livro> Livros => Set<Livro>();
        public DbSet<Aluguel> Alugueis => Set<Aluguel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluguel>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Alugueis)
                .HasForeignKey(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Aluguel>()
                .HasOne(a => a.Livro)
                .WithMany(l => l.Alugueis)
                .HasForeignKey(a => a.LivroId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}