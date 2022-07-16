using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSound : MonoBehaviour
{
    public AudioSource Smanager;
    // Start is called before the first frame update
    void Start()
    {
        Smanager = GameObject.Find("BGM").GetComponent<AudioSource>();
        GetComponent<AudioSource>().volume = Smanager.volume * 0.5f;
    }

}
