using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using projetoFinalISW.Components.Data;
using projetoFinalISW.Components.Models;

namespace projetoFinalISW.Components.Services;

public class UsuarioService
{
    private readonly AppDbContext _context;

    public UsuarioService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CadastrarUsuario(Usuario usuario, string senha)
    {
        if (await _context.Usuarios.AnyAsync(u => u.Email == usuario.Email))
            return false;

        usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(senha);

        _context.Usuarios.Add(usuario);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<Usuario?> DoLogin(string email, string senha)
    {
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(x => x.Email == email);

        if (usuario == null)
            return null;

        return BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash)
            ? usuario
            : null;
    }
}