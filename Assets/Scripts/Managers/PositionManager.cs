using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{

    public PositionManager instance;

    public Transform position1;
    public Transform position2;
    public Transform position3;
    public Transform position4;
    public Transform position5;
    public Transform position6;
    public Transform position7;
    public Transform position8;

    public static List<Transform> positions = new List<Transform>();


    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        positions.Add(position1);
        positions.Add(position2);
        positions.Add(position3);
        positions.Add(position4);
        positions.Add(position5);
        positions.Add(position6);
        positions.Add(position7);
        positions.Add(position8);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static int GetPositionByPlayArea(Transform playArea)
    {
        int x = 0;
        int i = 1;
        
        foreach (Transform position in positions)
        {
            
            if (position == playArea)
            {
                x = i;
            }
            else
            {
                i++;
            }
        }


        return x;
    }
}
