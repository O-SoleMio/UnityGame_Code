using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGhost : MonoBehaviour
{
    public GameObject Ghost;
    GameObject Player;
    BoatControl PlayerScript;
    List<GameObject> ghostList = new List<GameObject>();
    List<Vector3> ghostPos = new List<Vector3>();
    float OriginalDis;
    float speed;
    float delaytime;
    
    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerScript = GameObject.Find("Player").GetComponent<BoatControl>();

        Invoke("startGhost",30f);
    }

    void startGhost()
    {
        StartCoroutine(targetGo());
    }

    IEnumerator targetGo()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(Ghost,
                new Vector3((Random.Range(-500, 500)), 0, (Random.Range(0, 1500))), Quaternion.Euler(-90, 0, 0)).transform.parent = transform;
            ghostList.Add(gameObject.transform.GetChild(i).gameObject);
            ghostPos.Add(ghostList[i].transform.position);
        }
        //반복문 시작
        while (true)
        {
            if (PlayerScript.MapClear == false && PlayerScript.MapFail == false)
                for (int i = 0; i < 5; i++)
                {
                        ghostList[i].transform.position =
                    Vector3.MoveTowards(ghostList[i].transform.position, Player.transform.position, PlayerScript.MaxSpeed * Time.deltaTime * 100);//배마다 감당가능한 속도, 부스트 속도로 따돌릴 수 있게            
                }
            yield return null;
        }        
    }
}
