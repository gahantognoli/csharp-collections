using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoCollections
{
    class Program
    {
        static Queue<string> pedagio = new Queue<string>();

        static void Main(string[] args)
        {
            Enfileirar("Van");
            Enfileirar("Kombi");
            Enfileirar("Guincho");
            Enfileirar("Pickup");

            Desenfileirar();
            Desenfileirar();
            Desenfileirar();
            Desenfileirar();

            Console.ReadKey();
        }

        private static void Desenfileirar()
        {
            if (pedagio.Any())
            {
                if (pedagio.Peek() == "Guincho")
                {
                    Console.WriteLine($"Guicho está esperando");
                }

                var veiculo = pedagio.Dequeue();

                Console.WriteLine($"{veiculo} saiu da Fila");
                MostraFila();
            }
        }

        private static void Enfileirar(string veiculo)
        {
            Console.WriteLine($"Entrou na fila: {veiculo}");
            pedagio.Enqueue(veiculo);
            MostraFila();
        }

        private static void MostraFila()
        {
            Console.WriteLine("Fila: ");
            foreach (var v in pedagio)
            {
                Console.WriteLine(v);
            }
        }

        private static void Pilha()
        {
            var navegador = new Navegador();
            navegador.NavegarPara("google.com.br");
            navegador.NavegarPara("youtube.com.br");
            navegador.NavegarPara("alura.com.br");

            navegador.Anterior();
            navegador.Anterior();

            navegador.Proximo();

            Console.WriteLine("Página Atual = " + navegador.Atual);
        }

        private static void LinkedList()
        {
            LinkedList<string> dias = new LinkedList<string>();
            var d4 = dias.AddFirst("Quarta");
            var d2 = dias.AddBefore(d4, "Segunda");
            var d3 = dias.AddAfter(d2, "Terça");
            var d6 = dias.AddAfter(d4, "Sexta");
            var d7 = dias.AddAfter(d6, "Sábado");
            var d5 = dias.AddBefore(d6, "Quinta");
            var d1 = dias.AddBefore(d2, "Domingo");

            foreach (var dia in dias)
            {
                Console.WriteLine(dia);
            }

            var quarta = dias.Find("Quarta");
        }

        private static void Dicionarios()
        {
            Curso curso = new Curso("C# Collections", "Gabriel Antognoli");
            curso.AdicionarAula(new Aula("Trabalhando com Listas", 21));
            curso.AdicionarAula(new Aula("Criando uma aula", 20));
            curso.AdicionarAula(new Aula("Modelando com Coleções", 24));

            Aluno aluno1 = new Aluno("Venessa", 34672);
            Aluno aluno2 = new Aluno("Ana", 5617);
            Aluno aluno3 = new Aluno("Rafael", 17645);

            curso.Matricula(aluno1);
            curso.Matricula(aluno2);
            curso.Matricula(aluno3);

            Console.WriteLine("Imprimindo os alunos matriculados");

            foreach (var aluno in curso.Alunos)
            {
                Console.WriteLine(aluno);
            }

            Console.WriteLine($"O aluno 1 {aluno1.Nome} está matriculado?");
            Console.WriteLine(curso.EstaMatriculado(aluno1));

            var aluno4 = new Aluno("Venessa", 34672);
            Console.WriteLine($"O aluno 4 {aluno4.Nome} está matriculado?");
            Console.WriteLine(curso.EstaMatriculado(aluno4));

            Console.WriteLine("aluno 1 == aluno 4?");
            Console.WriteLine(aluno1 == aluno4);

            Console.WriteLine("aluno 1 == aluno 4?");
            Console.WriteLine(aluno1.Equals(aluno4));

            Console.Clear();

            Console.WriteLine("Quem é o Aluno com a Matrícula 5617?");
            var alunoEncontrado = curso.BuscaMatriculado(5617);
            Console.WriteLine(alunoEncontrado);

            Console.WriteLine("Quem é o Aluno com a Matrícula 5618?");
            var alunoEncontrado2 = curso.BuscaMatriculado(5618);
            Console.WriteLine(alunoEncontrado2);

            var novoAluno = new Aluno("Gabriel", 5617);
            //curso.Matricula(novoAluno);

            curso.SubstituiAluno(novoAluno);
            Console.WriteLine("Quem é o Aluno com a Matrícula 5617?");
            var alunoEncontrado3 = curso.BuscaMatriculado(5617);
            Console.WriteLine(alunoEncontrado3);
        }

        private static void Conjuntos()
        {
            //Conjuntos (Sets)
            ICollection<string> alunos = new HashSet<string>();
            alunos.Add("Vanessa");
            alunos.Add("Ana");
            alunos.Add("Rafael");

            Console.WriteLine(string.Join(", ", alunos));

            alunos.Add("Priscila");
            alunos.Add("Rolo");
            alunos.Add("Fabio");

            Console.WriteLine(string.Join(", ", alunos));

            alunos.Remove("Ana");
            alunos.Add("Marcelo");

            Console.WriteLine(string.Join(", ", alunos));

            alunos.Add("Fabio");
            Console.WriteLine(string.Join(", ", alunos));

            List<string> listaAlunos = new List<string>(alunos);
            listaAlunos.Sort();

            Console.WriteLine(string.Join(", ", listaAlunos));
        }

        private static void Listas()
        {
            Curso curso = new Curso("C# Collections", "Gabriel Antognoli");
            curso.AdicionarAula(new Aula("Trabalhando com Listas", 21));

            Imprimir(curso.Aulas);

            curso.AdicionarAula(new Aula("Criando uma aula", 20));
            curso.AdicionarAula(new Aula("Modelando com coleções", 19));

            Imprimir(curso.Aulas);

            List<Aula> aulasCopiadas = new List<Aula>(curso.Aulas);
            aulasCopiadas.Sort();

            Imprimir(aulasCopiadas);

            Console.WriteLine($"Tempo total do curso: {curso.TempoTotal}");

            Console.WriteLine(curso);
        }

        private static void ColecaoReadonly()
        {
            Curso curso = new Curso("C# Collections", "Gabriel Antognoli");
            curso.AdicionarAula(new Aula("Trabalhando com Listas", 21));

            Imprimir(curso.Aulas);
        }

        private static void OrdendandoListas()
        {
            var aulaIntro = new Aula("Introdução às Coleções", 20);
            var aulaModelando = new Aula("Modelando a Classe Aula", 18);
            var aulaSets = new Aula("Trabalhando com Conjuntos", 16);

            var aulas = new List<Aula>()
            {
                aulaIntro, aulaModelando, aulaSets
            };

            Imprimir(aulas);

            aulas.Sort();
            Imprimir(aulas);

            aulas.Sort((a, b) => a.TempoDuracao.CompareTo(b.TempoDuracao));
            Imprimir(aulas);
        }

        private static void OperacoesComListas()
        {
            string aulaIntro = "Introdução às Coleções";
            string aulaModelando = "Modelando a Classe Aula";
            string aulaSets = "Trabalhando com conjuntos";

            List<string> aulas = new List<string>();

            aulas.Add(aulaIntro);
            aulas.Add(aulaModelando);
            aulas.Add(aulaSets);

            Imprimir(aulas);

            Console.WriteLine("A primeira aula é " + aulas.First());
            Console.WriteLine("A ultima aula é " + aulas.Last());

            aulas[0] = "Trabalhando com listas";
            Imprimir(aulas);

            Console.WriteLine("A primeira aula 'Trabalhando é: '" + aulas.First(aula => aula.Contains("Trabalhando")));
            Console.WriteLine("A ultima aula 'Trabalhando é: '" + aulas.Last(aula => aula.Contains("Trabalhando")));
            Console.WriteLine("A ultima aula 'Conclusão é: '" + aulas.FirstOrDefault(aula => aula.Contains("Conclusão")));

            aulas.Reverse();
            aulas.RemoveAt(aulas.Count - 1);
            Imprimir(aulas);

            aulas.Add("Conclusão");
            Imprimir(aulas);

            aulas.Sort();
            Imprimir(aulas);

            var copiaLista = aulas.GetRange(aulas.Count - 2, 2);
            Imprimir(copiaLista);

            var clone = new List<string>(aulas);
            Imprimir(clone);

            clone.RemoveRange(aulas.Count - 2, 2);
            Imprimir(clone);
        }

        private static void Imprimir<T>(IList<T> aulas)
        {
            foreach (var aula in aulas)
            {
                Console.WriteLine(aula);
            }
        }
    }
}
