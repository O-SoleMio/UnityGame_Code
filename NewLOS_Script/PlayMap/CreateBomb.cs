using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBomb : MonoBehaviour
{    
    public GameObject bom;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i < 50 ;i++)
        {           
            Instantiate(bom, new Vector3(gameObject.transform.position.x + (Random.Range(-600, 600)), 0,
                gameObject.transform.position.z + (Random.Range(-1000, 1000))),
                Quaternion.identity).transform.parent = transform;           
        } 
    }
}
