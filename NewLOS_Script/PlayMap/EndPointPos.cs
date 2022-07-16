using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointPos : MonoBehaviour
{   
    void Start()
    {
        gameObject.transform.position = new Vector3(Random.Range(-500,500),0,Random.Range(2000,2200));
    }
}
