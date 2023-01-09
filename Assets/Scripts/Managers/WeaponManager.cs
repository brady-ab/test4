using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public List<int> player1Weapons = new List<int>();
    public List<int> player2Weapons = new List<int>();

    public Transform player1WeaponRack, player2WeaponRack;

    public List<WeaponController> player1ThisWeapon = new List<WeaponController>();
    public List<WeaponController> player2ThisWeapon = new List<WeaponController>();

    public WeaponController thisWeaponPrefab;

    public Canvas canvas;




    int RackCount1;
    int RackCount2;
    
    int LoopRackFillP1()
    {
        for (int i = 1; i < 11; i++)
        {

            player1Weapons.Add(i);

        }
        return player1Weapons.Count;

    }
    int LoopRackFillP2()
    {
        //ADD IFS FOR P2
        for (int i = 1; i < 11; i++)
        {

            player2Weapons.Add(i);

        }
        return player2Weapons.Count;

    }

    private void FillRacks()
    {
        foreach (int weaponID in player1Weapons)
        {
            WeaponController newWeapon = Instantiate(thisWeaponPrefab, player1WeaponRack);
            newWeapon.transform.localPosition = Vector2.zero;
            newWeapon.Initialize(WeaponDatabase.WeaponList[weaponID], 0);
            newWeapon.isDraggable = true;
            player1ThisWeapon.Add(newWeapon);

        }

        foreach (int weaponID in player2Weapons)
        {
            WeaponController newWeapon = Instantiate(thisWeaponPrefab, player2WeaponRack);
            newWeapon.transform.localPosition = Vector2.zero;
            newWeapon.Initialize(WeaponDatabase.WeaponList[weaponID], 1);
            newWeapon.isDraggable = true;
            player2ThisWeapon.Add(newWeapon);

        }

    }





    // Start is called before the first frame update
    void Start()
    {
        RackCount1 = LoopRackFillP1();
        RackCount2 = LoopRackFillP2();
        FillRacks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
