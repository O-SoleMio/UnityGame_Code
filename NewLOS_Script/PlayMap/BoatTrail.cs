using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoatTrail : MonoBehaviour
{
    GameObject Boat;
    void Start()
    {
        Boat = GameObject.Find("Player");
        StartCoroutine(TrailOn());
    }

    IEnumerator TrailOn()
    {
        while(true)
        {
            transform.rotation = Boat.transform.rotation;
            transform.position =
                new Vector3(Boat.transform.position.x,
                Boat.transform.position.y,
                Boat.transform.position.z);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
