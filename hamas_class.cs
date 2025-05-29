using System;
using System.Collections.Generic;

namespace OOP_project_idf
{
    internal class Hamas : Terrorist_organization
    {
        private string _Name;
        private string _DateEstablished;
        private string _Commander;
        private List<Terrorist> terrorist = new List<Terrorist>();
        Random _random = new Random();
        private int numberOfTerrorists;

        public Hamas()
        {
            _Name = "hamas";
            _DateEstablished = "10.12.1984";
            _Commander = "Sinwar";
            numberOfTerrorists = _random.Next(5, 10);

            for (int i = 0; i < numberOfTerrorists; i++)
            {
                Terrorist t = new Terrorist(i.ToString(), _random);
                terrorist.Add(t);
            }
        }

        public Terrorist getTerrorists(string id)
        {
            int i = 0;
            while (true)
            {
                if (i < numberOfTerrorists)
                {
                    if (terrorist[i].get_Id() == id)
                        return terrorist[i];
                    i++;
                }
                else
                    break;
            }
            Console.WriteLine("Dont found this id");
            return null;
        }

        public List<string> getLid()
        {
            List<string> lID = new List<string>();
            for (int i = 0; i < terrorist.Count; i++)
            {
                lID.Add(terrorist[i].get_Name());
            }
            return lID;
        }

        public string getCommander()
        {
            return _Commander;
        }

        public void setCpmmander(string newCommander)
        {
            _Commander = newCommander;
        }

        public string Name()
        {
            return _Name;
        }

        public string getDateEstablished()
        {
            return _DateEstablished;
        }

        public List<Terrorist> getTerrorist()
        {
            return terrorist;
        }

        public Terrorist getMostDangerousTerrorist()
        {
            if (terrorist.Count == 0)
                return null;

            Terrorist mostDangerous = terrorist[0];
            int maxDangerLevel = mostDangerous.QualityGoal();

            foreach (var t in terrorist)
            {
                int dangerLevel = t.QualityGoal();
                if (dangerLevel > maxDangerLevel)
                {
                    maxDangerLevel = dangerLevel;
                    mostDangerous = t;
                }
            }

            return mostDangerous;
        }

        public void KillTerrorist(string nId)
        {
            Terrorist terroristToRemove = null;

            foreach (Terrorist t in terrorist)
            {
                if (t.get_Id() == nId)
                {
                    terroristToRemove = t;
                    break;
                }
            }
            if (terroristToRemove != null)
            {
                terrorist.Remove(terroristToRemove);
                Console.WriteLine($"Terrorist with ID {nId} has been eliminated from the organization.");
            }
            else
            {
                Console.WriteLine($"Terrorist with ID {nId} not found.");
            }
        }
    }
}