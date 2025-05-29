using System;

namespace OOP_project_idf
{
    internal class F16FighterJet : StrikeUni
    {
        private string nameForValidity;
        private int numberOfHits;
        private int fuel;
        private string efficiency;
        private string pylot;
        private string bomb;

        public F16FighterJet()
        {
            nameForValidity = "F16FighterJet";
            numberOfHits = 8;
            fuel = 100;
            efficiency = "building";
            pylot = " Operated by a pilot";
            bomb = " 0.5 ton or 1 ton";
        }

        public void Strike()
        {
            Console.WriteLine($"🚀 {nameForValidity} Strike initiated!");
            Console.WriteLine($"   Hits: {numberOfHits}, Fuel: {fuel}%, Target: {efficiency}");
            Console.WriteLine($"   Bomb: {bomb}");
            
            // Reduce hits and fuel after strike
            if (numberOfHits > 0) numberOfHits--;
            if (fuel > 10) fuel -= 10;
        }

        public int NumberOfHits()
        {
            return numberOfHits;
        }

        public int setNumberOfHits(int numberOfHits)
        {
            this.numberOfHits = numberOfHits;
            return this.numberOfHits;
        }

        public int Fuel()
        {
            return fuel;
        }

        public string Efficiency()
        {
            return efficiency;
        }

        public string NameForValidity()
        {
            return nameForValidity;
        }

        public string Bomb()
        {
            return bomb;
        }
    }
}