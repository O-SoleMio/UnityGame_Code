using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SkyExposure : MonoBehaviour
{
    [SerializeField]
    float ExposureValue = 8.0f;
    [SerializeField]
    float expval = 1.0f;
    [SerializeField]
    float TickTime = 0;
    [SerializeField]
    bool setexpval = true;
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SpaceMap")
        {
            RenderSettings.skybox.SetFloat("_Exposure", Mathf.PingPong(Time.time * 2.0f, ExposureValue));
        }
        else if(SceneManager.GetActiveScene().name == "ForestMap")
        {           
            RenderSettings.skybox.SetFloat("_Exposure", expval + Mathf.PingPong(Time.time * 0.1f, 0.3f));            
        }
        
    }
}
