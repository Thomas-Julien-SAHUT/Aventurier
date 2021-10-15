using System;
using System.Collections.Generic;

namespace BiblioAventurier
{

    public class Plateau
    {
         private List<Case> myCases = new List<Case>();

         private Stub stub = new Stub();

        public Plateau()
        {
            myCases = stub.InitList();
        }

        /// <summary>
        /// Cette méthode permet d'afficher le plateau dans l'invite de commande
        /// </summary>
        public void AffichePlateau()
        {
            List<string> lines = new List<string>();

            for (int i = 0; i < 20; i++)
            {
                string line = "";
                foreach (Case c in myCases)
                {
                    if (c.Y == i)
                    {
                        if (c.Locked)
                            line += "#";
                        else if (c.Aventurier)
                            line += "@";
                        else if (c.Used)
                            line += "-";
                        else
                            line += " ";
                    }
                }
                lines.Add(line);
            }

            foreach (string line in lines)
                Console.WriteLine(line);
        }

        /// <summary>
        /// Application des consignes en fonction de la position initiale de l'aventurier et des directions données.
        /// S'il est impossible de placer l'aventurier ou de le déplacer on retourne un false. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="directions"></param>
        /// <returns></returns>
        public bool Consigne(int x, int y, string directions)
        {
            Console.WriteLine("Consigne : directions = "+ directions);

            foreach (Case c in myCases)
            {
                if (c.X == x && c.Y == y)
                {
                    if (c.Locked)
                    {
                        Console.WriteLine("Il est impossible de placer l'aventurier sur cette case elle est verrouillée.");
                        return false;
                    }
                    else
                    {
                        c.Used = true;
                        c.Aventurier = true;
                        Console.WriteLine("Aventurier placé");
                        break;
                    }
                }
            }

            if (Deplacement(directions))
            {
                foreach (Case c in myCases)
                {
                    if (c.X == 9 && c.Y == 2 && c.Aventurier)
                        Console.WriteLine("L'aventurier est arriver à la destination de la consigne : position " + c.X + "," + c.Y);
                }
                myCases = stub.InitList();
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Action du déplacement de l'aventurier.
        /// Retourne false si l'aventurier ne peut pas se déplacer via les directions données en paramètre.
        /// </summary>
        /// <param name="directions"></param>
        /// <returns></returns>
        private bool Deplacement(string directions)
        {
            int cpt = 1;
            bool validation = false;
            Case caseAventurier = new Case();

            foreach (Case c in myCases)
            {
                if (c.Aventurier)
                {
                    caseAventurier = c;
                    c.Aventurier = false;
                    break;
                }
            }

            foreach (char ch in directions)
            {
                if (ch == 'S')
                {
                    foreach (Case c in myCases)
                    {
                        if (c.X == caseAventurier.X && c.Y == caseAventurier.Y + 1)
                        {
                            c.Aventurier = true;
                            c.Used = true;
                            caseAventurier = c;
                            validation = true;

                            break;
                        }
                    }
                }
                else if (ch == 'N')
                {
                    foreach (Case c in myCases)
                    {
                        if (c.X == caseAventurier.X && c.Y == caseAventurier.Y - 1)
                        {
                            c.Aventurier = true;
                            c.Used = true;
                            caseAventurier = c;
                            validation = true;

                            break;
                        }
                    }
                }
                else if (ch == 'O')
                {
                    foreach (Case c in myCases)
                    {
                        if (c.X == caseAventurier.X - 1 && c.Y == caseAventurier.Y)
                        {
                            c.Aventurier = true;
                            c.Used = true;
                            caseAventurier = c;
                            validation = true;

                            break;
                        }
                    }
                }
                else
                {
                    foreach (Case c in myCases)
                    {
                        if (c.X == caseAventurier.X + 1 && c.Y == caseAventurier.Y)
                        {
                            c.Aventurier = true;
                            c.Used = true;
                            caseAventurier = c;
                            validation = true;

                            break;
                        }
                    }
                }

                if (cpt < directions.Length)
                {
                    if (validation)
                    {
                        foreach (Case c in myCases)
                        {
                            if (c.Aventurier)
                            {
                                caseAventurier = c;
                                c.Aventurier = false;
                                validation = false;
                                break;
                            }
                        }
                        cpt++;
                    }
                    else
                        return false;
                }
            }
            AffichePlateau();
            return true;
        }
    }
}
