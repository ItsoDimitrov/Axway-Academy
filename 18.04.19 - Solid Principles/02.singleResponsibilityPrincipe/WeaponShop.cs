using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace _02.singleResponsibilityPrincipe
{
    public class WeaponShop : WeaponShopValidate
    {
        public WeaponShop()
        {
            this.AllWeapons = new Dictionary<string, int>();    
        }
        public Dictionary<string,int> AllWeapons { get; set; }


        public void AddToShop(string name, int ammo)
        {
            if (base.ContainsInShop(name, AllWeapons))
            {
                AllWeapons.Add(name, ammo);

                Console.WriteLine($"Weapon {name} added");
            }
            Console.WriteLine($"Weapon {name} already added");
        }

        //public bool ContainsInShop(string name) // Method for checking if weapon is already in shop by given name
        //{
            //    if (this.AllWeapons.ContainsKey(name))
            //    {
                   
                //        return true;
            //    }

            //    return false;
        //}

        //public void WeaponsInShop()
        //{
        //    foreach (var allWeapon in AllWeapons)
        //    {
        //        Console.WriteLine($"Weapon {allWeapon.Key} - Ammo {allWeapon.Value}");
        //    }
        //}


    }
}
