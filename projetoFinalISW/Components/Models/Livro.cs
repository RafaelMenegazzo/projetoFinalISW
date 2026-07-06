using System.ComponentModel.DataAnnotations;

namespace projetoFinalISW.Components.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; } = "";

        [MaxLength(500)]
        public string Sinopse { get; set; } = "";

        [Required]
        [MaxLength(100)]
        public string Autor { get; set; } = "";

        [MaxLength(100)]
        public string Editora { get; set; } = "";

        [MaxLength(50)]
        public string Genero { get; set; } = "";

        public int AnoPublicacao { get; set; }

        public bool Disponivel { get; set; } = true;

        public ICollection<Aluguel> Alugueis { get; set; }
            = new List<Aluguel>();
    }
}