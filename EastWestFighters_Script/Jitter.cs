using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jitter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SpeakerCube;
    public GameObject mainAudio;
    public AudioSource subAudio;
    public float[] sample = new float[64];
    void Start()
    {
        subAudio = mainAudio.GetComponent<AudioSource>();

        StartCoroutine("SpeakerJitter");
    }

    // Update is called once per frame
    IEnumerator SpeakerJitter()
    {
        while(true)
        {
            subAudio.GetSpectrumData(sample, 0, FFTWindow.Rectangular);

            SpeakerCube.transform.localScale =
                new Vector3(SpeakerCube.transform.localScale.x * sample[0],
                SpeakerCube.transform.localScale.y * sample[0],
                SpeakerCube.transform.localScale.z);

            yield return new WaitForSeconds(0.01f);
        }
        
    }
}
