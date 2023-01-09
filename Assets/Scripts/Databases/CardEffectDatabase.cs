using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardEffectDatabase : MonoBehaviour
{
    public static List<Delegate> cardEffects = new List<Delegate>();


    private void Awake()
    {
        SmugglerCER = SmugglerCardEffect;
        cardEffects.Add(SmugglerCER);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }



    public delegate void SmugglerDelegate (CardController card);
    public SmugglerDelegate SmugglerCER;
    public void SmugglerCardEffect(CardController Card)
    {
        CardManager.instance.DrawCard(Card.ownerID);
    }

    
}
