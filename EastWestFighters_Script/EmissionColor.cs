using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionColor : MonoBehaviour
{
    public Material CubeMat;
    public Material CubeMat2;

    void Awake()
    {
        StartCoroutine("ChangeColor");        
    }
    IEnumerator ChangeColor()
    {
        while(true)
        {
            //CubeMat.SetVector("_EmissionColor",
            //    new Vector3(1.0f * Random.Range(1.0f,3.0f),
            //    1.0f * Random.Range(1.0f, 3.0f),
            //    1.0f * Random.Range(1.0f, 3.0f)));
            CubeMat.SetVector("_EmissionColor",
                new Vector3(1.0f * Mathf.PingPong(Time.time,3.0f),
                1.0f * Mathf.PingPong(Time.time, 1.0f),
                1.0f * Mathf.PingPong(Time.time, 2.0f)));

            CubeMat2.SetVector("_MainColor",
                new Vector3(1.0f * Mathf.PingPong(Time.time, 3.0f),
                1.0f * Mathf.PingPong(Time.time, 1.0f),
                1.0f * Mathf.PingPong(Time.time, 2.0f)));

            CubeMat2.SetVector("_RimColor",
                new Vector3(1.0f * Mathf.PingPong(Time.time, 3.0f),
                1.0f * Mathf.PingPong(Time.time, 1.0f),
                1.0f * Mathf.PingPong(Time.time, 2.0f)));

            yield return new WaitForSeconds(0.01f);
        }
    }
}