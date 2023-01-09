using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaMasterDatabase : MonoBehaviour
{

    public static List<ArenaMaster> arenaMasterList = new List<ArenaMaster>();


    private void Awake()
    {

        arenaMasterList.Add(new ArenaMaster(0, 0, 0, 0, ""));
        arenaMasterList.Add(new ArenaMaster(1, 40, 0, 4, "Deserter General"));
        arenaMasterList.Add(new ArenaMaster(2, 40, 0, 3, "Captured Warmaster"));
        arenaMasterList.Add(new ArenaMaster(3, 30, 0, 0, "Arcane Spirit"));
        arenaMasterList.Add(new ArenaMaster(4, 30, 0, 1, "Imprisoned Shaman"));
        arenaMasterList.Add(new ArenaMaster(5, 40, 0, 3, "Disgraced Competitor"));
        arenaMasterList.Add(new ArenaMaster(6, 40, 0, 2, "Bog Dweller"));

    }


}
