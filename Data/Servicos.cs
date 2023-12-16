using System;
using System.Collections.Generic;

namespace BurroCartas.Data
{
    public class Servicos
    {
        private readonly string[] Simbolos = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private readonly string[] Tipos = { "♠", "♦", "♣", "♥" };

        public List<Carta> GetCartas()
        {
            List<Carta> cartas = new List<Carta>();
            int i = 1;
            //A,2,3,4,5,6,7,8,9,10,J,Q,K
            foreach (var simbolo in Simbolos)
            {
                foreach (var tipo in Tipos)
                {
                    cartas.Add(new() { Id = i, Simbolo = simbolo, Tipo = tipo, Cor = (i % 2 == 0 ? "red" : "black") });
                    i++;
                }
            }
            return cartas;
        }

        public List<Carta> Baralhar() { 
            // Embaralhar a lista
            List<Carta> Cartas = GetCartas();
            Random rand = new Random();
            int n = Cartas.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                Carta value = Cartas[k];
                Cartas[k] = Cartas[n];
                Cartas[n] = value;
            }
            return Cartas;
        }

        public List<List<Carta>> DividirPara(int Num, List<Carta> Baralho)
        {
            List<List<Carta>> Cartas = new List<List<Carta>>();

            int sobra = Baralho.Count % Num, paraDividir;
            paraDividir = Baralho.Count - sobra;

            Cartas.Add(Dividir(sobra, Baralho));

            while (Baralho.Count > 0)
            {
                var result = Dividir((paraDividir / Num), Baralho);
                Cartas.Add(result);
            }
            return Cartas;
        }

        public List<List<Carta>> DividirPara(List<Carta> Baralho)
        {
            List<List<Carta>> Cartas = new List<List<Carta>>();

            var result = Dividir(8, Baralho);
            Cartas.Add(result);

            result = Dividir(8, Baralho);
            Cartas.Add(result);

            Cartas.Insert(0, Baralho);

            return Cartas;
        }

        private List<Carta> Dividir(int Num, List<Carta> Baralho)
        {
            List<Carta> cartas = new List<Carta>();
            while (Num > 0)
            {
                cartas.Add(Baralho.ElementAtOrDefault(0));
                Baralho.RemoveAt(0);
                Num--;
            }
            return cartas;
        }
    }
}