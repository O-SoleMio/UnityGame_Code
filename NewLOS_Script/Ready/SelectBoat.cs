
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

static class ConstNum
{
    public const int HP = 20;
    public const float SPEED = 20.0f;
    public const float CORNER = 10.0f;
    public const int LUCKYCOST = 5000;
    public const int GRADECOST = 10000;
}

public class SelectBoat : MonoBehaviour
{
    public List<GameObject> BoatList = new List<GameObject>();
    public GameObject Select;
    public GameObject Level;
    
    int childSize; 
    int a = 0;

    public GameManager Gmanager;

    void Start()
    {
        Gmanager = GameObject.Find("GameManager").GetComponent<GameManager>();//GameManager 수치변경을 위한 캐싱
        Select = GameObject.Find("Selectboat");
        Level = GameObject.Find("Select").transform.Find("GameLevel").gameObject;//GameLevel이 비활성화 되어있어서 부모를 찾은 후 탐색

        childSize = transform.childCount;
        for (int i = 0; i < childSize; i++)
            BoatList.Add(transform.GetChild(i).gameObject);//보트 정리
    }  
    public void RightBoat()
    {
        BoatList[a].SetActive(false);
        a += 1;
        if (a == childSize) a = 0;
        BoatList[a].SetActive(true);
    }

    public void LeftBoat()
    {
        BoatList[a].SetActive(false);
        a -= 1;
        if (a == -1) a = childSize - 1;
        BoatList[a].SetActive(true);
    }
    void Update()
    { 
        if (a == 0)
        {
            Gmanager.myinfo.selectboat = BoatList[a];
            Gmanager.myinfo.hp = ConstNum.HP;            
            Gmanager.myinfo.speed = ConstNum.SPEED;
            Gmanager.myinfo.cornering = ConstNum.CORNER;
            Gmanager.myinfo.boatGrade = 1;
        }
        else if(a == 1)
        {
            Gmanager.myinfo.selectboat = BoatList[a];
            Gmanager.myinfo.hp = ConstNum.HP * 2;
            Gmanager.myinfo.speed = ConstNum.SPEED * 1.5f;
            Gmanager.myinfo.cornering = ConstNum.CORNER * 1.5f;
            Gmanager.myinfo.boatGrade = 2;
        }
        else if (a == 2)
        {
            Gmanager.myinfo.selectboat = BoatList[a];
            Gmanager.myinfo.hp = ConstNum.HP * 3;
            Gmanager.myinfo.speed = ConstNum.SPEED * 2.0f;
            Gmanager.myinfo.cornering = ConstNum.CORNER * 2.0f;
            Gmanager.myinfo.boatGrade = 3;
        }
        else if (a == 3)
        {
            Gmanager.myinfo.selectboat = BoatList[a];
            Gmanager.myinfo.hp = ConstNum.HP * 4;
            Gmanager.myinfo.speed = ConstNum.SPEED * 2.5f;
            Gmanager.myinfo.cornering = ConstNum.CORNER * 2.5f;
            Gmanager.myinfo.boatGrade = 4;
        }
        else if (a == 4)
        {
            Gmanager.myinfo.selectboat = BoatList[a];
            Gmanager.myinfo.hp = ConstNum.HP * 5;
            Gmanager.myinfo.speed = ConstNum.SPEED * 3.0f;
            Gmanager.myinfo.cornering = ConstNum.CORNER * 3.0f;
            Gmanager.myinfo.boatGrade = 5;
        }
    }
    public void OKButton()
    {
        if(Gmanager.myinfo.boatGrade <= Gmanager.myinfo.myGrade)
        {           
            Gmanager.Pickboat = Gmanager.Boatlist[a];
            Select.SetActive(false);
            Level.SetActive(true);
        }      
    }
    public void Luckybutton()
    {
        switch(Gmanager.myinfo.myLucky)
        {
            case 1 : if (Gmanager.myinfo.luckycost <= Gmanager.myinfo.money)
                {
                    Gmanager.myinfo.money -= Gmanager.myinfo.luckycost;
                    Gmanager.myinfo.luckycost = ConstNum.LUCKYCOST;
                    Gmanager.myinfo.myLucky += 1;
                }
                break;
            case 2:
                if (Gmanager.myinfo.luckycost <= Gmanager.myinfo.money)
                {
                    Gmanager.myinfo.money -= Gmanager.myinfo.luckycost;
                    Gmanager.myinfo.luckycost = ConstNum.LUCKYCOST * 2;
                    Gmanager.myinfo.myLucky += 1;
                }
                break;
            case 3:
                if (Gmanager.myinfo.luckycost <= Gmanager.myinfo.money)
                {
                    Gmanager.myinfo.money -= Gmanager.myinfo.luckycost;
                    Gmanager.myinfo.luckycost = ConstNum.LUCKYCOST * 5;
                    Gmanager.myinfo.myLucky += 1;
                }
                break;
            case 4:
                if (Gmanager.myinfo.luckycost <= Gmanager.myinfo.money)
                {
                    Gmanager.myinfo.money -= Gmanager.myinfo.luckycost;                   
                    Gmanager.myinfo.myLucky += 1;
                }
                break;           
        }
    }
    public void Gradebutton()
    {
        switch (Gmanager.myinfo.myGrade)
        {
            case 1:
                if (Gmanager.myinfo.gradecost <= Gmanager.myinfo.money)
                {
                    Gmanager.myinfo.money -= Gmanager.myinfo.gradecost;
                    Gmanager.myinfo.gradecost = ConstNum.GRADECOST;
                    Gmanager.myinfo.myGrade += 1;
                }
                break;
            case 2:
                if (Gmanager.myinfo.gradecost <= Gmanager.myinfo.money)
                {
                    Gmanager.myinfo.money -= Gmanager.myinfo.gradecost;
                    Gmanager.myinfo.gradecost = ConstNum.GRADECOST * 2;
                    Gmanager.myinfo.myGrade += 1;
                }
                break;
            case 3:
                if (Gmanager.myinfo.gradecost <= Gmanager.myinfo.money)
                {
                    Gmanager.myinfo.money -= Gmanager.myinfo.gradecost;
                    Gmanager.myinfo.gradecost = ConstNum.GRADECOST * 5;
                    Gmanager.myinfo.myGrade += 1;
                }
                break;
            case 4:
                if (Gmanager.myinfo.gradecost <= Gmanager.myinfo.money)
                {
                    Gmanager.myinfo.money -= Gmanager.myinfo.gradecost;                    
                    Gmanager.myinfo.myGrade += 1;
                }
                break;
        }
    }

    void SellButton()
    {

    }
}
