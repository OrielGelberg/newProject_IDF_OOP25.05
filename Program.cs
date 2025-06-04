using new25._05;
using System;
using System.Threading.Tasks;

namespace OOP_project_idf
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Hamas hamas = new Hamas();
            Ahman ahman = new Ahman(hamas); 
            attackManager attackManager = new attackManager();
            bool continueProgram = true;
            char userInput;

            void showMenu()
            {
                string menu = @"
                                   please Select an option from commander's console.
                                    
                            A.Intel Analysis:
                                Identify the terrorist with the most intelligence reports

                            B.Strike Availability:
                                Show all currently available strike units and their remaining capacity

                            C.Target Prioritization:
                                Determining the most dangerous spy based on quality rating

                            D.Strike Execution:
                                Attack the most dangerous terrorist and eliminate them

                            T.Show All Terrorists:
                                Display complete list of all terrorists in database
                            
                            E.Exit";

                Console.WriteLine(menu);
            }

            while (continueProgram)
            {
                showMenu();
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                userInput = char.ToLower(keyInfo.KeyChar);
                Console.WriteLine(); // Add newline after key press

                switch (userInput)
                {
                    case 'a':
                        ahman.add();
                        Console.WriteLine(ahman.alerts());
                        break;

                    case 'b':
                        Console.WriteLine(attackManager.getFull());
                        break;

                    case 'c':
                        var mostDangerous = hamas.getMostDangerousTerrorist();
                        if (mostDangerous != null)
                        {
                            Console.WriteLine($"Most dangerous terrorist: {mostDangerous.get_Name()} (ID: {mostDangerous.get_Id()})");
                            Console.WriteLine($"Danger level: {mostDangerous.QualityGoal()}");
                            Console.WriteLine($"Rank: {mostDangerous.get_Rank()}");
                            Console.WriteLine($"Weapons: {string.Join(", ", mostDangerous.GetWeapons())}");
                        }
                        else
                        {
                            Console.WriteLine("No terrorists found.");
                        }
                        break;

                    case 'd':
                        var targetTerrorist = hamas.getMostDangerousTerrorist();
                        if (targetTerrorist != null)
                        {
                            // Execute targeted strike
                            attackManager.executeTargetedStrike(targetTerrorist);

                            // Remove terrorist from intelligence reports
                            ahman.removeFromIntelligence(targetTerrorist.get_Name());

                            // Remove terrorist from Hamas organization
                            hamas.KillTerrorist(targetTerrorist.get_Id());

                            Console.WriteLine($"\n MISSION ACCOMPLISHED!");
                            Console.WriteLine($"Target {targetTerrorist.get_Name()} has been eliminated and removed from all databases.");
                        }
                        else
                        {
                            Console.WriteLine("No terrorists available for strike operation.");
                        }
                        break;

                    case 't':
                        ahman.showAllTerrorists();
                    //    APIgemini apiGeminiInstance = new APIgemini();
                    //case 't':
                    //    //ahman.showAllTerrorists();
                    //    APIgemini apiGeminiInstance = new APIgemini();
                    //    await apiGeminiInstance.CallGeminiApiAsync();
                    //    break;
                    //case 't':
                    //    APIgemini apiGeminiInstance = new APIgemini();
                    //    await apiGeminiInstance.CallGeminiApiAsync();
                       break;
                        

                    case 'e':
                        continueProgram = false;
                        Console.WriteLine("Exiting commander's console. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                if (continueProgram)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
