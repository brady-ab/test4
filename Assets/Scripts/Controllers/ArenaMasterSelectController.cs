using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArenaMasterSelectController : MonoBehaviour
{
    public Button DG;
    public Button CW;
    public Button AS;
    public Button IS;
    public Button DC;
    public Button BM;



    private void SetupButtons()
    {
        DG.onClick.AddListener(() =>
        {
            PlayerManager.instance.assignArenaMaster(1, PlayerManager.instance.FindPlayerByID(TurnManager.instance.currentPlayerTurn));

        });

        CW.onClick.AddListener(() =>
        {
            PlayerManager.instance.assignArenaMaster(2, PlayerManager.instance.FindPlayerByID(TurnManager.instance.currentPlayerTurn));

        });

        AS.onClick.AddListener(() =>
        {
            PlayerManager.instance.assignArenaMaster(3, PlayerManager.instance.FindPlayerByID(TurnManager.instance.currentPlayerTurn));

        });

        IS.onClick.AddListener(() =>
        {
            PlayerManager.instance.assignArenaMaster(4, PlayerManager.instance.FindPlayerByID(TurnManager.instance.currentPlayerTurn));

        });

        DC.onClick.AddListener(() =>
        {
            PlayerManager.instance.assignArenaMaster(5, PlayerManager.instance.FindPlayerByID(TurnManager.instance.currentPlayerTurn));

        });

        BM.onClick.AddListener(() =>
        {
            PlayerManager.instance.assignArenaMaster(6, PlayerManager.instance.FindPlayerByID(TurnManager.instance.currentPlayerTurn));

        });
    }
    // Start is called before the first frame update
    void Start()
    {
        SetupButtons();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
