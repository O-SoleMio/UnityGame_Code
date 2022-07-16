using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
public class BoatControl : MonoBehaviour
{
    public GameObject playBoat;
    public GameObject startPoint;
    GameObject EndPoint;
    GameObject GhostSound;
    
    //이펙트///////////
    GameObject RespawnFX;
    GameObject FullSpeedFX;
    GameObject EndTarget;
    ////////////

    //UI///////////
    Slider hpbar;
    public Text hptext;
    Slider speedbar;
    public Text speedtext;
    ///////////////

    public int Maxhp;   
    public float PlusSpeed;
    public float MaxSpeed;
    public float MaxCornering;
    public float speed = 0;
    public float Cornering;
    
    GameManager Gmanager;
    SFXManager SFXObj;

    float TickCount;
    float TickSpeedUp;
    float TickSpeedDown;
    float Second;
    float GhostTick;

    public bool MapClear = false;
    public bool MapFail = false;
    bool FogInOut = false;
    bool CrazyMode = false;

    //카메라 세팅
    public PostProcessProfile Profile;
    public Grain CameraPost;   
    void Start()
    {
        Gmanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        SFXObj = gameObject.GetComponent<SFXManager>();
        hptext = GameObject.Find("HPTEXT").GetComponent<Text>();
        speedtext = GameObject.Find("SPEEDTEXT").GetComponent<Text>();
        hpbar = GameObject.Find("HPBAR").GetComponent<Slider>();
        speedbar = GameObject.Find("SPEEDBAR").GetComponent<Slider>();
        RespawnFX = GameObject.Find("ReSpawnBlue");
        FullSpeedFX = GameObject.Find("SpeedFX");       
        EndPoint = GameObject.Find("EndPoint");
        EndTarget = GameObject.Find("EndTarget");
        
        startPoint = GameObject.Find("StartPoint");
        playBoat = this.gameObject;

        MaxSpeed = Gmanager.myinfo.speed * 0.01f;
        Maxhp = Gmanager.myinfo.hp;
        PlusSpeed = MaxSpeed * 0.1f;
        MaxCornering = Gmanager.myinfo.cornering;
        Cornering = MaxCornering;      

        if (SceneManager.GetActiveScene().name == "CrazyMap") CrazyMode = true;
        if (CrazyMode == true)
        {
            EndTarget.SetActive(false);
            GhostSound = GameObject.Find("GhostSound");
            GhostSound.SetActive(false);
            Profile = GameObject.Find("Camera").GetComponent<PostProcessVolume>().profile;
            Profile.TryGetSettings<Grain>(out CameraPost);
            CameraPost.enabled.value = false;
        }       
    }
    void Update()
    {              
        if(MapClear == false && MapFail == false)
        {
            BoatCon();//배 조종관련          
            FXActive();//경계선 닿았을 때 귀환이펙트
            TargetOn();//최종목표 방향표시            
            TextUpdate();//HP,SPEED바 텍스트
        }
        
        if(Maxhp <= 0)//체력 0이 되었을 때
        {
            hptext.text = "HP : 0";
            hpbar.value = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MapLine")
        {
            speed = 0;
            playBoat.transform.position = startPoint.transform.position;
            playBoat.transform.rotation = Quaternion.Euler(0, 0, 0);
            RespawnFX.SetActive(true);
        }

        if (other.tag == "Bomb")
        {
            Maxhp -= 10;
            speed = speed * 0.5f;
            SFXObj.BoomSFX();
        }

        if (other.tag == "EndPoint")
        {
            SFXObj.GetGemSFX();
            MapClear = true;
        }

        if (other.tag == "DarkFog")
        {
            FogInOut = true;
            EndTarget.SetActive(false);
            StartCoroutine(FogDamage());                      
        }

        if(other.tag == "Ghost")
        {
            StartCoroutine(GhostCurse());
            CameraPost.enabled.value = true;
            Maxhp -= 10;
            SFXObj.GhostSFX();
            GhostSound.SetActive(true);
            CameraPost.enabled.value = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "DarkFog")
        {            
            FogInOut = false;
            if(CrazyMode == false) EndTarget.SetActive(true);            
        }
    }
    void TextUpdate()
    {
        hptext.text = "HP : " + Maxhp.ToString();
        speedtext.text = "SPEED : " + (speed * 100.0f).ToString("N1");
        hpbar.value = (float)Maxhp / Gmanager.myinfo.hp;
        speedbar.value = speed / MaxSpeed;
    }
    void FXActive()
    {
        TickCount += Time.deltaTime;

        if (TickCount > 10.0f)
        {
            RespawnFX.SetActive(false);
            TickCount = 0;
        }      
    }
    void TargetOn()
    {
        EndTarget.transform.position = new Vector3(playBoat.transform.position.x,5.0f,playBoat.transform.position.z);
        EndTarget.transform.LookAt(EndPoint.transform.position);       
    }
    
    IEnumerator FogDamage()
    {       
        while(true)
        {
            if (FogInOut == false){ 
                break; 
            }
            Maxhp -= 1;          
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator GhostCurse()
    {
        WaitForSeconds wait = new WaitForSeconds(2);
        while (true)
        {
            Maxhp -= 1;
            yield return wait;
        }
    }
    void BoatCon()
    {      
        playBoat.transform.Translate((Vector3.forward * speed * (Time.deltaTime * 100)));

        if (Input.GetKey(KeyCode.Space)) //가속
        {
            if (speed < MaxSpeed)
            {
                speed += PlusSpeed * Time.deltaTime;                
            }
                
        }
        else
        {
            if (speed > 0)
            {
                speed -= PlusSpeed * Time.deltaTime;                
            }                
            else if (speed < 0)
                speed = 0;
        }

        if (Input.GetKey(KeyCode.LeftShift)) //감속
        {
            if (speed > 0)
            {
                speed -= 2.0f * PlusSpeed * Time.deltaTime;                
            }              
            else if (speed < 0)
                speed = 0;

            Cornering = MaxCornering * 2.0f;
        }
        else
        {
            Cornering = MaxCornering;
        }

        if (speed >= MaxSpeed && Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.Space))
        {
            speed = MaxSpeed * 1.3f;
            Cornering = MaxCornering * 0.5f;
            FullSpeedFX.SetActive(true);
            FullSpeedFX.transform.position = new Vector3(playBoat.transform.position.x, 1.0f, playBoat.transform.position.z);      
        }
        else
        {
            if (speed >= MaxSpeed) speed = MaxSpeed; //최대속력 보정            
            FullSpeedFX.SetActive(false);
        }

        if (speed > 0) // 좌우 방향 조절
        {
            if (Input.GetKey(KeyCode.LeftArrow)) playBoat.transform.Rotate(new Vector3(0, -(Cornering * Time.deltaTime), 0));
            if (Input.GetKey(KeyCode.RightArrow)) playBoat.transform.Rotate(new Vector3(0, (Cornering * Time.deltaTime), 0));
        }
    }
}
