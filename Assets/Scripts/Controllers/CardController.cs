using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;
using UnityEditor.U2D.Path.GUIFramework;

public class CardController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Card card;
    public List<Card> Card = new List<Card>();

    public GameObject namePlate;
    public GameObject traitsPlate;
    public GameObject weaponPlate;
    public GameObject cardBackground;
    public GameObject cardBack;
    public Image image;


    public Transform originalParent;

    public int ownerID;
    public int id;

    public string cardName;
    public int sealCost;
    public int attackDamage;
    public int cardHealth;
    public string traits;
    public List<int> cardEffects;
    public List<int> effectTimings;

    public TMP_Text nameText;
    public TMP_Text costText;
    public TMP_Text attackDamageText;
    public TMP_Text healthText;
    public TMP_Text traitsText;

    public bool isInvulnerable;
    public bool canAttack;
    public bool isPlayed;
    public bool isDraggable;
    public int position;

    public bool isEquipped;
    public WeaponController equippedWeapon;
    public int combinedDamage;

    public Canvas canvas;
    private RectTransform rectTransform;

    public Transform topLayer;

    public bool isZombie;


    private void Awake()
    {
        image = GetComponent<Image>();
    }

    //Enter information into this CardController based on a Card. Allows manipulation of a card during gameplay.
    public void Initialize(Card card, int ownerID)
    {

        id = card.id;
        cardName = card.cardName;
        sealCost = card.sealCost;
        attackDamage = card.attackDamage;
        cardHealth = card.cardHealth;
        traits = card.traits;
        //cardBack = card.cardBack;
        combinedDamage = card.attackDamage;

        nameText.text = cardName;
        costText.text = sealCost.ToString();
        attackDamageText.text = combinedDamage.ToString();
        healthText.text = cardHealth.ToString();
        traitsText.text = traits;


        originalParent = transform.parent;

        if (card.cardHealth == 0) healthText.text = "";

        //CHECK IF THIS DOES ANYTHING
        this.card = new Card(card)
        {
            ownerID = ownerID
        };
        this.ownerID = ownerID;
        //Debug.Log(cardEffects[0]);
    }



    //Updates the health text on a card
    public static void AdjustValues(CardController card)
    {
        card.healthText.text = card.cardHealth.ToString();
    }

    //Changes the card's location to the board, and allows it to act as a card in play. Allows the Card Manager to add it to appropriate lists.
    private void PlayCard(Transform playArea)
    {
        isDraggable = false;
        transform.SetParent(playArea);
        transform.localPosition = Vector2.zero;
        originalParent = playArea;
        position = PositionManager.GetPositionByPlayArea(playArea);
        if (position == 1 || position == 2)
        {
            CardManager.p1Defenders.Add(this);
        }
        if (position == 5 || position == 6)
        {
            CardManager.p2Defenders.Add(this);
        }
        canAttack = false;
        CardManager.instance.PlayCard(this, card.ownerID);
        UIManager.instance.hands.SetActive(true);
        UIManager.instance.isShowing = true;
    }

    private void ReturnToHand()
    {
        transform.SetParent(originalParent);
        transform.localPosition = Vector2.zero;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        
        if (isPlayed) //if played
        {
            transform.SetParent(topLayer);

            namePlate.gameObject.SetActive(true);
            traitsPlate.gameObject.SetActive(true);
            cardBackground.gameObject.SetActive(true);
            weaponPlate.gameObject.SetActive(true);


        }
        else
        {
            if (TurnManager.instance.currentPlayerTurn == card.ownerID) // if yours and not played
            {

                transform.SetParent(transform.root);
                image.raycastTarget = false;
            }

            else // if not yours and not played, do nothing
            {

            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isPlayed)
        {
            transform.SetParent(originalParent);
            namePlate.gameObject.SetActive(false);
            traitsPlate.gameObject.SetActive(false);
            cardBackground.gameObject.SetActive(false);
            weaponPlate.gameObject.SetActive(false);
            transform.localPosition = Vector2.zero;
        }
        else
        {
            if (TurnManager.instance.currentPlayerTurn == card.ownerID)
            {
                image.raycastTarget = true;
                AnalyzePointerUp(eventData);
            }
            else
            {



            }
        }
    }

    private void AnalyzePointerUp(PointerEventData eventData)
    {

        //Debug.Log(eventData.pointerEnter.name);
        if (eventData.pointerEnter != null && eventData.pointerEnter.name.Contains($"Player{card.ownerID + 1}Area"))
        {
            //FIX TO SUBTRACT SEALS FROM AMCONTROLLER
            //if (PlayerManager.instance.FindPlayerByID(card.ownerID).playerSeals >= sealCost)
            //{
                PlayCard(eventData.pointerEnter.transform);
                Initialize(card, TurnManager.instance.currentPlayerTurn);
                card.ownerID = TurnManager.instance.currentPlayerTurn;
                //PlayerManager.instance.SpendMana(card.ownerID, card.sealCost);


                namePlate.gameObject.SetActive(false);
                traitsPlate.gameObject.SetActive(false);
                cardBackground.gameObject.SetActive(false);
                weaponPlate.gameObject.SetActive(false);

                isPlayed = true;
            //}
            //else
            //{
            //    ReturnToHand();
            //}

        }
        else
        {
            ReturnToHand();

        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isPlayed && canAttack)
        {

            
            if (card.ownerID == TurnManager.instance.currentPlayerTurn)
            {
                if (eventData.pointerEnter.name == "Card(Clone)")
                {
                    if (eventData.pointerDrag.GetComponent<CardController>().ownerID != eventData.pointerEnter.GetComponent<CardController>().ownerID) 
                    {
                        

                        if (eventData.pointerDrag.GetComponent<CardController>().canAttack == true && eventData.pointerEnter.GetComponent<CardController>().isPlayed == true)
                        {

                            CardManager.Attack(eventData.pointerDrag, eventData.pointerEnter);

                        }

                        else
                        {

                        }
                    }
                    else
                    {

                    }
                }

                else if (eventData.pointerEnter.name == ("ArenaMaster"))
                {
                    if (eventData.pointerEnter.GetComponentInParent<ArenaMasterController>().playerID != eventData.pointerDrag.GetComponent<CardController>().ownerID)
                    {

                        CardManager.AttackAM(eventData.pointerDrag, eventData.pointerEnter);

                    }
                }
                else
                {

                }
            }
        }

        else
        {

        }

    }
    public void OnDrag(PointerEventData eventData)
    {
        if (isDraggable)
        {
            if (transform.parent == originalParent) return;
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            UIManager.instance.hands.SetActive(false);
            UIManager.instance.isShowing = false;
        }
        else
        {

        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = CardManager.instance.canvas;
        topLayer = CardManager.instance.topLayer;
    }


    /**public void Equip(Weapon weapon)
    {
        if (isEquipped == false)
        {
            cardHealth = cardHealth + weapon.weaponHealth;
            healthText.text = cardHealth.ToString();
            attackDamage = attackDamage + weapon.weaponDamage;
            attackDamageText.text = attackDamage.ToString();
            isEquipped = true;
            //add image to weaponfield
            //add effects
        }
    }**/
    // Update is called once per frame
    void Update()
    {


        if (isPlayed && cardHealth <= 0)
        {
            if (isZombie)
            {
                Zombify();
            }
            else
            {
                CardManager.SendToGraveyard(this.gameObject, ownerID);
            }
        }

        if (ArsenalManager.instance.p1Formation)
        {
            if (ownerID == 0)
            {
                if (CardManager.p1Defenders.Count > 0 && this.position == 4)
                {                    
                    isInvulnerable = true;
                    

                }
                else
                {
                    isInvulnerable = false;
                }
            }
            
            if (ArsenalManager.instance.p2Formation)
            {

                if (ownerID == 1)
                {
                    if (CardManager.p2Defenders.Count > 0 && this.position == 8)
                    {
                        isInvulnerable = true;


                    }
                    else
                    {
                        isInvulnerable = false;
                    }
                }
            }
        }



    }



    public void Zombify()
    {
        cardHealth = 1;
        attackDamage = 2;
        healthText.text = cardHealth.ToString();
        attackDamageText.text = attackDamage.ToString();

        isZombie = false;
    }

 
    

    public void OnTurnEnd(int effectID)
    {

    }
}
