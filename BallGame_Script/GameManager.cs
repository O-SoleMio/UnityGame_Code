using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public int easyEnemyNum;
    public float easyEnemyDelay;    
    public Text gameMode;

    SoundManager soundManager;

    Button gameStart;
    Button modeButton;
    Button soundMute;
    Button gameExit;

    string sceneName;

    public int scoreMag;
    int modeNum = 0;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        Application.targetFrameRate = 60;        
        SceneManager.LoadScene("Intro");      
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "Intro")
        {           
            gameMode = GameObject.Find("ModeText").GetComponent<Text>();
            soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

            gameStart = GameObject.Find("GameStart").GetComponent<Button>();
            modeButton = GameObject.Find("GameMode").GetComponent<Button>();
            soundMute = GameObject.Find("Mute").GetComponent<Button>();
            gameExit = GameObject.Find("GameExit").GetComponent<Button>();

            gameStart.onClick.AddListener(StartButton);
            modeButton.onClick.AddListener(GameMode);
            gameExit.onClick.AddListener(Exitbutton);
            soundMute.onClick.AddListener(soundManager.SoundMute);

            easyEnemyNum = 30;
            easyEnemyDelay = 0.5f;
            scoreMag = 1;
            modeNum = 0;
        }
    }

    
    void StartButton()
    {
        SceneManager.LoadScene("Play");    
    }

    void GameMode()
    {
        if(modeNum == 0)
        {
            gameMode.text = "Hard";
            easyEnemyNum = 50;
            easyEnemyDelay = 0.3f;
            scoreMag = 2;
            modeNum = 1;
        }
        else if (modeNum == 1)
        {
            gameMode.text = "Hell";
            easyEnemyNum = 100;
            easyEnemyDelay = 0.1f;
            scoreMag = 3;
            modeNum = 2;
        }
        else if (modeNum == 2)
        {
            gameMode.text = "Normal";
            easyEnemyNum = 30;
            easyEnemyDelay = 0.5f;
            scoreMag = 1;
            modeNum = 0;
        }
    }

    void Exitbutton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();       
#endif
    }
}
