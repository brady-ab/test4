using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectListDatabase : MonoBehaviour
{
    /**
    *0 - None
    *1 - Start Turn
    *2 - End Turn
    *3 - Card Played
    *4 - Card Attacked
    *5 - Card Killed
    *6 - Survive Damage
    *7 - Death
    *8 - Equip Self
    *9 - Equip Allies
    *10 - Equip Enemy
    *11 - Equip All
    *12 - Friendly Spell
    *13 - Enemy Spell
    *14 - Any Spell
    *15 - Constant
    *MORE?
     **/

    public static EffectListDatabase instance;




    public void deployEffects(int i, CardController card)
    {
        //many cases that subscribe a method to an event in eventManager.
    }

    public static List<int> noEffectList = new List<int>();
    public static List<int> noTimingtList = new List<int>();

    public static List<int> smugglerEffectList = new List<int>();
    public static List<int> smugglerTimingList = new List<int>();

    private void Awake()
    {
        instance = this;

        noEffectList.Add(0);
        noTimingtList.Add(0);

        smugglerEffectList.Add(1);
        smugglerTimingList.Add(7);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
