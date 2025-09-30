using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_biblioteca
{
    internal class Exemplar
    {
        private int tombo;
        private List<Emprestimo> emprestimos = new List<Emprestimo>();

        public int Tombo { get => tombo; set => tombo = value; }
        public List<Emprestimo> Emprestimos { get => emprestimos; set => emprestimos = value; }

        public Exemplar(int tombo)
        {
            Tombo = tombo;
        }

        public bool emprestar()
        {
            return true;
        }

        public bool devolver()
        {
            return true;
        }

        public bool disponivel()
        {
            return true;
        }

        public int qtdeEmprestimos()
        {
            return 0;
        }
    }
}
