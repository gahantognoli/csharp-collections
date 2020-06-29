using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoCollections
{
    public class Aluno
    {
        public Aluno(string nome, int matricula)
        {
            Nome = nome;
            Matricula = matricula;
        }

        public string Nome { get; set; }
        public int Matricula { get; set; }

        public override string ToString()
        {
            return $"{Nome} - {Matricula}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return Nome.Equals((obj as Aluno).Nome);
        }

        public override int GetHashCode()
        {
            return Nome.GetHashCode();
        }
    }
}
