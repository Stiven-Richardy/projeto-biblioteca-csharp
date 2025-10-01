using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_biblioteca
{
    internal class Livro
    {
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares = new List<Exemplar>();

        public int Isbn { get => isbn; set => isbn = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Editora { get => editora; set => editora = value; }
        public List<Exemplar> Exemplares { get => exemplares; set => exemplares = value; }

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            Isbn = isbn;
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
        }

        public Livro(int isbn) : this(isbn, "", "", "") { }

        public void adicionarExemplar(Exemplar exemplar)
        {
            
        }

        public int qtdeExemplares()
        {
            return exemplares.Count();
        }

        public int qtdeDisponiveis()
        {
            return exemplares.Count(exemplar => exemplar.disponivel() == true);
        }

        public int qtdeEmprestimos()
        {
            int qtde = 0;
            foreach(Exemplar e in exemplares)
                qtde += e.qtdeEmprestimos();
            return qtde;
        }

        public double percDisponibilidade()
        {
            return (qtdeDisponiveis()/qtdeExemplares()) * 100;
        }
    }
}
