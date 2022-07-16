using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDarkFog : MonoBehaviour
{
    public GameObject DarkFog;
    float dis;
    void Start()
    {
        for(int i =0; i < 3 ;i++)
        {
            Instantiate(DarkFog,
                new Vector3((Random.Range(-500, 500)), 0, (Random.Range(0, 1500))), Quaternion.Euler(-90, 0, 0)).transform.parent = transform;
        }
    }   
}
