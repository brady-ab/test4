using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Card
{
    public int id;
    public int ownerID;

    public string cardName;
    public int sealCost;
    public int attackDamage;
    public int cardHealth;
    public string traits;

    public Sprite illustration;


    public Card()
    {

    }

    public Card(int id, string cardname, int sealcost, int attackdamage, int cardhealth, string traits, Sprite illustration)
    {
        this.id = id;

        cardName = cardname;
        sealCost = sealcost;
        attackDamage = attackdamage;
        cardHealth = cardhealth;
        this.traits = traits;
        this.illustration = illustration;


    }

    public Card(Card card)
    {
        cardName = card.cardName;
        cardHealth = card.cardHealth;
        attackDamage = card.attackDamage;
        sealCost = card.sealCost;
        traits = card.traits;
        illustration = card.illustration;

    }

    public virtual void OnPlay(CardController card)
    {

    }

    public virtual void OnStartTurn(CardController card)
    {

    }

    public virtual void OnEndTurn(CardController card)
    {

    }

    public virtual void OnSustainDamage(CardController card)
    {

    }

    public virtual void OnDeath(CardController card)
    {

    }

    public virtual void OnAllySustainDamage(CardController card)
    {

    }

    public virtual void OnAllyDeath(CardController card)
    {

    }

    public virtual void OnAttack(CardController card)
    {

    }

    public virtual void OnAllyAttack(CardController card)
    {

    }

    public virtual void OnEquip(CardController card)
    {

    }


}

