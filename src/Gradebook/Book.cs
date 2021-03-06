using System;
using System.Collections.Generic;
using System.IO;

namespace Gradebook
{

    public delegate void NotaAdicionadaDelegate(object sender, EventArgs args);

    public class DiskBook : BookBase
    {
        public DiskBook(string name) : base(name)
        {

        }
        public override event NotaAdicionadaDelegate NotaAdicionada;

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }

        public override void AddNota(double nota)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(nota);
            }
        }
        
          
    }

    public class InMemoryBook : BookBase
    {
        
        public InMemoryBook(string name) : base(name)
        {

            grades = new List<double>();
            Name = name;

            var disk = new DiskBook(Name);
        }

    

        public override void AddNota(double nota)
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

        public override event NotaAdicionadaDelegate NotaAdicionada;

        public override Statistics GetStatistics()
        {
            var resultado = new Statistics();
            
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