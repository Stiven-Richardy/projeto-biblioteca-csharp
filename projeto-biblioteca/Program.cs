/*
| Instituto Federal de São Paulo - Campus Cubatão
| Nome: Guilherme Mendes de Sousa - CB3030857
| Nome: Stiven Richardy Silva Rodrigues - CB3030202
| Turma: ADS 471
| 
| Opções no seletor:
| 0. Sair
| 1. Adicionar livro
| 2. Pesquisar livro (sintético)*
| 3. Pesquisar livro (analítico)**
| 4. Adicionar exemplar
| 5. Registrar empréstimo
| 6. Registrar devolução
|
| * . Informar dos dados básicos do livro com as quantidades: total de exemplares, de exemplares disponíveis, de empréstimos e o respectivo percentual de disponibilidade do título
| **. Informando, além dos dados acima, os detalhes dos seus exemplares e respectivos empréstimos
*/

using static System.Net.Mime.MediaTypeNames;

namespace projeto_biblioteca
{
    internal class Program
    {
        public static Livros acervo = new Livros();
        static void Main(string[] args)
        {
            int seletor = -1;
            while (seletor != 0)
            {
                Console.Clear();
                Utils.Titulo("PAINEL PRINCIPAL");
                Console.WriteLine(" 0 - Sair");
                Console.WriteLine(" 1 - Adicionar livro");
                Console.WriteLine(" 2 - Pesquisar livro (Sintético)");
                Console.WriteLine(" 3 - Pesquisar livro (Analítico)");
                Console.WriteLine(" 4 - Adicionar exemplar");
                Console.WriteLine(" 5 - Registrar empréstimo");
                Console.WriteLine(" 6 - Registrar devolução");
                Console.WriteLine(new string('-', 44));
                Console.Write(" Escolha uma opção: ");
                seletor = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida!\n Informe outro número: ");

                switch (seletor)
                {
                    case 0:
                        Console.WriteLine(" Programa finalizado!");
                        break;
                    case 1:
                         adicionarLivro();
                        break;
                    case 2:
                        pesquisarLivroSintetico();
                        break;
                    case 3:
                        pesquisarLivroAnalitico();
                        break;
                    case 4:
                        adicionarExemplar();
                        break;
                    case 5:
                        registrarEmprestimo();
                        break;
                    case 6:
                        registrarDevolucao();
                        break;
                    default:
                        Utils.MensagemErro("Digite um número de 0-5!");
                        break;
                }
            }
        }

        static void adicionarLivro()
        {
            Utils.Titulo("ADICIONAR LIVRO");
            Console.Write("Digite o ISBN do livro: ");
            int isbn = Utils.lerInt(Console.ReadLine(), 0, "\n ISBN inválido. Tente novamente:");
            Console.Write("Digite o Título do livro: ");
            string titulo = Console.ReadLine();
            Console.Write("Digite o nome do Autor do livro: ");
            string autor = Console.ReadLine();
            Console.Write("Digite o nome da Editora do livro: ");
            string editora = Console.ReadLine();
            Livro novoLivro = new Livro(isbn, titulo, autor, editora);
            acervo.adicionar(novoLivro);
        }

        static void pesquisarLivroSintetico()
        {
            Utils.Titulo("PESQUISAR LIVRO (Sintetico)");
            Console.Write("Digite o ISBN do livro: ");
            int isbn = Utils.lerInt(Console.ReadLine(), 0, "\n ISBN inválido. Tente novamente:");
            Livro livroPesquisado = acervo.pesquisar(new Livro(isbn));
            if (livroPesquisado != null)
            {
                Console.WriteLine($"DADOS DO LIVRO: \n" +
                    $"Titulo: {livroPesquisado.Titulo}" + "\n" +
                    $"Autor: {livroPesquisado.Autor}" + "\n" +
                    $"Editora: {livroPesquisado.Editora}" + "\n" +
                    $"Exemplares: {livroPesquisado.qtdeExemplares()}" + "\n" +
                    $"Exemplares disponíveis: {livroPesquisado.qtdeDisponiveis()}" + "\n" +
                    $"Emprestimos: {livroPesquisado.qtdeEmprestimos()}" + "\n" +
                    $"Percentual de disponibilidade: {livroPesquisado.percDisponibilidade()}");
            }
            else
                Utils.MensagemErro("Livro não encontrado.");
        }

