using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    //부모 오브젝트 안에 원하는 만큼의 자식을 넣고 배열 크기를 맞춰 할당
    //배열로 짠 코드와 리스트를 사용한 코드 2개가 있음
       
    //Wall의 마지막 칸에는 무리가 아닌 좌표설정을 위한 빈 오브젝트 설정을 권함 - 리스트 코드 수정함
    //상자의 이동경로가 다른 상자의 영역에 침범하지 않는 것을 권함
    //public Transform[] Wall; // 사용할 무리의 수만큼 인스펙터 창에서 할당

    public List<Transform> Wall = new List<Transform>();// 리스트 용
    public List<Transform> FishPool = new List<Transform>();
    public List<Transform> NodePoint = new List<Transform>();

    [SerializeField]
    float WallSpeed; // 속도
    [SerializeField]
    int pattern;
    [SerializeField]
    int wallNum;
    [SerializeField]
    float dist; // 이동 목표까지의 거리

    int MaxSwarm; 
    int MinSwarm; 

    Vector3 GoPosition; // 도달 목표지점
    [SerializeField]
    Vector3[] SavePosition;
    
    public Transform Parentobj;//부모 오브젝트
    //public Transform PoolMgr;
    public GameObject LocalPoint;

    // Start is called before the first frame update

    void Awake()
    {
        MaxSwarm = 3; 
        MinSwarm = 0;
        SavePosition = new Vector3[Parentobj.childCount];
        
        //Wall = new Transform[MaxSwarm + 1]; // 배열 크기 할당        
        //Parentobj = transform.parent; // GetPoint 의 부모를 불러옴
        // for(int i = 0; i < 3 ; i++)
        //Vector3[] GetPosition = new Vector3[MaxSwarm];
        for (int i = 4; i < Parentobj.childCount -1 ; i++)
        {
            //Wall[i] = Parentobj.transform.GetChild(i); // Parentobj의 자식들을 불러옴
            Wall.Add(Parentobj.transform.GetChild(i));//리스트 용
        }
        for (int i = 0; i < LocalPoint.transform.childCount -1; i++)
        {
            NodePoint.Add(LocalPoint.transform.GetChild(i));
        }

        //for (int i = 0; i <= 1; i++)
        //{
        //    FishPool.Add(PoolMgr.transform.GetChild(i));
        //}

        wallNum = MaxSwarm - 1;
        WallSpeed = 2.0f;
        pattern = 1;
        dist = 0;
        GoPosition = Wall[wallNum].position;

        SavePosition[0] = Wall[4].position;
    }
    // Update is called once per frame
    void Update()
    {
        //MovePattern();
        NodeMove();
    }

    void MovePattern()
    {
        switch (pattern)
        {
            //case 0://(미완성)
            //    FishPool[MinSwarm].position = Wall[MinSwarm].position;
            //    FishPool.Add(Wall[MinSwarm]);

            //    Wall[MinSwarm].gameObject.SetActive(false);
            //    Wall.RemoveAt(MinSwarm);
            //    Wall.Insert(MinSwarm, FishPool[MinSwarm]);

            //    FishPool[MinSwarm].gameObject.SetActive(true);
            //    FishPool.RemoveAt(MinSwarm);
            //    pattern = 1;
            //    break;

            case 1:
                if (wallNum == Wall.Count - 1) // if (wallNum == MaxSwarm)
                {
                    wallNum = MinSwarm;
                }
                else
                {
                    wallNum = wallNum + 1;
                }

                SavePosition[0] = Wall[wallNum].position;
  
                pattern = 2;
                break;
            case 2:
                dist = Vector3.Distance(GoPosition, Wall[wallNum].position);
                if (wallNum == Wall.Count - 1)// if (wallNum == MaxSwarm) //Wall[MaxSwarm] 은 좌표설정을 위한 빈 오브젝트이기에 빠른 속도로 이동시킴
                {
                    Wall[wallNum].position =
                        Vector3.MoveTowards(Wall[wallNum].position, GoPosition, WallSpeed * 10 * Time.deltaTime);
                }
                else
                {               
                    Wall[wallNum].position =
                        Vector3.MoveTowards(Wall[wallNum].position, GoPosition, WallSpeed * Time.deltaTime);
                }
                if (dist < 0.01f) // 목표에 도달했다면 다음으로
                    pattern = 3;

                break;
            case 3:
                if (wallNum != Wall.Count - 2) // if (wallNum != MaxSwarm - 1)

                    GoPosition = SavePosition[0];

                pattern = 1;
                break;
        }
    }

    void NodeMove()
    {
        switch (pattern)
        {
            case 1:
                for (int i = 4; i < Parentobj.childCount - 1; i++)
                {
                    for (int j = 0; j < LocalPoint.transform.childCount; j++)
                    {
                        if (Vector3.Distance(NodePoint[j].position, Wall[i].position) < 1.0f)// 
                        {
                            if (j + 1 < NodePoint.Count)
                            {
                                SavePosition[i] = NodePoint[j + 1].position;
                            }
                            if (j + 1 == NodePoint.Count)
                            {
                                SavePosition[i] = NodePoint[0].position;
                            }
                            break;
                        }
                    }
                }

                pattern = 2;
                break;
            case 2:
                dist = distplus(); // 각 상자와 목표까지의 거리의 합

                for(int i = 0; i < Parentobj.childCount;i++)
                {
                    if (SavePosition[i] == NodePoint[0].position || SavePosition[i] == NodePoint[Parentobj.childCount - 1].position)
                    {
                        Wall[i].position =
                            Vector3.MoveTowards(Wall[i].position, SavePosition[i], WallSpeed * Time.deltaTime);
                    }
                    else
                    {
                        Wall[i].position =
                            Vector3.MoveTowards(Wall[i].position, SavePosition[i], WallSpeed * Time.deltaTime);
                    }
                }

                if(dist < 0.1f)
                {
                    pattern = 1;
                }                
                break;
            case 3:
                break;
        }
    }

    
    float distplus()
    {
        //이동 목표 노드 찾기       
        float result = 0;
       
        for (int i = 0; i < Parentobj.childCount; i++)
        {
            result += Vector3.Distance(SavePosition[i], Wall[i].position);
        }
        float dist = result;

        
        return dist;
    }

}