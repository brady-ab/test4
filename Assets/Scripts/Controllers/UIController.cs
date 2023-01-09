using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public TextMeshProUGUI currentPlayerTurn;
    public static UIController instance;
    public Button endTurn;
    public Button showHand;
    public Button showWeapons;

    public bool isShowing;
    public GameObject hands;

    private void Awake()
    {
        instance = this;
        SetupButtons();
    }

    private void SetupButtons()
    {
        endTurn.onClick.AddListener(() =>
        {
            TurnManager.instance.EndTurn();
        });
        
        showHand.onClick.AddListener(() =>
        {
            UIManager.instance.toggleHand();
        });
        
        showWeapons.onClick.AddListener(() =>
        {
            UIManager.instance.toggleRack();
        });
    }


    public void UpdateCurrentPlayerTurn(int ID)
    {
        currentPlayerTurn.gameObject.SetActive(true);
        currentPlayerTurn.text = $"Player {ID + 1}'s Turn!";

        StartCoroutine(BlinkCurrentPlayerTurn());
    }

    private IEnumerator BlinkCurrentPlayerTurn()
    {
        yield return new WaitForSeconds(0.5f);
        currentPlayerTurn.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        currentPlayerTurn.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        currentPlayerTurn.gameObject.SetActive(false);
        //yield return new WaitForSeconds(0.5f);
        //currentPlayerTurn.gameObject.SetActive(true);
        //yield return new WaitForSeconds(0.5f);
        //currentPlayerTurn.gameObject.SetActive(false);

    }

    // Start is called before the first frame update
    void Start()
    {
        isShowing = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}