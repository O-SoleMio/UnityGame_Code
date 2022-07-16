using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    GameManager gmanager;
    public int RandomNum;
    private void Start()
    {
        gmanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        RandomNum = Random.Range(0, 100);
    }
    public void PickEasy()
    {
        if ((gmanager.myinfo.myLucky * 2) > RandomNum)
        { 
            BonusMap(); 
        }
        else
        {
            SceneManager.LoadScene("EasyMap");
            gmanager.myinfo.MapLevel = 1;
        }       
    }
    public void PickNormal()
    {
        if ((gmanager.myinfo.myLucky * 2) > RandomNum)
        {
            BonusMap();
        }
        else
        {
            SceneManager.LoadScene("NormalMap");
            gmanager.myinfo.MapLevel = 2;
        }       
    }

    public void PickHard()
    {
        if ((gmanager.myinfo.myLucky * 2) > RandomNum)
        {
            BonusMap();
        }
        else
        {
            SceneManager.LoadScene("HardMap");
            gmanager.myinfo.MapLevel = 4;
        }        
    }

    public void PickCrazy()
    {
        if ((gmanager.myinfo.myLucky * 2) > RandomNum)
        {
            BonusMap();
        }
        else
        {
            SceneManager.LoadScene("CrazyMap");
            gmanager.myinfo.MapLevel = 10;
        }      
    }

    void BonusMap()
    {        
        SceneManager.LoadScene("BonusMap");
        gmanager.myinfo.MapLevel = 5;       
    }
}
