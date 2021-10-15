using System;

namespace BiblioAventurier
{
    public class Case
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Locked { get; set; }
        public bool Aventurier { get; set; }
        public bool Used { get; set; }
        public Case(int x, int y, bool locked, bool used, bool aventurier)
        {
            X = x;
            Y = y;
            Locked = locked;
            Used = used;
            Aventurier = aventurier;
        }

        public Case()
        {
        }
    }
}
