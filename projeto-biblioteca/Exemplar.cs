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
            bool podeEmprestar = this.disponivel();
            if (podeEmprestar)
            {
                Emprestimo emprestimo = new Emprestimo(DateTime.Now);
                Emprestimos.Add(emprestimo);
            }
            return podeEmprestar;
        }

        public bool devolver()
        {
            bool devolveu = false;
            Emprestimo emprestimo = Emprestimos.Find(e => e.DtDevolucao == null);
            if (emprestimo != null)
            {
                emprestimo.DtDevolucao = DateTime.Now;
                devolveu = true;
            }
            return devolveu;
        }

        public bool disponivel()
        {
            Emprestimo emprestimoAtivo = this.Emprestimos.Find(e => e.DtDevolucao == null);
            return emprestimoAtivo == null;
        }

        public int qtdeEmprestimos()
        {
            return Emprestimos.Count();
        }
    }
}
