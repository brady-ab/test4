using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDatabase : MonoBehaviour
{

    public static List<Weapon> WeaponList = new List<Weapon>();

    private void Awake()
    {
        WeaponList.Add(new Weapon(0, "None", 0, 0, 0, false));
        WeaponList.Add(new Weapon(1, "Battlefield Salvage", 1, 2, 1, false));
        WeaponList.Add(new Weapon(2, "Repurposed Keg", 1, 0, 3, false));
        WeaponList.Add(new Weapon(3, "Casyrite Wand", 2, 1, 1, true));
        WeaponList.Add(new Weapon(4, "Hefty Mace", 2, 2, 2, false));
        WeaponList.Add(new Weapon(5, "Throwing Axe", 2, 2, 0, false));
        WeaponList.Add(new Weapon(6, "Crossbow", 3, 3, 0, false));
        WeaponList.Add(new Weapon(7, "Casyrite Staff", 3, 1, 3, true));
        WeaponList.Add(new Weapon(8, "Militia Spear", 3, 4, 2, false));
        WeaponList.Add(new Weapon(9, "Fang Dagger", 4, 1, 0, false));
        WeaponList.Add(new Weapon(10, "Halberd", 6, 6, 3, false));




    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
