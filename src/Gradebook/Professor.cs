using System;
using System.Collections.Generic;

namespace Gradebook
{

    public class Professor
    {

        public ProfessorArea SelecionarProfesor()
        {
            var prof = new ProfessorArea();
            var professores = new List<string> { "Mauro", "Paula", "Rodrigo", "Ricardo", "Rafael", "Diego", "Marcela", "Jaqueline" };
            var random = new Random();


            prof.selecionado = random.Next(professores.Count);

            prof.nome = professores[prof.selecionado];

            if (prof.selecionado <= 3)
            {

                prof.area = "Exatas";

            }
            else
            {
                prof.area = "Humanas";
            }

            return prof;



        }
    }


}