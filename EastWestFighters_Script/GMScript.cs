using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMScript : MonoBehaviour
{
    private Vector3 StartPos_Vec;
    public GameObject StartPos;
    float startTime;
    int second = 3;
    // Start is called before the first frame update
    void Start()
    {             
        
    }

    // Update is called once per frame
    void Update()
    {
        StartPos_Vec = StartPos.transform.position;
        startTime += Time.deltaTime;

        if (startTime > second)
        {
            second = Random.Range(1,5);
            ICICLE();
            startTime = 0;
        }
    }

    void ICICLE()
    {
        GameObject obj = ObjPooling.current.GetPooledObject();

        if (obj == null) return;

        obj.transform.position = StartPos_Vec;
        obj.SetActive(true);      
    }
}
