using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoatMap : MonoBehaviour
{
    public GameObject Boat;
    public float BoatZ;
    public float Maxnum;
    public float Minnum;
    public float startTime;
    public float speed;
    public bool ok;
    public int stack;
    public float BoatY;
    public float BoatYpoint;
    public AudioSource[] _BGM;

    // Start is called before the first frame update
    void Start()
    {
        BoatZ = 0;
        BoatY = 0;
        Maxnum = 10;
        Minnum = -10;
        startTime = 0;
        speed = 10;
        stack = 0;
        ok = true;
        BoatYpoint = -1;
        _BGM[0].Play();
    }

    // Update is called once per frame
    void Update()
    {
        Boat.transform.rotation = Quaternion.Euler(0.0f, 180.0f,BoatZ);
        Boat.transform.Translate(Vector3.up * BoatYpoint * ((Time.smoothDeltaTime * speed) / 10));

        if (BoatZ >=( Maxnum + stack))
        {
            ok = false;
        }
        else if(BoatZ <= (Minnum - stack))
        {
            ok = true;
        }

        if(ok == true)
        {
            BoatZ += Time.smoothDeltaTime * speed;
            if(Boat.transform.position.y < 0)
            {
                BoatYpoint = 1;
            }
        }
        else
        {
            BoatZ -= Time.smoothDeltaTime * speed;
            if(Boat.transform.position.y >= 0)
            {
                BoatYpoint = -1;
            }
        }

        _BGM[0].pitch += Time.smoothDeltaTime / 100; // 점점 빠르게
        startTime += Time.deltaTime;

        if(startTime > 5)
        {
            
            stack+= 3;
            speed = Random.Range(5, 30);
            startTime = 0;
            
        }


    }
}
