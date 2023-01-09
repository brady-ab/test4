using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArsenalManager : MonoBehaviour
{
    public static ArsenalManager instance;
    public bool p1Formation;
    public bool p2Formation;


    private void Awake()
    {
        instance = this;
    }


    public void UnlockArsenal(int playerID, int arenaMasterID, ArenaMasterController arenaMaster)
    {
        if(playerID == TurnManager.instance.currentPlayerTurn) {
            switch (arenaMasterID)
            {
                case 1:
                    arenaMaster.attackPossible = true;
                    arenaMaster.canAttack = true;
                    arenaMaster.currentAttack = 4;
                    arenaMaster.attackText.text = arenaMaster.currentAttack.ToString();

                    arenaMaster.hasSplash = true;

                    break;



                case 2:
                    arenaMaster.attackPossible = true;
                    arenaMaster.canAttack = true;
                    arenaMaster.currentAttack = 3;
                    arenaMaster.attackText.text = arenaMaster.currentAttack.ToString();
                    if (arenaMaster.playerID == 0)
                    {
                        p1Formation = true;
                    }
                    else if (arenaMaster.playerID == 1)
                    {
                        p2Formation = true;
                    }

                    break;



                case 3:
                    arenaMaster.attackPossible = true;
                    arenaMaster.canAttack = true;
                    arenaMaster.currentAttack = 0;
                    arenaMaster.attackText.text = arenaMaster.currentAttack.ToString();

                    arenaMaster.canCastArcaneSpirit = true;

                    break;



                case 4:
                    arenaMaster.attackPossible = true;
                    arenaMaster.canAttack = true;
                    arenaMaster.currentAttack = 1;
                    arenaMaster.attackText.text = arenaMaster.currentAttack.ToString();

                    if (arenaMaster.playerID == 0)
                    {
                        foreach (CardController card in CardManager.instance.player1ThisDeck)
                        {
                            card.isZombie = true;

                        }
                        foreach (CardController card in CardManager.instance.player1HandCards)
                        {
                            card.isZombie = true;
                        }
                        foreach (CardController card in CardManager.player1CardsInPlay)
                        {
                            card.isZombie = true;
                        }

                    }
                    if (arenaMaster.playerID == 1)
                    {
                        foreach (CardController card in CardManager.instance.player2ThisDeck)
                        {
                            card.isZombie = true;
                        }
                        foreach (CardController card in CardManager.instance.player2HandCards)
                        {
                            card.isZombie = true;
                        }
                        foreach (CardController card in CardManager.player2CardsInPlay)
                        {
                            card.isZombie = true;
                        }
                    }


                    break;



                case 5:
                    arenaMaster.attackPossible = true;
                    arenaMaster.canAttack = true;
                    arenaMaster.currentAttack = 3;
                    arenaMaster.attackText.text = arenaMaster.currentAttack.ToString();

                    arenaMaster.hasDeflect = true;

                    break;



                case 6:
                    arenaMaster.attackPossible = true;
                    arenaMaster.canAttack = true;
                    arenaMaster.currentAttack = 2;
                    arenaMaster.attackText.text = arenaMaster.currentAttack.ToString();

                    arenaMaster.lifeLeech = true;

                    break;
            }
        }
        else
        {

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
