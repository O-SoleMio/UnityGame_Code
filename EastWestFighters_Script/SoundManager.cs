using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SoundManager : MonoBehaviour
{   //Scene num 0 - Start 1 - Loading 2 - Cube_Test 3 - PirateMap 4 - SpaceMap 5 - Jump_Test
    //Music num 0 - Let's Rock... 1 - Christmas... 2 - Casual Theme#2 3 - Downhill... 4 - EDM... 5,
    [SerializeField]
    AudioClip[] BGMs = new AudioClip[6]; 
    public AudioSource _BGM;

    public AudioClip[] SFXs = new AudioClip[0];
    [SerializeField]
    GameObject sfxObj;
    AudioSource _SFX;

    float TickTime;
    float saveVolume;
    bool muteSound;

    GameObject bgmObj;
    AudioSource bgmSource;
    FastSound fsound;

    //TaeHO Code
    NewGameManager NGM;

    void Awake()
    {
        bgmObj = GameObject.Find("_BGM");
        sfxObj = GameObject.Find("SFX");

        bgmSource = bgmObj.GetComponent<AudioSource>();
        fsound = gameObject.GetComponent<FastSound>();
        muteSound = false;
        bgmSource.volume = 0.5f;
        bgmSource.pitch = 1.0f;
    }
    // Start is called before the first frame update
    void Start()
    { 
        DontDestroyOnLoad(gameObject);
        fsound.enabled = false;
        //Debug.Log(Application.loadedLevelName);
        //Debug.Log(SceneManager.GetActiveScene().name);
        //Debug.Log(SceneManager.GetActiveScene().buildIndex);
        //Debug.Log(_BGM.clip);

        NGM = GameObject.Find("GameManager").GetComponent<NewGameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        TickTime += Time.deltaTime;

        if (TickTime > 0.2f) // 키 입력 텀
        {
            if (Input.GetKeyDown(KeyCode.F10) && muteSound == false)
            {
                bgmSource.volume += 0.1f;
                TickTime = 0.0f;
            }
            else if (Input.GetKeyDown(KeyCode.F11) && muteSound == false)
            {
                bgmSource.volume -= 0.1f;
                TickTime = 0.0f;
            }
            else if(Input.GetKeyDown(KeyCode.F12))
            {
                if (muteSound == false)
                {
                    saveVolume = bgmSource.volume;
                    bgmSource.volume = 0.0f;
                    muteSound = true;
                }
                else if(muteSound == true)
                {
                    bgmSource.volume = saveVolume;
                    muteSound = false;
                }
                TickTime = 0.0f;
            }
        }

        if(SceneManager.GetActiveScene().name == "Start" &&
            _BGM.clip != BGMs[0])
        {
            _BGM.clip = BGMs[0];            
            bgmSource.enabled = false;
            bgmSource.enabled = true;
        }
        else if(SceneManager.GetActiveScene().name == "Cube_Test"&&
            _BGM.clip != BGMs[1])
        {
            _BGM.clip = BGMs[1];
            fsound.enabled = false;
            fsound.enabled = true;
            bgmSource.enabled = false;
            bgmSource.enabled = true;
        }
        else if(SceneManager.GetActiveScene().name == "PirateMap" &&
            _BGM.clip != BGMs[2])
        {
            _BGM.clip = BGMs[2];
            fsound.enabled = false;
            fsound.enabled = true;
            bgmSource.enabled = false;
            bgmSource.enabled = true;
            
        }
        else if (SceneManager.GetActiveScene().name == "ForestMap" &&
            _BGM.clip != BGMs[3])
        {
            _BGM.clip = BGMs[3];
            fsound.enabled = false;
            fsound.enabled = true;
            bgmSource.enabled = false;
            bgmSource.enabled = true;

        }
        else if (SceneManager.GetActiveScene().name == "SpaceMap" &&
            _BGM.clip != BGMs[4])
        {
            _BGM.clip = BGMs[4];
            fsound.enabled = false;
            fsound.enabled = true;
            bgmSource.enabled = false;
            bgmSource.enabled = true;        
        }
        else if (SceneManager.GetActiveScene().name == "Result" &&
            _BGM.clip != BGMs[5])
        {
            _BGM.clip = BGMs[5];
            fsound.enabled = false;
            bgmSource.enabled = false;
            bgmSource.enabled = true;
        }

        if (NGM.restart_state)
        {
            NGM.restart_state = false;
            //Destroy(gameObject);
        }
    }
}
