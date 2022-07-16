
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoveMap : MonoBehaviour

{
    public Transform[] Wall; 
    public float WallSpeed;
    public int pattern;
    public int wallNum;
    int goNum;
    public float dist; 

    int MaxSwarm; 
    int MinSwarm; 
    Vector3 GoPosition; 
    Vector3 SavePosition;



    // Start is called before the first frame update

    void Awake()
    {
        MaxSwarm = 3; 
        MinSwarm = 0; 

        wallNum = MaxSwarm - 1;
        WallSpeed = 5.0f;
        pattern = 1;
        dist = 0;

        GoPosition = Wall[wallNum].position;
    }
    // Update is called once per frame
    void Update()
    {
        MovePattern();
    }

    void MovePattern()
    {
        switch (pattern)
        {
            case 1:
                if (wallNum == MaxSwarm)
                {
                    wallNum = MinSwarm;
                }
                else
                {
                    wallNum = wallNum + 1;
                }
                SavePosition = Wall[wallNum].position;
                pattern = 2;
                break;
            case 2:
                dist = Vector3.Distance(GoPosition, Wall[wallNum].position);
                if (wallNum == MaxSwarm)
                {
                    Wall[wallNum].position =
                        Vector3.MoveTowards(Wall[wallNum].position, GoPosition, WallSpeed * 10 * Time.deltaTime);
                }
                else
                {
                    Wall[wallNum].position =
                        Vector3.MoveTowards(Wall[wallNum].position, GoPosition, WallSpeed * Time.deltaTime);
                }
                if (dist < 0.1f) // 목표에 도달했다면 다음으로
                    pattern = 3;
                break;
            case 3:
                if (wallNum != MaxSwarm - 1)
                    GoPosition = SavePosition;
                pattern = 1;
                break;
        }
    }
}
