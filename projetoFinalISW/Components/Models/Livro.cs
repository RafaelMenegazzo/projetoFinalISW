namespace projetoFinalISW.Components.Models
{
    public class Livro
    {
        private int Id_livro { get; set; }
        private int AnoPublicacao { get; set; }
        private string Titulo { get; set; }
        private string sinopse { get; set; }
        private string Autor { get; set; }
        private string Editora { get; set; }
        private string genero { get; set; }
        private bool Disponivel { get; set; }


        public int getIdLivro()
        {
            return this.Id_livro;
        }

        public string getTitulo()
        {
            return this.Titulo;
        }

        public string getSinopse()
        {
            return this.sinopse;
        }

        public string getAutor()
        {
            return this.Autor;
        }

        public string getEditora()
        {
            return this.Editora;
        }

        public string getGenero()
        {
            return this.genero;
        }

        public int getAnoPublicacao()
        {
            return this.AnoPublicacao;
        }

        public bool getDisponivel()
        {
            return this.Disponivel;
        }

        public void setTitulo(string titulo)
        {
            if(titulo.Length > 100 || !Validator.ValidarTexto(titulo))
            {
                throw new Exception("O título do livro não pode conter mais de 100 caracteres ou caracteres inválidos.");
            }
            this.Titulo = titulo;
        }

        public void setSinopse(string sinopse)
        {
            if (sinopse.Length > 500 || !Validator.ValidarTexto(sinopse))
            {
                throw new Exception("A sinopse do livro não pode conter mais de 500 caracteres ou caracteres inválidos.");
            }
            this.sinopse = sinopse;
        }
        public void setAutor(string autor)
        {
            if (autor.Length > 100 || !Validator.ValidarTexto(autor))
            {
                throw new Exception("O nome do autor não pode conter mais de 100 caracteres ou caracteres inválidos.");
            }
            this.Autor = autor;
        }
        public void setEditora(string editora)
        {
            if (editora.Length > 100 || !Validator.ValidarTexto(editora))
            {
                throw new Exception("O nome da editora não pode conter mais de 100 caracteres ou caracteres inválidos.");
            }
            this.Editora = editora;
        }

        public void setGenero(string genero)
        {
            if (genero.Length > 50 || !Validator.ValidarTexto(genero))
            {
                throw new Exception("O gênero do livro não pode conter mais de 50 caracteres ou caracteres inválidos.");
            }
            this.genero = genero;
        }

        public void setAnoPublicacao(int anoPublicacao)
        {
            if (anoPublicacao < 0 || anoPublicacao > DateTime.Now.Year)
            {
                throw new Exception("O ano de publicação do livro deve ser um valor válido.");
            }
            this.AnoPublicacao = anoPublicacao;
        }
        public void setDisponivel(bool disponivel)
        {
            this.Disponivel = disponivel;
        }


      



    }
}
