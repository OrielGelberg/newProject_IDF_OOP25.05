using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_project_idf
{
    internal class Terroristweapon
    {
        private Random random = new Random();

        private Dictionary<string, int> ScoreWeapon = new Dictionary<string, int>()
        {
            { "Knife", 1 },
            { "Gun", 2 },
            { "AK47", 3 },
            { "M16", 3 }
        };

        private Dictionary<string, int> listTWeapon = new Dictionary<string, int>();

        public Terroristweapon()
        {
            int weaponsToAdd = random.Next(1, ScoreWeapon.Count + 1);
            List<string> allWeapons = ScoreWeapon.Keys.ToList();
            allWeapons = allWeapons.OrderBy(w => random.Next()).ToList();

            for (int i = 0; i < weaponsToAdd; i++)
            {
                string weaponName = allWeapons[i];
                int score = ScoreWeapon[weaponName];
                listTWeapon.Add(weaponName, score);
            }
        }

        public int GetScoreAllWeaponName()
        {
            int _Score = 0;
            foreach (var weapon in listTWeapon)
            {
                _Score += weapon.Value;
            }
            return _Score;
        }

        public List<string> GetAllWeapons()
        {
            List<string> allWeaponsT = listTWeapon.Keys.ToList();
            return allWeaponsT;
        }
    }
}