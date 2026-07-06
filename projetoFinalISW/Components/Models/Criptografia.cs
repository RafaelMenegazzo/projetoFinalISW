using Microsoft.AspNetCore.Identity;

namespace projetoFinalISW.Components.Models
{
    public class Criptografia
    {
        public string criptografarSenha(string senha)
        {
            var passwordHasher = new PasswordHasher<Usuario>();
            return passwordHasher.HashPassword(null, senha);
        }

        public bool verificarSenha(string senha, string senhaCriptografada )
        {
            var passwordHasher = new PasswordHasher<Usuario>();
            var result = passwordHasher.VerifyHashedPassword(null, senhaCriptografada, senha);
            return result == PasswordVerificationResult.Success;
        }

    }
}
