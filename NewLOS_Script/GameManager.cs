using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject Pickboat;
    public List<GameObject> Boatlist = new List<GameObject>();
    public struct Myinfo {       
        public GameObject selectboat;
        public int money;
        public int hp;
        public float speed;
        public float cornering;
        public int luckycost;
        public int gradecost;
        public int myGrade;
        public int boatGrade;
        public int myLucky;
        public int MapLevel;
    }
    public string moneyCheat;
    string scenename;
    public Myinfo myinfo;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
        Application.targetFrameRate = 60;   
    }
    void Start()
    {     
        myinfo.money = 0;
        myinfo.luckycost = 1000;
        myinfo.gradecost = 2000;
        myinfo.myGrade = 1;
        myinfo.myLucky = 1;
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
        scenename = SceneManager.GetActiveScene().name;
        if(scenename == "EasyMap" ||
            scenename == "NormalMap" ||
            scenename == "HardMap" ||
            scenename == "CrazyMap")
        {
            
        }
    }    
}
