using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]


public class Player
{

    public int ID;
    public bool myTurn;
    public int arenaMasterID;

    public Player(int ID, int arenaMasterID)
    {
        this.ID = ID;
        this.arenaMasterID = arenaMasterID;
    }
}
