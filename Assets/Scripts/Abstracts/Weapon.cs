using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]


public class Weapon 
{
    public int ownerID;
    public int ID;

    public string weaponName;
    public int weaponCost;
    public int weaponDamage;
    public int weaponHealth;

    public Sprite illustration;
    public bool isFocus;


    
    public Weapon(int ID, string weaponName, int weaponCost, int weaponDamage, int weaponHealth, bool isFocus)
    {
        this.ID = ID;
        this.weaponName = weaponName;
        this.weaponCost = weaponCost;
        this.weaponDamage = weaponDamage;
        this.weaponHealth = weaponHealth;
        this.isFocus = isFocus;

    }

    public Weapon (Weapon weapon)
    {
        ID = weapon.ID;
        weaponName = weapon.weaponName;
        weaponCost = weapon.weaponCost;
        weaponDamage = weapon.weaponDamage;
        weaponHealth = weapon.weaponHealth;
    }

}
