using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetRain : MonoBehaviour
{
    GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");
        //gameObject.transform.parent = Player.transform;
        //gameObject.transform.localPosition = new Vector3(0, 50, -10);
        //gameObject.transform.localScale = new Vector3(4, 3, 4);
        StartCoroutine(FollowRain());
    }

    IEnumerator FollowRain()
    {      
        
        while (true)
        {
            gameObject.transform.position =
                new Vector3(Player.transform.position.x, gameObject.transform.position.y, Player.transform.position.z);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
