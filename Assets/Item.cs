using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public string r;
    public int l;
    public string t;
    public int mC;
    public int rC;
    public Renderer m;
    public string[] p;
    public string e;

    public Item(string rarity, int level, string type, int magazineCapacity, int reserveCapacity, string[] perks, string element)
    {
        r = rarity;
        l = level;
        t = type;
        mC = magazineCapacity;
        rC = reserveCapacity;
        p = perks;
        e = element;
    }

    public void SetLootInfo(string rarity, int level, string type, int magazineCapacity, int reserveCapacity, string[] perks, string element)
    {
        r = rarity;
        l = level;
        t = type;
        mC = magazineCapacity;
        rC = reserveCapacity;
        p = perks;
        e = element;

        // minor changes based on weapon type for balence
        if (t == "Rocket") mC /= 10;
        if (t == "Sniper") mC /= 7;

        if (t == "Machinegun")
        {
            mC *= 2;
            rC *= 2;
        }

        foreach (string i in perks)
        {
            if (i == "Extra Magazine Capacity") mC *= 2;
            if (i == "Extra Reserves Capacity") rC *= 2;
            if (i == "Extra Magazine and Reserves Capacity")
            {
                mC *= 2;
                rC *= 2;
            }
        }
    }
}
