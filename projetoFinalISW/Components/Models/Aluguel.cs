namespace projetoFinalISW.Components.Models
{
    public class Aluguel
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; } = null!;

        public int LivroId { get; set; }

        public Livro Livro { get; set; } = null!;

        public DateTime DataAluguel { get; set; }

        public DateTime? DataDevolucao { get; set; }

    }
}
