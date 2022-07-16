using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastSound : MonoBehaviour
{
    public GameObject fSound;
    public float SoundSpeed;
    float DelayTime;

    AudioSource bgmSound;
    // Start is called before the first frame update
    void Awake()
    {        
        bgmSound = fSound.GetComponent<AudioSource>();        
    }

    void OnEnable()
    {
        SoundSpeed = 0.0f;
        DelayTime = 0.0f;
    }

    void OnDisable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DelayTime += Time.deltaTime;

        bgmSound.pitch
                = (1.0f + SoundSpeed);

        if (DelayTime > 1.5f && SoundSpeed <= 0.2f)
        {
            SoundSpeed += 0.01f;
            DelayTime = 0;
        }
    }
}
