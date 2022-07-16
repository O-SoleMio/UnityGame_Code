using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoyancy : MonoBehaviour
{
    float yPos;    
    void Start()
    {
        StartCoroutine(Buo());
        yPos = transform.position.y;
    }

    IEnumerator Buo()
    {       
        while (true)
        {
            transform.position =
                new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, yPos + 0.25f, 0.01f), transform.position.z);
            if (transform.position.y >= yPos + 0.125f) { break; }            
            yield return new WaitForSeconds(0.02f);
        }       
        StartCoroutine(Yan());
    }

    IEnumerator Yan()
    {       
        while (true)
        {            
            transform.position =
                new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, yPos-0.25f, 0.01f), transform.position.z);
            if (transform.position.y <= yPos - 0.125f) { break; }           
            yield return new WaitForSeconds(0.02f);
        }        
        StartCoroutine(Buo());
    }
}
