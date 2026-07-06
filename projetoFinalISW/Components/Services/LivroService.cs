using Microsoft.EntityFrameworkCore;
using projetoFinalISW.Components.Data;
using projetoFinalISW.Components.Models;

namespace projetoFinalISW.Components.Services;

public class LivroService
{
    private readonly AppDbContext _context;

    public LivroService(AppDbContext context)
    {
        _context = context;
    }

    public async Task CadastroLivro(Livro livro)
    {
        _context.Livros.Add(livro);

        await _context.SaveChangesAsync();
    }

    public async Task<List<Livro>> Listar()
    {
        return await _context.Livros.ToListAsync();
    }

  
}