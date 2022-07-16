using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    float a = 0;
    int b = 0;
    void Start()
    {
        StartCoroutine(TestMath());
    }

    IEnumerator TestMath()
    {
        while(true)
        {
            
            yield return new WaitForSeconds(0.1f);
        }     
    }
}
