using System;

namespace OOP_project_idf
{
    internal class M109Artillery : StrikeUni
    {
        private string nameForValidity;
        private int numberOfHits;
        private int fuel;
        private string efficiency;
        private string pylot;
        private string bomb;

        public M109Artillery()
        {
            nameForValidity = "M109 Artillery";
            numberOfHits = 40;
            fuel = 100;
            efficiency = "open spaces";
            bomb = "Explosive shells";
        }

        public void Strike()
        {
            Console.WriteLine($"💥 {nameForValidity} Strike initiated!");
            Console.WriteLine($"   Hits: {numberOfHits}, Fuel: {fuel}%, Target: {efficiency}");
            Console.WriteLine($"   Bomb: {bomb}");
            
            // Reduce hits and fuel after strike
            if (numberOfHits > 0) numberOfHits--;
            if (fuel > 5) fuel -= 5;
        }

        public int setNumberOfHits(int numberOfHits)
        {
            this.numberOfHits = numberOfHits;
            return this.numberOfHits;
        }

        public int NumberOfHits()
        {
            return numberOfHits;
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