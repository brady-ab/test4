using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{


    public static CardManager instance;
    public List<Card> cards = new List<Card>();
    public Transform player1Hand, player2Hand;
    public Transform player1DeckPanel, player2DeckPanel;
    public CardController thisCardPrefab;
    public List<CardController> player1Cards = new List<CardController>(),
        player2Cards = new List<CardController>(), player1HandCards = new List<CardController>(), player2HandCards = new List<CardController>();

    public static List<CardController> player1CardsInPlay = new List<CardController>(), player2CardsInPlay = new List<CardController>();
    public static List<CardController> p1Defenders = new List<CardController>(), p2Defenders = new List<CardController>();

    public bool p1DefendersActive;
    public bool p2DefendersActive;

    public List<int> player1Deck = new List<int>();
    public List<int> player2Deck = new List<int>();

    public List<CardController> player1ThisDeck = new List<CardController>();
    public List<CardController> player2ThisDeck = new List<CardController>();

    public RectTransform cardSize = new RectTransform();

    public Canvas canvas;

    public Transform topLayer;



    int deckCount1;
    int deckCount2;

    private void Awake()
    {
        instance = this;

    }


    int LoopDeckFillP1()
    {
        for (int i = 1; i < 8; i++)
        {

            player1Deck.Add(i);
            
        }
        return player1Deck.Count;
        
    }
    int LoopDeckFillP2()
    {
        //ADD IFS FOR P2
        for (int i = 1; i < 8; i++)
        {

            player2Deck.Add(i);

        }
        return player2Deck.Count;

    }

    private void FillDecks()
    {
        foreach (int cardID in player1Deck)
        {
            CardController newCard = Instantiate(thisCardPrefab, player1DeckPanel);
            newCard.transform.localPosition = Vector2.zero;
            newCard.Initialize(CardDatabase.cardList[cardID], 0);
            newCard.cardBack.gameObject.SetActive(true);
            newCard.transform.localRotation = Quaternion.Euler(0, 0, 0);
            //CHECK THIS SHIT LATER
            newCard.transform.localScale = new Vector2(0.61f, 0.61f);
            player1ThisDeck.Add(newCard);

        }

        foreach (int cardID in player2Deck)
        {
            CardController newCard = Instantiate(thisCardPrefab, player2DeckPanel);
            newCard.transform.localPosition = Vector2.zero;
            newCard.Initialize(CardDatabase.cardList[cardID], 1);
            newCard.cardBack.gameObject.SetActive(true);
            newCard.transform.localRotation = Quaternion.Euler(0, 0, 0);
            //CHECK THIS SHIT LATER
            newCard.transform.localScale = new Vector2(0.61f, 0.61f);
            player2ThisDeck.Add(newCard);

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        deckCount1 = LoopDeckFillP1();
        deckCount2 = LoopDeckFillP2();
        FillDecks();
    }

    public void ProcessStartTurn(int ID)
    {
        bool drawCardBool = false;
        if (ID == 0)
        {
            drawCardBool = player1HandCards.Count < 6;
        }
        else
        {
            drawCardBool = player2HandCards.Count < 6;

        }

        if (drawCardBool && ID == 0)
        {
            if (player1ThisDeck.Count > 0)
            {
                DrawCard(0);
                
            }
        }

        else if (drawCardBool && ID == 1)
        {
            if (player2ThisDeck.Count > 0)
            {
                DrawCard(1);

            }


        }

    }

    public void DrawCard(int ID)
    {
        if (ID == 0)
        {
            int randomCard = UnityEngine.Random.Range(0, player1ThisDeck.Count);
            CardController drawnCard = player1ThisDeck[randomCard];

            drawnCard.transform.SetParent(player1Hand);
            drawnCard.transform.localRotation = Quaternion.Euler(0, 0, 0);
            drawnCard.transform.localScale = new Vector2(1f, 1f);
            drawnCard.isDraggable = true;
            drawnCard.originalParent = player1Hand;
            drawnCard.transform.localPosition = Vector2.zero;

            drawnCard.cardBack.gameObject.SetActive(false);

            player1HandCards.Add(drawnCard);
            player1ThisDeck.Remove(drawnCard);
        }
        else if (ID == 1)
        {
            int randomCard = UnityEngine.Random.Range(0, player2ThisDeck.Count);
            CardController drawnCard = player2ThisDeck[randomCard];

            drawnCard.transform.SetParent(player2Hand);
            drawnCard.transform.localRotation = Quaternion.Euler(0, 0, 0);
            drawnCard.transform.localScale = new Vector2(1f, 1f);
            drawnCard.isDraggable = true;
            drawnCard.originalParent = player2Hand;
            drawnCard.transform.localPosition = Vector2.zero;
            drawnCard.cardBack.gameObject.SetActive(false);

            player2HandCards.Add(drawnCard);
            player2ThisDeck.Remove(drawnCard);
        }
    }


    public void PlayCard(CardController card, int ID)
    {
        if (ID == 0)
        {
            player1Cards.Add(card);
            player1HandCards.Remove(card);
            player1CardsInPlay.Add(card);
        }
        if (ID == 1)
        {
            player2Cards.Add(card);
            player2HandCards.Remove(card);
            player2CardsInPlay.Add(card);


        }
    }


    public static void Attack(GameObject attackerObject, GameObject defenderObject)
    {
        int attackerDamage = attackerObject.GetComponentInChildren<CardController>().attackDamage;
        int defenderDamage = defenderObject.GetComponentInChildren<CardController>().attackDamage;

        if (attackerObject.GetComponent<CardController>().isInvulnerable == true)
        {
            defenderDamage = 0;

        }
        
        if (defenderObject.GetComponent<CardController>().isInvulnerable == true)
        {
            attackerDamage = 0;

        }

        defenderObject.GetComponentInChildren<CardController>().cardHealth = defenderObject.GetComponentInChildren<CardController>().cardHealth - attackerDamage;
        attackerObject.GetComponentInChildren<CardController>().cardHealth = attackerObject.GetComponentInChildren<CardController>().cardHealth - defenderDamage;

        attackerObject.GetComponentInChildren<CardController>().canAttack = false;

        CardController.AdjustValues(defenderObject.GetComponentInChildren<CardController>());
        CardController.AdjustValues(attackerObject.GetComponentInChildren<CardController>());

        attackerObject.GetComponentInChildren<CardController>().canAttack = false;

        if (attackerObject.GetComponentInChildren<CardController>().cardHealth <= 0)
        {
            SendToGraveyard(attackerObject, attackerObject.GetComponentInChildren<CardController>().ownerID);
           
        }

        if (defenderObject.GetComponentInChildren<CardController>().cardHealth <= 0)
        {
            SendToGraveyard(defenderObject, defenderObject.GetComponentInChildren<CardController>().ownerID);
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AttackAM(GameObject attackingCard, GameObject defendingAM)
    {
        int attackerDamage = attackingCard.GetComponentInChildren<CardController>().attackDamage;
        if (defendingAM.GetComponentInParent<ArenaMasterController>().hasDeflect == true)
        {
            attackerDamage = attackerDamage - 3;
            if (attackerDamage < 0)
            {
                attackerDamage = 0;
            }

        }

        defendingAM.GetComponentInParent<ArenaMasterController>().currentHealth = defendingAM.GetComponentInParent<ArenaMasterController>().currentHealth - attackerDamage;
        defendingAM.GetComponentInParent<ArenaMasterController>().UpdateHealth();
        attackingCard.GetComponentInChildren<CardController>().canAttack = false;


    }

    public static void SendToGraveyard(GameObject card, int ownerID) 
    {
        //card.GetComponent<CardController>().EffectCheck(7, card.GetComponent<CardController>());

        //add player 1 and 2 dead card lists
        if (ownerID == 0)
        {
            try
            {
                foreach (CardController cardController in p1Defenders)
                {
                    if (card.GetComponent<CardController>() == cardController)
                    {
                        p1Defenders.Remove(cardController);
                    }
                }
                player1CardsInPlay.Remove(card.GetComponentInChildren<CardController>());
                Destroy(card);
            }
            //DANGEROUS
            catch { }
        }
        else if (ownerID == 1)
        {
            try
            {
                foreach (CardController cardController in p2Defenders)
                {
                    if (card.GetComponent<CardController>() == cardController)
                    {
                        p1Defenders.Remove(cardController);
                    }
                }
                player2CardsInPlay.Remove(card.GetComponentInChildren<CardController>());
                Destroy(card);
            }
            //DANGEROUS
            catch { }
        }
    }


}
