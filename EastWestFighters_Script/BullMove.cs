using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullMove : MonoBehaviour
{
    public GameObject bull;
    public GameObject obj;
    public GameObject Point;
    public float change;
    public float dist;
    float speed;
    bool Direction;
    float random;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        Direction = true;
        change = 1;
        dist = 0;
        speed = 0.5f;
        random = 180;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(obj.transform.position, bull.transform.position);

        time += Time.deltaTime;
        speed += Time.deltaTime * 5;

        //Direction = new Vector3(0.0f,0.0f,random);

        Pattern();

        //SetChange();
        
        //transform.Translate(Vector3 * Time.deltaTime * speed);
        // SetChange();             
    }

    void Pattern()
    {
        if (Direction == true)
        {
            transform.rotation = Quaternion.Euler(0.0f, random + change, 0.0f);
        }

        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (time > 1.0f && dist >= 8 && dist < 8.5f)
        {
            Direction = true;           
            if (random > 90)
            {
                random = Random.Range(-20.0f, 20.0f);
            }
            else
            {
                random = Random.Range(160.0f, 200.0f);
            }

            // if (change == 0)
            // {
            //     change = -180;
            // }
            // else
            //{
            //     change = 0;
            //}
            time = 0;
            speed = 0.5f;       
           
        }
        else if(dist > 8.5f && time > 1.0f)
        {
            Direction = false;
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(Point.transform.transform.position - transform.position), 1.0f);

            time = 0;
            speed = 0.5f;
        }       
    }

}
