using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EstudoCollections
{
    public class Curso
    {
        public Curso(string nome, string instrutor)
        {
            Nome = nome;
            Instrutor = instrutor;
            aulas = new List<Aula>();
            alunos = new HashSet<Aluno>();
            dicionarioAlunos = new Dictionary<int, Aluno>();
        }

        public string Nome { get; set; }
        public string Instrutor { get; set; }

        private IList<Aula> aulas;

        public IList<Aula> Aulas
        {
            get
            {
                return new ReadOnlyCollection<Aula>(aulas);
            }
        }

        public int TempoTotal
        {
            get
            {
                return aulas.Sum(aula => aula.TempoDuracao);
            }
        }

        private ISet<Aluno> alunos;

        public IList<Aluno> Alunos
        {
            get { return new ReadOnlyCollection<Aluno>(alunos.ToList()); }
        }

        private IDictionary<int, Aluno> dicionarioAlunos;
        public IDictionary<int, Aluno> DicionarioAlunos
        {
            get
            {
                return new ReadOnlyDictionary<int, Aluno>(dicionarioAlunos);
            }
        }

        public void Matricula(Aluno aluno)
        {
            alunos.Add(aluno);
            dicionarioAlunos.Add(aluno.Matricula, aluno);
        }

        public void AdicionarAula(Aula aula)
        {
            aulas.Add(aula);
        }

        public bool EstaMatriculado(Aluno aluno)
        {
            return alunos.Contains(aluno);
        }

        public override string ToString()
        {
            return $"Curso: {Nome} - Instrutor: {Instrutor} - Tempo Total: {TempoTotal} - Aulas:\n {string.Join("\n", aulas)}";
        }

        public Aluno BuscaMatriculado(int matricula)
        {
            Aluno aluno = null;
            dicionarioAlunos.TryGetValue(matricula, out aluno);
            return aluno;
        }

        public void SubstituiAluno(Aluno aluno)
        {
            dicionarioAlunos[aluno.Matricula] = aluno;
        }
    }
}
