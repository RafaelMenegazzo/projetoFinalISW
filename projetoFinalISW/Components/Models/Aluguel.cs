namespace projetoFinalISW.Components.Models
{
    public class Aluguel
    {
        private int Id_Aluguel { get; set; }
        private int Id_Usuario { get; set; } = 0;
        private int Id_Livro { get; set; } = 0;
        private Usuario usuario { get; set; } = new Usuario();
        private Livro livro { get; set; } = new Livro();


    }
}
