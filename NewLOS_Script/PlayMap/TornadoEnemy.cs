using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoEnemy : MonoBehaviour
{
    public GameObject Tornado;
    GameObject Player;
    BoatControl PlayerScript;

    float dis;
    float Second;
    Vector3 getPos;
    Vector3 PlayerPos;
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(Tornado,
                new Vector3((Random.Range(-500, 500)), 0, (Random.Range(0, 1500))),Quaternion.Euler(-90,0,0)).transform.parent = transform;
        }

        Player = GameObject.Find("Player");
        PlayerScript = GameObject.Find("Player").GetComponent<BoatControl>();
    }
    private void Update()
    {
        PlayerPos = Player.transform.position;
        for (int i = 0; i < 5;i++)
        {
            getPos = gameObject.transform.GetChild(i).position;            
            dis = Vector3.Distance(getPos,PlayerPos);

            if(dis < 30.0f)
            {
                if(PlayerPos.x > getPos.x) PlayerPos.x -= Time.deltaTime * 5.0f;
                else PlayerPos.x += Time.deltaTime * 2.0f;

                if(PlayerPos.z > getPos.z) PlayerPos.z -= Time.deltaTime * 5.0f;
                else PlayerPos.z += Time.deltaTime * 2.0f;

                Player.transform.position = PlayerPos;
            }           
            if(dis < 10.0f)
            {
                Second += Time.deltaTime;
                if(Second > 0.2f)
                {
                    PlayerScript.Maxhp -= 1;
                    Second = 0;
                }                           
            }
        }
    }
}
