using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update   
    public AudioClip[] _BGM = new AudioClip[6];
    public AudioClip[] _SFX = new AudioClip[6];

    public AudioSource PlayBGM;
    public AudioSource PlaySFX;
    
    public GameObject bgmObj;
    public GameObject sfxObj;   
    
    public Slider SoundSlider;   
    public GameObject OptionUI;

    string scenename;
    void Awake()
    {
        bgmObj = GameObject.Find("BGM");
        sfxObj = GameObject.Find("SFX");

        OptionUI = GameObject.Find("TitleCanvas").transform.Find("Optionpopup").gameObject;
        SoundSlider = OptionUI.transform.Find("SoundSlider").GetComponent<Slider>();

        PlayBGM = bgmObj.GetComponent<AudioSource>();
        PlaySFX = sfxObj.GetComponent<AudioSource>();

        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (scenename == "TitleScene")
        {
            if (OptionUI.activeSelf)
            {
                PlayBGM.volume = SoundSlider.value;
                PlaySFX.volume = SoundSlider.value;
            }
        }      
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        scenename = SceneManager.GetActiveScene().name;
        if (scenename == "TitleScene")// 배경음
        {            
            PlayBGM.clip = _BGM[0];
            PlayBGM.enabled = false;
            PlayBGM.enabled = true;
        }
        else if(scenename == "ReadyScene")
        {
            PlayBGM.clip = _BGM[1];
            PlayBGM.enabled = false;
            PlayBGM.enabled = true;
        }
        else if (SceneManager.GetActiveScene().name == "EasyMap")
        {
            PlayBGM.clip = _BGM[2];
            PlayBGM.enabled = false;
            PlayBGM.enabled = true;
        }
        else if (SceneManager.GetActiveScene().name == "NormalMap")
        {
            PlayBGM.clip = _BGM[3];
            PlayBGM.enabled = false;
            PlayBGM.enabled = true;
        }
        else if (SceneManager.GetActiveScene().name == "HardMap")
        {
            PlayBGM.clip = _BGM[4];
            PlayBGM.enabled = false;
            PlayBGM.enabled = true;
        }
        else if (SceneManager.GetActiveScene().name == "CrazyMap")
        {
            PlayBGM.clip = _BGM[5];
            PlayBGM.enabled = false;
            PlayBGM.enabled = true;
        }
        else if (SceneManager.GetActiveScene().name == "BonusMap")
        {
            PlayBGM.clip = _BGM[6];
            PlayBGM.enabled = false;
            PlayBGM.enabled = true;
        }
    }

    public void SFXFunc(string action)
    {
        switch(action)
        {
            case "CLICK":
                PlaySFX.clip = _SFX[0];
                break;
            case "SELL":
                PlaySFX.clip = _SFX[1];
                break;
            case "BOOM":
                PlaySFX.clip = _SFX[2];
                break;
            case "GETGEM":
                PlaySFX.clip = _SFX[3];
                break;                           
            case "FAIL":
                PlaySFX.clip = _SFX[4];
                break;
            case "GHOST":
                PlaySFX.clip = _SFX[5];
                break;
        }
        PlaySFX.Play();
    }
}
