using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager instance;
    public List<Player> players = new List<Player>();

    public GameObject arenaMasterSelect;

    public ArenaMasterController amPrefab;
    public List<ArenaMasterController> arenaMasters = new List<ArenaMasterController>();

    public Transform Player1Portrait;
    public Transform Player2Portrait;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // THIS SHOULD BE IN AMManagerMETHINKS
        //UIManager.instance.UpdateValues(players[0], players[1]);
        
        arenaMasterSelect.SetActive(true);

    }

    internal void AssignTurn(int currentPlayerTurn)
    {

        foreach (Player player in players)
        {

            player.myTurn = player.ID == currentPlayerTurn;
        }
    }

    public Player FindPlayerByID(int ID)
    {
        Player foundPlayer = null;
        foreach (Player player in players)
        {
            if (player.ID == ID)
                foundPlayer = player;
        }
        return foundPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**MOVE TO AMMANAGER
    public void DamagePlayer(int ID, int damage)
    {
        Player player = FindPlayerByID(ID);
        player.playerHealth -= damage;
        if (player.playerHealth <= 0)
        {

        }
    }

    internal void SpendMana(int ownerID, int sealCost)
    {
        FindPlayerByID(ownerID).playerSeals -= sealCost;
        UIManager.instance.UpdateSealValues(players[0].playerSeals, players[1].playerSeals);
    }
    **/

    public void assignArenaMaster(int arenaMasterID, Player player)
    {
        if (player.ID == 0)
        {
            player.arenaMasterID = arenaMasterID;
            ArenaMasterController arenaMaster = Instantiate(amPrefab, Player1Portrait);
            arenaMasters.Add(arenaMaster);
            arenaMaster.transform.localPosition = Vector2.zero;
            arenaMaster.Initialize(ArenaMasterDatabase.arenaMasterList[arenaMasterID], TurnManager.instance.currentPlayerTurn);
            arenaMaster.watchForDeath = true;
            TurnManager.instance.EndTurn();

        }
        else if (player.ID == 1)
        {
            player.arenaMasterID = arenaMasterID;
            ArenaMasterController arenaMaster = Instantiate(amPrefab, Player2Portrait);
            arenaMasters.Add(arenaMaster);
            arenaMaster.transform.localPosition = Vector2.zero;
            arenaMaster.Initialize(ArenaMasterDatabase.arenaMasterList[arenaMasterID], TurnManager.instance.currentPlayerTurn);
            arenaMasterSelect.SetActive(false);
            arenaMaster.watchForDeath = true;
            TurnManager.instance.EndTurn();
        }
    }

}
