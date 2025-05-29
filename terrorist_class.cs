using System;
using System.Collections.Generic;

namespace OOP_project_idf
{
    internal class Terrorist
    {
        private string _Name;
        private int _Rank;
        private bool _live;
        private string _Id;
        private string[] names;
       // Random _random = new Random();
        private Terroristweapon _weapon = new Terroristweapon();

        public Terrorist(string id, Random random)
        {
            _Id = id;
            _Rank = random.Next(1, 6);
            _live = true;
            names = new string[] { "Ahmed", "Omar", "Ali", "Hassan", "Khaled", "Youssef", "Tariq", "Samir", "Mahmoud", "Nabil" };
            _Name = names[random.Next(names.Length)];
            _weapon = new Terroristweapon();
        }

        public string get_Name() { return _Name; }
        public int get_Rank() { return _Rank; }
        public bool is_live() { return _live; }
        public string get_Id() { return _Id; }

        public List<string> GetWeapons()
        {
            return _weapon.GetAllWeapons();
        }

        public int QualityGoal()
        {
            int Quality = _weapon.GetScoreAllWeaponName();
            return _Rank * Quality;
        }
    }
}