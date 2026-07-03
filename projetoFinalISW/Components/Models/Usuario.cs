using Microsoft.AspNetCore.Identity;

namespace projetoFinalISW.Components.Models
{
    public class Usuario : IdentityUser
    {
        private int Id {get;set;}
        private string Nome { get; set; } = string.Empty;
        private string Email { get; set; } = string.Empty;
        private string Senha { get; set; } = string.Empty;
        private List<Livro> livros { get; set; } = new List<Livro>();

        public int getId()
        {
            return this.Id;
        }

        public List<Livro> getLivros()
        {
            return this.livros;
        }

        public string getNome()
        {
            return this.Nome;
        }

        public string getEmail()
        {
            return this.Email;
        }

        public string getSenha()
        {
            return this.Senha;
        }   

        public string setNome(string nome)
        {
            if (nome.Length > 50 || !Validator.ValidarTexto(nome))
            {
                throw new Exception("O nome do usuário não pode conter mais de 50 caracteres ou caracteres inválidos.");
            }
            this.Nome = nome;
            return this.Nome;
        }

        public string setEmail(string email)
        {
            if (!Validator.ValidarEmail(email))
            {
                throw new Exception("O email do usuário não é válido.");
            }
            this.Email = email;
            return this.Email;
        }
        
        public string setSenha(string senha)
        {
            if (senha.Length < 6 || senha.Length > 12)
            {
                throw new Exception("A senha do usuário deve ter entre 6 e 12 caracteres.");
            }
            this.Senha = senha;
            return this.Senha;
        }

        

    }
}
