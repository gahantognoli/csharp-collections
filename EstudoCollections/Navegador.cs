using System;
using System.Collections.Generic;
using System.Linq;

namespace EstudoCollections
{
    public class Navegador
    {
        private readonly Stack<string> historicoAnterior;
        private readonly Stack<string> historicoProximo;

        public string Atual { get; private set; } = "vazia";

        public Navegador()
        {
            Console.WriteLine($"Página atual: {Atual}");
            historicoAnterior = new Stack<string>();
            historicoProximo = new Stack<string>();
        }

        public void NavegarPara(string url)
        {
            historicoAnterior.Push(Atual);
            Atual = url;
        }

        internal void Proximo()
        {
            if (historicoAnterior.Any())
            {
                historicoAnterior.Push(Atual);
                Atual = historicoProximo.Pop();
            }
        }

        public void Anterior()
        {
            if (historicoAnterior.Any())
            {
                historicoProximo.Push(Atual);
                Atual = historicoAnterior.Pop();
            }
        }
    }
}
