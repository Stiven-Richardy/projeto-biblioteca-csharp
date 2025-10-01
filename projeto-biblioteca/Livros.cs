using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_biblioteca
{
    internal class Livros
    {
        private List<Livro> acervo = new List<Livro>();

        public List<Livro> Acervo { get => acervo; set => acervo = value; }

        public void adicionar(Livro livro)
        {
            if ((pesquisar(livro) == null))
            {
                acervo.Add(livro);
                Utils.MensagemSucesso("Livro adicionado com sucesso.");
            }
            else
                Utils.MensagemErro("Não foi possível adicionar um livro.");
        }

        public Livro pesquisar(Livro livro)
        {
            return acervo.Find(livroPesquisado => livroPesquisado.Isbn.Equals(livro.Isbn));
        }
    }
}
