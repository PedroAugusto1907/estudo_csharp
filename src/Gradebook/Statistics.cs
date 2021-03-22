namespace Gradebook
{

    public class Statistics
    {

        public double media;
        public double alta;
        public double baixa;

        public char letra;

        public Statistics()
        {
            media = 0;
            alta = double.MinValue;
            baixa = double.MaxValue;
        }
    }
}