using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPos : MonoBehaviour
{
    float StartTime;
    float randomX;
    float randomY;
    float randomZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartTime += Time.deltaTime;
        if (StartTime > 1)
        {
            randomX = Random.Range(-4, 4);
            randomY = Random.Range(10, 20);
            randomZ = Random.Range(-4, 4);
            transform.position = new Vector3(randomX,randomY,randomZ);
            StartTime = 0;
        }

    }
}
