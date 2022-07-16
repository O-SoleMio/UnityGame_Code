using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voiceinput : MonoBehaviour
{
    public GameObject Player;
    public AudioClip aud;
    int sampleRate = 44100;
    private float[] samples;
    string[] microname;
    public float rmsValue;
    public float modulate;
    public int resultValue;
    public int cutValue;

    // Start is called before the first frame update
    void Start()
    {
        samples = new float[sampleRate];
        microname = Microphone.devices;
        aud = Microphone.Start(Microphone.devices[0].ToString(), true, 1, sampleRate);
        StartCoroutine(MicroCoroutine());
    }

    IEnumerator MicroCoroutine()
    {        
        while (true)
        {         
            aud.GetData(samples, 0);
            float sum = 0;
            for (int i = 0; i < samples.Length; i++)
            {
                sum += samples[i] * samples[i];
            }
            rmsValue = Mathf.Sqrt(sum / samples.Length);
            rmsValue = rmsValue * modulate;
            rmsValue = Mathf.Clamp(rmsValue, 0, 100);
            
            if (resultValue < cutValue)
            {
                resultValue = 0;
            }
           
            yield return new WaitForSeconds(1.0f);
        }
        
    }   
}
