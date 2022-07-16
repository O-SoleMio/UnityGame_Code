using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SFXManager : MonoBehaviour
{
    SoundManager SoundManager;
    void Start()
    {
        SoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    public void ClickButton()
    {
        SoundManager.SFXFunc("CLICK");
    }

    public void SellButton()
    {
        SoundManager.SFXFunc("SELL");
    }

    public void BoomSFX()
    {
        SoundManager.SFXFunc("BOOM");
    }

    public void GetGemSFX()
    {
        SoundManager.SFXFunc("GETGEM");
    }
    public void FailSFX()
    {
        SoundManager.SFXFunc("FAIL");
    }
    public void GhostSFX()
    {
        SoundManager.SFXFunc("GHOST");
    }
}
