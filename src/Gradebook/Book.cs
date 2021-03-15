using System;
using System.Collections.Generic;

namespace Gradebook
{

    public delegate void NotaAdicionadaDelegate(object sender, EventArgs args);

    public class NomesAtribuidos
    {
        public NomesAtribuidos(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }


    public class Book : NomesAtribuidos
    {
        public Book(string name) : base(name)
        {

            grades = new List<double>();
            Name = name;
        }

        public void addnota(double nota)
        {
            if (nota <= 100 && nota >= 0)
            {
                grades.Add(nota);
                if (NotaAdicionada != null)
                {
                    NotaAdicionada(this, new EventArgs());
                }
            }
            else
            {
                System.Console.WriteLine($"A nota {nota} não é válida");
            }
        }

        public event NotaAdicionadaDelegate NotaAdicionada;

        public Statistics gerar_resultado()
        {
            var resultado = new Statistics();
            resultado.media = 0;
            resultado.alta = double.MinValue;
            resultado.baixa = double.MaxValue;
            for (var i = 0; i < grades.Count; i++)
            {
                resultado.media += grades[i];
                resultado.alta = Math.Max(grades[i], resultado.alta);
                resultado.baixa = Math.Min(grades[i], resultado.baixa);

            }




            resultado.media = resultado.media / grades.Count;


            switch (resultado.media)
            {
                case var d when d >= 90:
                    resultado.letra = 'A';
                    break;

                case var d when d >= 80:
                    resultado.letra = 'B';
                    break;

                case var d when d >= 70:
                    resultado.letra = 'C';
                    break;

                case var d when d >= 60:
                    resultado.letra = 'D';
                    break;

                default:
                    resultado.letra = 'F';
                    break;

            }
            if (grades.Count == 0)
            {

                System.Console.WriteLine("Nenhuma nota foi adicionada");

                resultado.alta = 0;
                resultado.baixa = 0;
                resultado.media = 0;

                return resultado;
            }
            else
            {
                return resultado;
            }




        }
        public List<double> grades;


    }
}