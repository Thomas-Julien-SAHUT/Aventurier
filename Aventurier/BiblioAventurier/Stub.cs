using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BiblioAventurier
{
    public class Stub
    {
        /// <summary>
        /// On récupère le plateau contenu dans le fichier carte.txt.
        /// On retourne une liste de cases.
        /// </summary>
        /// <returns></returns>
        public List<Case> InitList()
        {
            List<Case> cases = new List<Case>();

            string startupPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "carte.txt");

            int x;
            int y = 0;

            foreach (string line in System.IO.File.ReadLines(startupPath))
            {
                x = 0;
                foreach (char ch in line)
                {
                    if (ch == '#')
                        cases.Add(new Case(x, y, true, false, false));
                    else
                        cases.Add(new Case(x, y, false, false, false));
                    x++;
                }
                y++;
            }

            return cases;
        }
    }
}
