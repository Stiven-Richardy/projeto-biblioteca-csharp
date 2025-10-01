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
                        // pesquisarLivroAnalitico();
                        break;
                    case 4:
                        // adicionarExemplar();
                        break;
                    case 5:
                        // registrarEmprestimo();
                        break;
                    case 6:
                        // registrarDevolucao();
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
            Console.Write(" Digite o ISBN do livro: ");
            int isbn = Utils.lerInt(Console.ReadLine(), 0, "\n ISBN inválido. Tente novamente:");
            Console.Write(" Digite o Título do livro: ");
            string titulo = Console.ReadLine();
            Console.Write(" Digite o nome do Autor do livro: ");
            string autor = Console.ReadLine();
            Console.Write(" Digite o nome da Editora do livro: ");
            string editora = Console.ReadLine();
            Livro novoLivro = new Livro(isbn, titulo, autor, editora);
            acervo.adicionar(novoLivro);
        }

        static void pesquisarLivroSintetico()
        {
            Utils.Titulo("PESQUISAR LIVRO (SINTÉTICO)");
            Console.Write(" Digite o ISBN do livro: ");
            int isbn = Utils.lerInt(Console.ReadLine(), 0, "\n ISBN inválido. Tente novamente:");
            Livro livroPesquisado = new Livro(isbn);
            Livro livroEncontrado = acervo.pesquisar(livroPesquisado);
            if (livroEncontrado != null)
            {
                Utils.Titulo("PESQUISAR LIVRO (SINTÉTICO)");
                Console.WriteLine($" ISBN: {livroEncontrado.Isbn}" +
                    $"\n Título: {livroEncontrado.Titulo}" +
                    $"\n Autor: {livroEncontrado.Autor}" +
                    $"\n Editora: {livroEncontrado.Editora}" +
                    $"\n Total de exemplares: {livroEncontrado.qtdeExemplares()}" +
                    $"\n Total de disponíveis: {livroEncontrado.qtdeDisponiveis()}" +
                    $"\n Total de empréstimos: {livroEncontrado.qtdeEmprestimos()}" +
                    $"\n Percentual de disponibilidade: {livroEncontrado.percDisponibilidade()}%");
                Utils.MensagemSucesso("Livro encontrado.");
            }
            else
                Utils.MensagemErro("Livro não encontrado.");
        }
    }
}
