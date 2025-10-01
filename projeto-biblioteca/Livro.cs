using System;
using System.Collections.Generic;
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
            Exemplar pesquisaExemplar = exemplares.Find(e => e.Tombo == exemplar.Tombo);
            if (pesquisaExemplar == null) 
            {
                exemplares.Add(exemplar);
                Utils.MensagemSucesso(" Exemplar adicionado com sucesso! ");
            }
            else
            {
                Utils.MensagemErro($"Exemplar já existe! Tombo nº{exemplar.Tombo}");
            }
        }

        public int qtdeExemplares()
        {
            return 0;
        }

        public int qtdeDisponiveis()
        {
            return 0;
        }

        public int qtdeEmprestimos()
        {
            return 0;
        }

        public double percDisponibilidade()
        {
            return 0;
        }
    }
}
