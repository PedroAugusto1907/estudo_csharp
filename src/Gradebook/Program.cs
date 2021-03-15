using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Digite um nome para atribuir ao livro:");
            string nome = Console.ReadLine();
            var book = new Book(nome);
            book.NotaAdicionada += LogNotaAdicionada;

            EntradaNota(book);

            var result = book.gerar_resultado();

            
            System.Console.WriteLine($"Maior nota: {result.alta}\nMenor nota:{result.baixa}\nMédia geral:{result.media:N1}\nLetra atribuida: {result.letra}");

        }

        private static void EntradaNota(Book book)
        {
            while (true)
            {

                System.Console.WriteLine("Digite uma nota ou Q para finalizar o programa:");
                var leitura = Console.ReadLine();

                if (leitura == "Q" || leitura == "q")
                {
                    System.Console.WriteLine("Programa finalizado");
                    break;
                }

                try
                {
                    var nota = double.Parse(leitura);
                    book.addnota(nota);
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);

                }
                finally
                {
                    System.Console.WriteLine("______________________");
                }

            }
        }

        static void LogNotaAdicionada(object sender, EventArgs args)
        {
            System.Console.WriteLine("Uma nota foi adiconada");
        }
    }
}