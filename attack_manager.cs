using System;
using System.Text;

namespace OOP_project_idf
{
    internal class attackManager
    {
        Hermes460_Zik_Drone hermes460_Zik_Drone = new Hermes460_Zik_Drone();
        F16FighterJet f16FighterJet = new F16FighterJet();
        M109Artillery m109Artillery = new M109Artillery();

        public void statushermes460_Zik_Drone()
        {
            hermes460_Zik_Drone.Strike();
            f16FighterJet.Strike();
            m109Artillery.Strike();
        }

        public void executeStrike()
        {
            Console.WriteLine("Executing coordinated strike:");
            hermes460_Zik_Drone.Strike();
            f16FighterJet.Strike();
            m109Artillery.Strike();
        }

        public void executeTargetedStrike(Terrorist target)
        {
            Console.WriteLine($"\n TARGETED STRIKE INITIATED ");
            Console.WriteLine($"Target: {target.get_Name()} (ID: {target.get_Id()})");
            Console.WriteLine($"Danger Level: {target.QualityGoal()}");
            Console.WriteLine($"Rank: {target.get_Rank()}");
            Console.WriteLine($"Weapons: {string.Join(", ", target.GetWeapons())}");
            Console.WriteLine();

            // Select best unit for the strike
            StrikeUni selectedUnit = selectBestUnitForTerrorist(target);
            Console.WriteLine($"Selected Strike Unit: {selectedUnit.NameForValidity()}");
            Console.WriteLine();

            // Execute the strike
            selectedUnit.Strike();
            
            Console.WriteLine();
            Console.WriteLine(" TARGET ELIMINATED ");
            Console.WriteLine($"{target.get_Name()} has been successfully neutralized!");
        }

        public string getFull()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" STRIKE UNITS STATUS ");
            sb.AppendLine($"1. {hermes460_Zik_Drone.NameForValidity()}:");
            sb.AppendLine($"   - Fuel: {hermes460_Zik_Drone.Fuel()}%");
            sb.AppendLine($"   - Hits Available: {hermes460_Zik_Drone.NumberOfHits()}");
            sb.AppendLine($"   - Efficiency: {hermes460_Zik_Drone.Efficiency()}");
            sb.AppendLine($"   - Bomb Type: {hermes460_Zik_Drone.Bomb()}");

            sb.AppendLine($"\n2. {f16FighterJet.NameForValidity()}:");
            sb.AppendLine($"   - Fuel: {f16FighterJet.Fuel()}%");
            sb.AppendLine($"   - Hits Available: {f16FighterJet.NumberOfHits()}");
            sb.AppendLine($"   - Efficiency: {f16FighterJet.Efficiency()}");
            sb.AppendLine($"   - Bomb Type: {f16FighterJet.Bomb()}");

            sb.AppendLine($"\n3. {m109Artillery.NameForValidity()}:");
            sb.AppendLine($"   - Fuel: {m109Artillery.Fuel()}%");
            sb.AppendLine($"   - Hits Available: {m109Artillery.NumberOfHits()}");
            sb.AppendLine($"   - Efficiency: {m109Artillery.Efficiency()}");
            sb.AppendLine($"   - Bomb Type: {m109Artillery.Bomb()}");

            return sb.ToString();
        }

        public StrikeUni selectBestUnit(string targetType, string location)
        {
            if (targetType.ToLower().Contains("building"))
            {
                return f16FighterJet;
            }
            else if (targetType.ToLower().Contains("vehicle") || targetType.ToLower().Contains("personnel"))
            {
                return hermes460_Zik_Drone;
            }
            else if (location.ToLower().Contains("open") || targetType.ToLower().Contains("area"))
            {
                return m109Artillery;
            }

            return hermes460_Zik_Drone;
        }

        private StrikeUni selectBestUnitForTerrorist(Terrorist target)
        {
            // Logic to select best unit based on terrorist characteristics
            var weapons = target.GetWeapons();
            int dangerLevel = target.QualityGoal();

            // High danger terrorists (>10) - use F16 for maximum impact
            if (dangerLevel > 10)
            {
                return f16FighterJet;
            }
            // Medium danger terrorists (5-10) - use precision drone
            else if (dangerLevel >= 5)
            {
                return hermes460_Zik_Drone;
            }
            // Low danger terrorists - use artillery
            else
            {
                return m109Artillery;
            }
        }
    }
}