using System;
using System.Collections.Generic;

namespace Gradebook{


    public class AtribuirNome
    {
        public AtribuirNome(string name)
        {
            Name = name;
            
        }
        public string Name
        {
            get;
            set;
        }
    }

    public abstract class BookBase : AtribuirNome, IBook
    {
        public BookBase(string name) : base(name)
        {

        }
        public virtual event NotaAdicionadaDelegate NotaAdicionada;

        public virtual Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }

        public abstract void AddNota(double nota);
       
    }

    public interface IBook 
    {
        void AddNota(double nota);
        Statistics GetStatistics();
        string Name { get;}
        event NotaAdicionadaDelegate NotaAdicionada;


    }
}