using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {

                System.Console.WriteLine("Digite um nome para atribuir ao livro:");
                string nome = Console.ReadLine();

                if (string.IsNullOrEmpty(nome))
                {
                    System.Console.WriteLine("Um nome é necessário para criar o livro!!");

                }
                else
                {
                    var book = new InMemoryBook(nome);

                    book.NotaAdicionada += LogNotaAdicionada;
                    EntradaNota(book);

                    var result = book.GetStatistics();
                    var professor = new Professor();

                    var selecao = professor.SelecionarProfessor();


                    System.Console.WriteLine($"Nome: {book.Name}\nProfessor(a): {selecao.nome}\nÁrea: {selecao.area}\nMaior nota: {result.alta}\nMenor nota:{result.baixa}\nMédia geral:{result.media:N1}\nLetra atribuida: {result.letra}");

                    break;

                }

            }

        }

        private static void EntradaNota(IBook book)
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
                    book.AddNota(nota);
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