using System;

namespace OOP_project_idf
{
    internal class Hermes460_Zik_Drone : StrikeUni
    {
        private string nameForValidity;
        private int numberOfHits;
        private int fuel;
        private string efficiency;
        private string bomb;

        public Hermes460_Zik_Drone()
        {
            nameForValidity = "Hermes460 {Zik} Drone";
            numberOfHits = 3;
            fuel = 100;
            efficiency = "people, vehicles";
            bomb = "personnel or armored vehicles";
        }

        public void Strike()
        {
            Console.WriteLine($"🎯 {nameForValidity} Strike initiated!");
            Console.WriteLine($"   Hits: {numberOfHits}, Fuel: {fuel}%, Target: {efficiency}");
            Console.WriteLine($"   Bomb: {bomb}");
            
            // Reduce hits and fuel after strike
            if (numberOfHits > 0) numberOfHits--;
            if (fuel > 15) fuel -= 15;
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