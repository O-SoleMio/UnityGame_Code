using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleMove : MonoBehaviour
{
    float random1;
    float random2;
    float Tick;
    public GameObject IceEffect;
    public GameObject Icicle;
   
    //public float _speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Tick = 0;
    }

    // Update is called once per frame
    void Update()
    {
        random1 = Random.Range(5, 15);
        
        transform.Translate(0,  0, random1 * Time.deltaTime);    
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Land"))
        {
            gameObject.SetActive(false);
            Instantiate(IceEffect,Icicle.transform.position, Quaternion.identity);         
        }
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.tag(""))
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}
}
