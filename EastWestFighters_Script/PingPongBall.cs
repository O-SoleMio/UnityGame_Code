using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongBall : MonoBehaviour
{ 
    public GameObject[] mapObj = new GameObject[2];

    float Num;

    void Update()
    {     
        for(int i = 0; i < mapObj.Length; i++)
        {
            Num = i + 1;
            mapObj[i].transform.position =
                 new Vector3(mapObj[i].transform.position.x,
                 Mathf.PingPong(Time.time * 0.2f * Num, Num * 2)
                , mapObj[i].transform.position.z);
        }
    }
}
