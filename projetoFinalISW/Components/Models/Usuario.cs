using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace projetoFinalISW.Components.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        // Aqui será armazenado apenas o hash
        public string SenhaHash { get; set; }

        public ICollection<Aluguel> Alugueis { get; set; }
            = new List<Aluguel>();
        public int getId()
        {
            return this.Id;
        }


        public string getNome()
        {
            return this.Nome;
        }

        public string getEmail()
        {
            return this.Email;
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
        
   

        

    }
}
