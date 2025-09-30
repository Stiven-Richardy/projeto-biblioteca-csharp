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
            
        }

        public Livro pesquisar(Livro livro)
        {
            return null;
        }
    }
}
