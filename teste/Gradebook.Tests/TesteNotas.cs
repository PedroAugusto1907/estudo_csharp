using System;
using Gradebook;
using Xunit;

namespace Gradebook.Tests
{
    public class TesteNotas
    {
        [Fact]
        public void TesteCalculoNotas()
        {
            //Passo 1 / Organizar dados

            var book = new Book("");
            book.addnota(45.2);
            book.addnota(57.8);
            book.addnota(78.2);


            //Passo 2 / Processamento dos dados  

            var result = book.gerar_resultado();



            //Passo 3 / Resultado esperado

            Assert.Equal(78.2, result.alta);
            Assert.Equal(60.4, result.media);
            Assert.Equal(45.2, result.baixa);
            Assert.Equal('D', result.letra);

        }
    }
}
