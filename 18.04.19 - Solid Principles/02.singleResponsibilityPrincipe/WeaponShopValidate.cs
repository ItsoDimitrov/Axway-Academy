using System;
using System.Collections.Generic;
using System.Text;

namespace _02.singleResponsibilityPrincipe
{
    public abstract class WeaponShopValidate
    {
        protected bool ContainsInShop(string name, Dictionary<string,int> allWeapons)
        {
            if (allWeapons.ContainsKey(name))
            {
                return true;
            }

            return false;
        }
    }
}
