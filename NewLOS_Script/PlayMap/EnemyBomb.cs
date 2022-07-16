using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : MonoBehaviour
{
    public GameObject effectBoom;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);           
 
            Destroy(Instantiate(effectBoom, gameObject.transform.position, Quaternion.identity), 3.0f);
        }
    }
}
