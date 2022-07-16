using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionClear : MonoBehaviour
{
    SFXManager SFX;
    void Start()
    {
        SFX = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        SFX.GetGemSFX();
    }
}
