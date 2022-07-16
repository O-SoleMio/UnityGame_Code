using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StateText : MonoBehaviour
{
    public struct Textbox
    {
        public Text money;
        public Text luckycost;
        public Text gradecost;
        public Text hp;
        public Text speed;
        public Text cornering;
        public Text boatgrade;
        public Text mylucky;
        public Text mygrade;
    }
    Textbox textbox;
    public GameManager Gmanager;    
    void Start()
    {
        Gmanager = GameObject.Find("GameManager").GetComponent<GameManager>();        
        textbox.money = GameObject.Find("MONEY").GetComponent<Text>();
        textbox.mygrade = GameObject.Find("MYGRADETEXT").GetComponent<Text>();
        textbox.mylucky = GameObject.Find("MYLUCKYTEXT").GetComponent<Text>();

        textbox.hp = GameObject.Find("HP").GetComponent<Text>();
        textbox.speed = GameObject.Find("SPEED").GetComponent<Text>();
        textbox.cornering = GameObject.Find("CORNERING").GetComponent<Text>();
        textbox.boatgrade = GameObject.Find("OKBUTTON").GetComponent<Text>();
        textbox.gradecost = GameObject.Find("GRADEUPTEXT").GetComponent<Text>();
        textbox.luckycost = GameObject.Find("LUCKYUPTEXT").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {       
        textbox.money.text = Gmanager.myinfo.money.ToString();
        textbox.mygrade.text = Gmanager.myinfo.myGrade.ToString();
        textbox.mylucky.text = Gmanager.myinfo.myLucky.ToString();

        textbox.boatgrade.text = "GRADE : " + Gmanager.myinfo.boatGrade.ToString();
        textbox.hp.text = "HP : " + Gmanager.myinfo.hp.ToString();
        textbox.speed.text = "SPEED : " + Gmanager.myinfo.speed.ToString();
        textbox.cornering.text = "CORNERING : " + Gmanager.myinfo.cornering.ToString();

        if (Gmanager.myinfo.myLucky != 5)
            textbox.luckycost.text = "(LUCKY UP) : COST " + Gmanager.myinfo.luckycost.ToString();
        else if (Gmanager.myinfo.myLucky == 5)
            textbox.luckycost.text = "MAX LEVEL";

        if (Gmanager.myinfo.myGrade != 5)
           textbox.gradecost.text = "(GRADE UP) : COST " + Gmanager.myinfo.gradecost.ToString();
        else if (Gmanager.myinfo.myGrade == 5)
            textbox.gradecost.text = "MAX LEVEL";
    }
}
