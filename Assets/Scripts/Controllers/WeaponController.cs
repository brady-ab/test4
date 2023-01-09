using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class WeaponController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public GameObject weaponBackground;
    public GameObject numberPanel;
    public GameObject traitsPanel;
    public GameObject namePlate;
    public Image image;

    public bool isDraggable;

    public int sealCost;
    public int weaponDamage;
    public int weaponDefense;
    public int ownerID;
    public bool equipped;
    public int ID;
    public string weaponName;

    public TMP_Text sealCostText;
    public TMP_Text defenseText;
    public TMP_Text attackText;
    public TMP_Text nameText;
    //public TMP_Text traitsText;

    public Canvas canvas;
    private RectTransform rectTransform;
    public Transform originalParent;

    public Weapon weapon;

    private void Awake()
    {
        image = GetComponent<Image>();

    }

    public void Initialize(Weapon weapon, int ownerID)
    {
        ID = weapon.ID;
        weaponName = weapon.weaponName;
        sealCost = weapon.weaponCost;
        weaponDamage = weapon.weaponDamage;
        weaponDefense = weapon.weaponHealth;
        //weaponTraits = weapon.weaponTraits;

        nameText.text = weaponName;
        sealCostText.text = sealCost.ToString();
        attackText.text = weaponDamage.ToString();
        defenseText.text = weaponDefense.ToString();
        //traitsText.text = weaponTraits;

        originalParent = transform.parent;


        this.weapon = new Weapon(weapon)
        {
            ownerID = ownerID
        };
        this.ownerID = ownerID;
    }

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = CardManager.instance.canvas;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (TurnManager.instance.currentPlayerTurn == weapon.ownerID) // if yours and not played
        {

            transform.SetParent(transform.root);
            image.raycastTarget = false;
        }
    }

    private void ReturnToHand()
    {
        transform.SetParent(originalParent);
        transform.localPosition = Vector2.zero;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (TurnManager.instance.currentPlayerTurn == weapon.ownerID)
        {
            image.raycastTarget = true;
            AnalyzePointerUp(eventData);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDraggable)
        {
            if (transform.parent == originalParent) return;
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            UIManager.instance.racks.SetActive(false);
            UIManager.instance.weaponShowing = false;
        }
        else
        {

        }
    }

    private void AnalyzePointerUp(PointerEventData eventData)
    {

        //Debug.Log(eventData.pointerEnter.name);
        if (eventData.pointerEnter != null && eventData.pointerEnter.name.Contains($"Card(Clone)"))
        {
            if (equipped != true && eventData.pointerEnter.GetComponent<CardController>().isEquipped == false)
            {
                //FIX TO SUBTRACT SEALS FROM AMCONTROLLER
                //if (PlayerManager.instance.FindPlayerByID(card.ownerID).playerSeals >= sealCost)
                //{
                EquipWeapon(eventData.pointerEnter.GetComponent<CardController>());
                Initialize(weapon, TurnManager.instance.currentPlayerTurn);
                weapon.ownerID = TurnManager.instance.currentPlayerTurn;
                equipped = true;
                //PlayerManager.instance.SpendMana(card.ownerID, card.sealCost);


                namePlate.gameObject.SetActive(false);
                traitsPanel.gameObject.SetActive(false);
                weaponBackground.gameObject.SetActive(false);
                numberPanel.gameObject.SetActive(false);

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
        else
        {
            ReturnToHand();

        }
    }

    public void EquipWeapon(CardController card)
    {
        card.cardHealth = card.cardHealth + weaponDefense;
        card.healthText.text = card.cardHealth.ToString();
        card.combinedDamage = card.attackDamage + weaponDamage;
        card.attackDamageText.text = card.combinedDamage.ToString();
        card.isEquipped = true;
        card.equippedWeapon = this;
        //card.weaponImage = weaponImage

        originalParent = card.weaponPlate.transform;
        image.transform.SetParent(originalParent);
        image.transform.localPosition = Vector2.zero;
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }
}
