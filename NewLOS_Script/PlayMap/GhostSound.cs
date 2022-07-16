using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSound : MonoBehaviour
{
    public AudioSource Smanager;
    // Start is called before the first frame update
    void Start()
    {
        
        Smanager = GameObject.Find("BGM").GetComponent<AudioSource>();
        GetComponent<AudioSource>().volume = Smanager.volume;
    }
}
