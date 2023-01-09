using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]


public class ArenaMaster
{
    public int ID;
    public int playerHealth, playerSeals;
    public bool myTurn;
    public string arenaMasterName;
    public int amDamage;

    public Sprite illustration;


    public ArenaMaster(int ID, int amHealth, int playerSeals, int amDamage, string arenaMasterName)
    {
        this.ID = ID;
        this.playerHealth = amHealth;
        this.playerSeals = playerSeals;
        this.arenaMasterName = arenaMasterName;
        this.amDamage = amDamage;
    }

    public ArenaMaster(ArenaMasterController amc)
    {
        ID = amc.ID;
        playerHealth = amc.currentHealth;
        playerSeals = amc.currentSeals;
        arenaMasterName = amc.arenaMasterName;

    }

    /** LMAO FIX THIS LATER
    public void UpdateValues(Player player0, Player player1)
    {
        UpdateHealthValues(player0.playerHealth, player1.playerHealth);
        UpdateSealValues(player0.playerSeals, player1.playerSeals);
    }

    public void UpdateHealthValues(int player0Health, int player1Health)
    {
        this.player0Health.text = player0Health.ToString();
        this.player1Health.text = player1Health.ToString();

    }

    public void UpdateSealValues(int player0Seals, int player1Seals)
    {
        this.player0Seals.text = player0Seals.ToString();
        this.player1Seals.text = player1Seals.ToString();
    }
    **/
}
