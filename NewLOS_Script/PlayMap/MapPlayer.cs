using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPlayer : MonoBehaviour
{
    MapTimer MapTimer;
    BoatControl PlayerScript;
    GemPoint GPoint;
    SFXManager SFXObj;
    GameManager gmanager;
    
    public GameObject missionFail;
    public GameObject missionClear;
    public Text ResultText;

    bool resultOn = true;
    string new_Line = System.Environment.NewLine;
    int ResultMoney = 0;
    void Start()
    {
        MapTimer = GameObject.Find("TIMER").GetComponent<MapTimer>();
        PlayerScript = GameObject.Find("Player").GetComponent<BoatControl>();
        SFXObj = GameObject.Find("Player").GetComponent<SFXManager>();
        GPoint = GameObject.Find("Gem").GetComponent<GemPoint>();      
        gmanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (MapTimer.timeCount <= 0 || PlayerScript.Maxhp <= 0 && PlayerScript.MapClear == false)
        {
            missionFail.SetActive(true);            
            PlayerScript.MapFail = true;
        }

        if (PlayerScript.MapClear == true)
        {          
            if(resultOn == true)
            {
                missionClear.SetActive(true);
                MoneyResult();               
                resultOn = false;
            }           
        }
    }

    void MoneyResult()
    {
        ResultMoney = gmanager.myinfo.MapLevel *
            ((MapTimer.timeCount * 5)+
            (PlayerScript.Maxhp * 10) +
            (GPoint.GetGem * 300));

        gmanager.myinfo.money += ResultMoney;

        ResultText.text =
            "CLEAR TIME : " + MapTimer.timeCount.ToString() + "X 5" + new_Line +
            "CLEAR HP : " + PlayerScript.Maxhp.ToString() + "X 10" + new_Line +
            "GEM : " + GPoint.GetGem.ToString() + "X 300" + new_Line +
            "MODE BOUNS : " + "X " + gmanager.myinfo.MapLevel.ToString() + new_Line + new_Line +
            "RESULT : " + ResultMoney.ToString();
    }
}
