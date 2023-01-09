using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    public int currentPlayerTurn;
    public int turnCount;
    public static TurnManager instance;

    public GameObject manager;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartTurnGameplay(0);
    }

    public void StartTurnGameplay(int playerID)
    {
        currentPlayerTurn = playerID;
        PlayerManager.instance.AssignTurn(currentPlayerTurn);
        turnCount = -1;
        StartTurn();

    }

    public void StartTurn()
    {
        UIController.instance.UpdateCurrentPlayerTurn(currentPlayerTurn);
        CardManager.instance.ProcessStartTurn(currentPlayerTurn);
        if (currentPlayerTurn == 0)
        {
            turnCount++;
            if (PlayerManager.instance.arenaMasters.Count > 1)
            {
                PlayerManager.instance.arenaMasters[0].GetComponent<ArenaMasterController>().currentSeals = turnCount;
                PlayerManager.instance.arenaMasters[0].GetComponent<ArenaMasterController>().sealsText.text = turnCount.ToString();
            }
        }

        if (currentPlayerTurn == 1)
        {
            if (PlayerManager.instance.arenaMasters.Count > 1)
            {
                PlayerManager.instance.arenaMasters[1].GetComponent<ArenaMasterController>().currentSeals = turnCount;
                PlayerManager.instance.arenaMasters[1].GetComponent<ArenaMasterController>().sealsText.text = turnCount.ToString();
            }
        }

    }

    public void EndTurn()
    {
        if (currentPlayerTurn == 0)
        {
            

            foreach (CardController thisCard in manager.GetComponent<CardManager>().player1Cards)
            {
                thisCard.card.OnEndTurn(thisCard);
                thisCard.canAttack = true;

            }
        }

        if (currentPlayerTurn == 1)
        {
            foreach (CardController thisCard in manager.GetComponent<CardManager>().player2Cards)
            {
                thisCard.card.OnEndTurn(thisCard);
                thisCard.canAttack = true;
            }
        }


        currentPlayerTurn = currentPlayerTurn == 0 ? 1 : 0;
        StartTurn();

    }


    // Update is called once per frame
    void Update()
    {

    }
}
