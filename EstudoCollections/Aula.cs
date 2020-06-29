using System;

namespace EstudoCollections
{
    public class Aula : IComparable
    {
        public Aula(string titulo, int tempoDuracao)
        {
            Titulo = titulo;
            TempoDuracao = tempoDuracao;
        }

        public string Titulo { get; set; }
        public int TempoDuracao { get; set; }

        public int CompareTo(object obj)
        {
            var aula = obj as Aula;
            return this.Titulo.CompareTo(aula.Titulo);
        }

        public override string ToString()
        {
            return $"{Titulo} - {TempoDuracao}";
        }

        
    }
}
