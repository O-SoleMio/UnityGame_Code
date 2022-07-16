using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionFail : MonoBehaviour
{
    SFXManager SFX;
    void Start()
    {
        SFX = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        SFX.FailSFX();
    }
}
