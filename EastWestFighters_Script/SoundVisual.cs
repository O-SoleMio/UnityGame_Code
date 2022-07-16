using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVisual : MonoBehaviour
{
    public GameObject parentCube;
    public Transform[] Cube;   
    public Transform SpeakerCube;
    public Material CubeMat;
    Vector3 SpeakerScale;
    float SpeakerMax;

    AudioSource subAudio;
    [SerializeField]
    GameObject mainAudio;
    
    float BarSize = 50;
    float BarPosition;
    float BonusPoint;
    float BarXpos;
    public float[] samples = new float[64];

    void Awake()
    {     
        BarXpos = 0.125f;
        Cube = new Transform[64];
        mainAudio = GameObject.Find("_BGM");
        subAudio = mainAudio.GetComponent<AudioSource>();
        BonusPoint = 32 * BarXpos;
        for (int i = 0; i < 64; i++)
        {
            Cube[i] = parentCube.transform.GetChild(i);
        }

        for (int i = 0; i < 32; i++)
        {
            BarPosition = i;
            Cube[i].position = new Vector3(-1 * (7 - (BarPosition * BarXpos)), 0, (i - 8) * 0.5f);
        }

        for (int i = 32; i < 64; i++)
        {
            BarPosition = i;
            Cube[i].position = new Vector3((7 + BonusPoint) - (BarPosition * BarXpos), 0, (i - 40) * 0.5f);
        }

        SpeakerScale = SpeakerCube.localScale;
        SpeakerMax = SpeakerScale.x * 0.1f;
        StartCoroutine("VisualAudio");
    }

    // Update is called once per frame

    IEnumerator VisualAudio()
    {
        while (true)
        {
            subAudio.GetSpectrumData(samples, 0, FFTWindow.Rectangular);

            for (int i = 0; i < 64; i++)
            {
                if (i == 0)
                {
                    BarSize = 20;

                    SpeakerCube.localScale =
                new Vector3(SpeakerScale.x + samples[i] * SpeakerMax,
                SpeakerScale.y + samples[i] * SpeakerMax,
                SpeakerScale.z + samples[i] * SpeakerMax);
                }
                else
                {
                    BarSize = 50;
                }
                Cube[i].localScale =
                    new Vector3(0.5f,0.5f + (samples[i] * BarSize), 0.5f);
                
            }
            CubeMat.SetVector("_EmissionColor",
                new Vector3(0.5f + (1.0f * Mathf.PingPong(Time.time, 1.0f)),
                0.5f + (1.0f * Mathf.PingPong(Time.time, 2.0f)),
                0.5f + (1.0f * Mathf.PingPong(Time.time, 1.0f))));
            yield return new WaitForSeconds(0.02f);
        }
        
    }

    //void FixedUpdate()
    //{
    //    subAudio.GetSpectrumData(samples, 0, FFTWindow.Rectangular);

        

    //    for(int i = 0; i < 32; i++)
    //    {
    //        if(i == 0)
    //        {
    //            BarSize = 20;
    //        }
    //        else
    //        {
    //            BarSize = 50;
    //        }
    //        Cube[i].localScale =
    //            new Vector3(0.5f,samples[i] * BarSize,0.5f);
    //    }
    //}
}
