using System;
using Gradebook;
using Xunit;

namespace Gradebook.Tests
{

    public class TesteAddNotas
    {

        public void Notas()
        {

            var livro1 = new InMemoryBook("Livro Teste");

            livro1.AddNota(105);



        }

    }
}