using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaMasterManager : MonoBehaviour
{
    public ArenaMasterManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static void AMAttack(GameObject attackingAM, GameObject defendingAM)
    {
        int attackerDamage = attackingAM.GetComponentInChildren<ArenaMasterController>().currentAttack;
        if (defendingAM.GetComponentInParent<ArenaMasterController>().hasDeflect == true)
        {
            attackerDamage = attackerDamage - 3;
            if (attackerDamage < 0)
            {
                attackerDamage = 0;
            }
        }

        int health1 = defendingAM.GetComponentInParent<ArenaMasterController>().currentHealth;
        defendingAM.GetComponentInParent<ArenaMasterController>().currentHealth = defendingAM.GetComponentInParent<ArenaMasterController>().currentHealth - attackerDamage;
        int health2 = defendingAM.GetComponentInParent<ArenaMasterController>().currentHealth;
        int leeched = health1 - health2;

        if (attackingAM.GetComponentInParent<ArenaMasterController>().lifeLeech == true)
        {
            attackingAM.GetComponentInParent<ArenaMasterController>().currentHealth = attackingAM.GetComponentInParent<ArenaMasterController>().currentHealth + leeched;
            attackingAM.GetComponentInParent<ArenaMasterController>().UpdateHealth();

        }

        defendingAM.GetComponentInParent<ArenaMasterController>().UpdateHealth();
        attackingAM.GetComponentInParent<ArenaMasterController>().canAttack = false;

    }

    public static void CardAttack(GameObject attackingAM, GameObject defendingCard)
    {
        int attackerDamage = attackingAM.GetComponentInChildren<ArenaMasterController>().currentAttack;
        if (defendingCard.GetComponent<CardController>().isInvulnerable == true)
        {
            attackerDamage = 0;

        }

        int health1 = defendingCard.GetComponent<CardController>().cardHealth;
        defendingCard.GetComponentInChildren<CardController>().cardHealth = defendingCard.GetComponentInChildren<CardController>().cardHealth - attackerDamage;
        attackingAM.GetComponentInParent<ArenaMasterController>().currentHealth = attackingAM.GetComponentInParent<ArenaMasterController>().currentHealth - defendingCard.GetComponentInChildren<CardController>().attackDamage;
        int health2 = defendingCard.GetComponent<CardController>().cardHealth;
        int leeched = health1 - health2;

        if (attackingAM.GetComponentInParent<ArenaMasterController>().lifeLeech == true)
        {
            attackingAM.GetComponentInParent<ArenaMasterController>().currentHealth = attackingAM.GetComponentInParent<ArenaMasterController>().currentHealth + leeched;
            attackingAM.GetComponentInParent<ArenaMasterController>().UpdateHealth();

        }


        attackingAM.GetComponentInParent<ArenaMasterController>().canAttack = false;
        attackingAM.GetComponentInParent<ArenaMasterController>().UpdateHealth();
        CardController.AdjustValues(defendingCard.GetComponentInChildren<CardController>());


        if (attackingAM.GetComponentInParent<ArenaMasterController>().hasSplash)
        {
            if (TurnManager.instance.currentPlayerTurn == 0)
            {
                foreach (CardController card in CardManager.player2CardsInPlay)
                {
                    if (card.position == defendingCard.GetComponentInChildren<CardController>().position + 1 || card.position == defendingCard.GetComponentInChildren<CardController>().position - 1)
                    {
                        card.cardHealth = card.cardHealth - attackingAM.GetComponentInParent<ArenaMasterController>().currentAttack / 2;
                        CardController.AdjustValues(card);
                      

                    }
                }
            }
            
            if (TurnManager.instance.currentPlayerTurn == 1)
            {
                foreach (CardController card in CardManager.player1CardsInPlay)
                {
                    if (card.position == defendingCard.GetComponentInChildren<CardController>().position + 1 || card.position == defendingCard.GetComponentInChildren<CardController>().position - 1)
                    {
                        card.cardHealth = card.cardHealth - attackingAM.GetComponentInParent<ArenaMasterController>().currentAttack / 2;
                        CardController.AdjustValues(card);

                    }
                }

            }
        }

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
