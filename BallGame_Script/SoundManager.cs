using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] _BGM = new AudioClip[5];   
    AudioSource playBgm;
    Button startButton;
    Scene sceneManager;
    string sceneName;
    int bgmNum = 0;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        playBgm = GameObject.Find("BGM").GetComponent<AudioSource>();      
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
        sceneName = SceneManager.GetActiveScene().name;
        if(sceneName == "Intro")
        {
            StartMusic();
            startButton = GameObject.Find("GameStart").GetComponent<Button>();
            startButton.onClick.AddListener(NextMusic);
        }
    }
    void StartMusic()
    {
        bgmNum = 0;
        playBgm.clip = _BGM[bgmNum];
        playBgm.Play();
    }
    void NextMusic()
    {
        playBgm.Stop();
        bgmNum += 1;
        StartCoroutine(MusicPlay());
    }
    IEnumerator MusicPlay()
    {
        while(true)
        {
            if(playBgm.isPlaying == false)
            {
                if (bgmNum < _BGM.Length - 1) 
                {                   
                    playBgm.clip = _BGM[bgmNum];
                    bgmNum++;
                }     
                else if(bgmNum == _BGM.Length - 1)
                {
                    if(playBgm.pitch < 2.0f) playBgm.pitch += 0.1f;
                    playBgm.clip = _BGM[bgmNum];
                }                
                playBgm.Play();
            }
            
            yield return new WaitForSeconds(0.5f);
        }      
    }
    public void SoundMute()
    {
        if (playBgm.volume != 0) playBgm.volume = 0;
        else if (playBgm.volume == 0) playBgm.volume = 1.0f;
    }
}
