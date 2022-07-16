using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost : MonoBehaviour
{
    public GameObject effectGhost;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            Destroy(Instantiate(effectGhost, gameObject.transform.position, Quaternion.identity), 3.0f);
        }
    }
}
