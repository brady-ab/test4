using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class ArenaMasterController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public int playerID;
    public int ID;
    public string arenaMasterName;
    public int currentSeals;
    public int currentHealth;
    public int currentAttack;

    public bool attackPossible;
    public bool canAttack;
    public bool watchForDeath;
    public bool canCast;

    public bool hasSplash;
    public bool invulnOn;
    public int defenderCheck;
    public bool zombifyOn;
    public bool hasDeflect;
    public bool lifeLeech;
    public bool canCastArcaneSpirit;

    public Button arsenalUnlock;
    public GameObject background;
    public TMP_Text healthText;
    public TMP_Text sealsText;
    public TMP_Text attackText;


    // Start is called before the first frame update
    void Start()
    {
        SetupButtons();
    }
    private void SetupButtons()
    {
        arsenalUnlock.onClick.AddListener(() =>
        {
            ArsenalManager.instance.UnlockArsenal(playerID, ID, this);
        });

    }


    public void Initialize(ArenaMaster arenaMaster, int ownerID)
    {
        playerID = TurnManager.instance.currentPlayerTurn;
        ID = arenaMaster.ID;
        arenaMasterName = arenaMaster.arenaMasterName;
        currentSeals = arenaMaster.playerSeals;
        currentHealth = arenaMaster.playerHealth;
        currentAttack = arenaMaster.amDamage;

        /*
        this.arenaMaster = new ArenaMaster(arenaMaster) 
        { 
        };\
        **/

        healthText.text = currentHealth.ToString();
        sealsText.text = currentSeals.ToString();

    }


    public void UpdateHealth()
    {
        healthText.text = currentHealth.ToString();

    }



    // Update is called once per frame
    void Update()
    {
        if (attackPossible)
        {
            attackText.gameObject.SetActive(true);
        }

        if (watchForDeath == true)
        {


            if (currentHealth == 0 || currentHealth < 0)
            {
                UIManager.instance.LoseGame(playerID);
            }
        }




    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if (attackPossible && canAttack)
        {
            if (playerID == TurnManager.instance.currentPlayerTurn)
            {
                if (eventData.pointerEnter.name == "Card(Clone)")
                {
                    if (playerID != eventData.pointerEnter.GetComponentInChildren<CardController>().ownerID && eventData.pointerEnter.GetComponentInChildren<CardController>().isPlayed == true)
                    {

                        ArenaMasterManager.CardAttack(eventData.pointerDrag, eventData.pointerEnter);

                    }


                }

                else if (eventData.pointerEnter.name == ("ArenaMaster"))
                {
                    if (playerID != eventData.pointerEnter.GetComponentInParent<ArenaMasterController>().playerID)
                    {

                        ArenaMasterManager.AMAttack(eventData.pointerDrag, eventData.pointerEnter);


                    }


                }

            }
        }
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        //throw new NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //throw new NotImplementedException();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       // throw new NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       // throw new NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //throw new NotImplementedException();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new NotImplementedException();
    }
}