        static void pesquisarLivroAnalitico()
        {
            Utils.Titulo("PESQUISAR LIVRO (Sintetico)");
            Console.Write("Digite o ISBN do livro: ");
            int isbn = Utils.lerInt(Console.ReadLine(), 0, "\n ISBN inválido. Tente novamente:");
            Livro livroPesquisado = acervo.pesquisar(new Livro(isbn));
            if (livroPesquisado != null)
            {
                Console.WriteLine($"DADOS DO LIVRO: \n" +
                    $"Titulo: {livroPesquisado.Titulo}" + "\n" +
                    $"Autor: {livroPesquisado.Autor}" + "\n" +
                    $"Editora: {livroPesquisado.Editora}" + "\n" +
                    $"Exemplares: {livroPesquisado.qtdeExemplares()}" + "\n" +
                    $"Exemplares disponíveis: {livroPesquisado.qtdeDisponiveis()}" + "\n" +
                    $"Emprestimos: {livroPesquisado.qtdeEmprestimos()}" + "\n" +
                    $"Percentual de disponibilidade: {livroPesquisado.percDisponibilidade()}");
                Console.WriteLine("EXEMPLARES: ");
                foreach (Exemplar e in livroPesquisado.Exemplares)
                {
                    Console.WriteLine($"Tombo: {e.Tombo} \nDados de empréstimos:");
                    foreach(Emprestimo emp in e.Emprestimos)
                    {
                        if (emp.DtEmprestimo != null) 
                        {
                            Console.WriteLine($"Emprestado em {emp.DtEmprestimo}");
                        }
                        if (emp.DtDevolucao != null)
                        {
                            Console.WriteLine($"Devolvido em {emp.DtDevolucao}");
                        }
                    }
                }
            }
            else
                Utils.MensagemErro("Livro não encontrado.");
        }
        static void adicionarExemplar()
        {
            Utils.Titulo("ADICIONAR EXEMPLAR");
            Console.Write("Digite o ISBN do livro: ");
            int isbn = Utils.lerInt(Console.ReadLine(), 0, "\n ISBN inválido. Tente novamente:");
            Livro livroPesquisado = acervo.pesquisar(new Livro(isbn));
            if (livroPesquisado != null)
            {
                Console.Write("Digite o tombo do exemplar: ");
                int tombo = Utils.lerInt(Console.ReadLine(), 0, "\n Tombo inválido. Tente novamente:");
                Exemplar exemplar = new Exemplar(tombo);
                livroPesquisado.adicionarExemplar(exemplar);
            }
            else
                Utils.MensagemErro("Livro não encontrado.");
        }

        static void registrarEmprestimo()
        {
            Utils.Titulo("EMPRESTAR EXEMPLAR");
            Console.Write("Informe o título: ");
            string titulo = Console.ReadLine();
            Livro livroPesquisado = acervo.Acervo.Find(l => l.Titulo == titulo);
            Exemplar exempDisponivel = livroPesquisado.Exemplares.Find(e => e.disponivel());
            bool emprestou;
            if (exempDisponivel != null)
            {
                emprestou = exempDisponivel.emprestar();
                if (emprestou)
                {
                    Utils.MensagemSucesso($"Livro emprestado. Data do emprestimo: {DateTime.Now}");
                }
                else
                {
                    Utils.MensagemErro("Não foi possível emprestar o livro");
                }
            }
            else 
                Utils.MensagemErro("Nenhum exemplar disponível");
        }

        static void registrarDevolucao()
        {
            Utils.Titulo("DEVOLVER EXEMPLAR");
            Console.Write("Informe o titulo do livro:");
            string titulo = Console.ReadLine();
            Livro livroPesquisado = acervo.Acervo.Find(l => l.Titulo == titulo);
            if (livroPesquisado != null)
            {
                Console.Write("Informe o tombo do exemplar:");
                int tombo = Utils.lerInt(Console.ReadLine(), 0, "Tombo inválido. Tente novamente.");
                Exemplar exmp = livroPesquisado.Exemplares.Find(e => e.Tombo == tombo);
                bool devolveu;
                if (exmp != null)
                {
                    devolveu = exmp.devolver();
                    if (devolveu)
                    {
                        Utils.MensagemSucesso($"Livro devolvido em {DateTime.Now}");
                    }
                }
                else
                {
                    Utils.MensagemErro("Emprestimo não consta na base de dados");
                }
                
            }
            else
                Utils.MensagemErro("Livro não encontrado");

        }
    }
    
}
