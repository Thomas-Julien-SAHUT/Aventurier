using BiblioAventurier;
using System;

namespace AppliAventurier
{
    class Program
    {
        static private Plateau plateau = new Plateau();

        static void Main(string[] args)
        {
            plateau.AffichePlateau();
            Console.WriteLine();

            // 1ère consigne
            string directions = "SSSSEEEEEENN";
            plateau.Consigne(3,0,directions);
            Console.WriteLine();

            // 2ème consigne
            directions = "OONOOOSSO";
            plateau.Consigne(6,9,directions);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
