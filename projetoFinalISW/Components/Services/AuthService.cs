using projetoFinalISW.Components.Models;

namespace projetoFinalISW.Components.Services
{
    public class AuthService
    {
        public Usuario? UsuarioLogado { get; private set; }

        public bool EstaLogado => UsuarioLogado != null;

        public void DoLogin(Usuario usuario)
        {
            UsuarioLogado = usuario;
        }

        public void Logout()
        {
            UsuarioLogado = null;
        }
    }
}
