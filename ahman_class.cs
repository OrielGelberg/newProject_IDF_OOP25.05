using System;
using System.Collections.Generic;

namespace OOP_project_idf
{
    internal class Ahman
    {
        Dictionary<string, List<Dictionary<string, string>>> terrorists = new Dictionary<string, List<Dictionary<string, string>>>();
        Hamas hamas;
        List<string> terorost;

        public Ahman(Hamas hamasInstance)
        {
            this.hamas = hamasInstance; // Use the same Hamas instance
        }

        public void ahman(string nameTerrorist, string location)
        {
            DateTime time = DateTime.Now;

            Dictionary<string, string> report = new Dictionary<string, string>
            {
                { "location", location },
                { "date", time.ToString("HH:mm dd/MM/yyyy") }
            };

            if (!terrorists.ContainsKey(nameTerrorist))
            {
                terrorists[nameTerrorist] = new List<Dictionary<string, string>>();
            }

            terrorists[nameTerrorist].Add(report);
        }

        public void add()
        {
            string loc = "home";
            terorost = hamas.getLid();
            foreach (string ter in terorost)
            {
                ahman(ter, loc);
            }
        }

        public string alerts()
        {
            string name = "";
            int max = 0;

            foreach (var kvp in terrorists)
            {
                int reportCount = kvp.Value.Count;
                if (reportCount > max)
                {
                    max = reportCount;
                    name = kvp.Key;
                }
            }

            return $"Terrorist with most reports - Name: {name}, Reports: {max}";
        }

        public void showAllTerrorists()
        {
            Console.WriteLine("\nALL TERRORISTS IN DATABASE ");
            var allTerrorists = hamas.getTerrorist();
            
            if (allTerrorists.Count == 0)
            {
                Console.WriteLine("No terrorists found in database.");
                return;
            }

            for (int i = 0; i < allTerrorists.Count; i++)
            {
                var terrorist = allTerrorists[i];
                Console.WriteLine($"{i + 1}. Name: {terrorist.get_Name()}, ID: {terrorist.get_Id()}, Rank: {terrorist.get_Rank()}");
                Console.WriteLine($"   Weapons: {string.Join(", ", terrorist.GetWeapons())}");
                Console.WriteLine($"   Danger Level: {terrorist.QualityGoal()}");
                
                // Show intelligence reports if any
                if (terrorists.ContainsKey(terrorist.get_Name()))
                {
                    Console.WriteLine($"   Intelligence Reports: {terrorists[terrorist.get_Name()].Count}");
                }
                else
                {
                    Console.WriteLine("   Intelligence Reports: 0");
                }
                Console.WriteLine();
            }
        }

        public void removeFromIntelligence(string terroristName)
        {
            if (terrorists.ContainsKey(terroristName))
            {
                terrorists.Remove(terroristName);
                Console.WriteLine($"Intelligence reports for {terroristName} have been archived.");
            }
        }
    }
}