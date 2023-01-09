using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;


    public bool isShowing;
    public bool weaponShowing;
    public GameObject hands;
    public GameObject racks;
    public int winnerID;

    public TextMeshProUGUI winner;

    public GameObject endScreen;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isShowing = true;
        weaponShowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleHand()
    {
        if (isShowing == true)
        {
            hands.gameObject.SetActive(false);
            isShowing = false;
        }
        else if (isShowing == false)
        {
            racks.gameObject.SetActive(false);
            weaponShowing = false;
            hands.gameObject.SetActive(true);
            isShowing = true;
        }
    }

    public void toggleRack()
    {
        if (weaponShowing == false)
        {
            isShowing = false;
            hands.gameObject.SetActive(false);

            racks.gameObject.SetActive(true);
            weaponShowing = true;
        }
        else if(weaponShowing == true)
        {
            racks.gameObject.SetActive(false);
            weaponShowing = false;
        }

    }

    internal void LoseGame(int playerID)
    {
        if (playerID == 0){
            winnerID = 1;
        }
        else if (playerID == 1)
        {
            winnerID = 0;
        }

        WinGame(winnerID);
        //add layer that cant be clicked, defeat screen
    }

    private void WinGame(int winnerID)
    {
        endScreen.gameObject.SetActive(true);
        winner.gameObject.SetActive(true);
        winner.text = $"Player {winnerID + 1} has won!";
        //add layer that cant be clicked, victory screem
    }
}
