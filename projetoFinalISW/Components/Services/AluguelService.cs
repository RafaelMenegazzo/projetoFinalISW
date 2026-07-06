using projetoFinalISW.Components.Data;
using projetoFinalISW.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace projetoFinalISW.Components.Services
{
    public class AluguelService
    {

        private readonly AppDbContext _context;

        public AluguelService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Livro>> LivrosDisponiveis()
        {
            return await _context.Livros
                .Where(l => l.Disponivel)
                .ToListAsync();
        }

        public async Task<List<Aluguel>> MeusLivros(int usuarioId)
        {
            return await _context.Alugueis

                .Include(a => a.Livro)

                .Where(a => a.UsuarioId == usuarioId)

                .ToListAsync();
        }

        public async Task AlugarLivro(int livroId, int usuarioId)
        {
            var livro = await _context.Livros.FindAsync(livroId);

            if (livro == null || !livro.Disponivel)
                return;

            livro.Disponivel = false;

            _context.Alugueis.Add(new Aluguel
            {
                LivroId = livro.Id,
                UsuarioId = usuarioId,
                DataAluguel = DateTime.UtcNow,
                DataDevolucao = DateTime.UtcNow.AddDays(15)
            });

            await _context.SaveChangesAsync();
        }

        public async Task Renovar(int aluguelId)
        {
            var aluguel = await _context.Alugueis.FindAsync(aluguelId);

            if (aluguel == null)
                return;

            aluguel.DataDevolucao =
                aluguel.DataDevolucao?.ToUniversalTime().AddDays(15);

            await _context.SaveChangesAsync();
        }

    }


}
