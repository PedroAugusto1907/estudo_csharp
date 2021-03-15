using System;
using Gradebook;
using Xunit;

namespace Gradebook.Tests
{

    public delegate string LogDelegate(string log);
    public class TesteTipos
    {
        int contador = 0;
        [Fact]
        public void DelegateApontaOutraMetodo()
        {
            LogDelegate log = Mensagem;
            log += Mensagem;
            log += Contador;

            var result = log("OLA!!");
            Assert.Equal(3, contador);
        }

        string Mensagem(string msg)
        {
            contador++;
            return msg;
        }

        string Contador(string cnt)
        {
            contador++;
            return cnt;
        }


        [Fact]
        public void TesteCalculoNotas()
        {
            var livro1 = new Book("Livro Pedro");
            var livro2 = new Book("Livro Ricardo");

            Assert.Equal("Livro Pedro", livro1.Name);
            Assert.Equal("Livro Ricardo", livro2.Name);

        }

        [Fact]
        public void TesteMudarNome()
        {
            var livro1 = new Book("Livro Pedro");

            SetName(livro1, "Livro João");



            Assert.Equal(livro1.Name, "Livro João");

        }


        [Fact]
        public void PassagemPorReferencia()
        {
            var livro1 = new Book("Livro Pedro");

            referencia(ref livro1, "Livro Paulo");

            Assert.Equal(livro1.Name, "Livro Paulo");

        }

        private void referencia(ref Book livro1, string name)
        {

            livro1 = new Book(name);

        }


        private void SetName(Book livro, string name)
        {

            livro.Name = name;
        }


        [Fact]
        public void Inteiro()
        {

            var x = GetInt();


            SetInt(ref x);

            Assert.Equal(x, 42);

        }

        public int GetInt()
        {

            return 3;
        }

        public void SetInt(ref int x)
        {

            x = 42;
        }







    }


}
