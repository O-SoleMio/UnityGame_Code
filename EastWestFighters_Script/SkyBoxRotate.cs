using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRotate : MonoBehaviour
{
    [SerializeField]
    float RotateSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {               
        RenderSettings.skybox.SetFloat("_Rotation", -(Time.time * RotateSpeed));
    }
}
