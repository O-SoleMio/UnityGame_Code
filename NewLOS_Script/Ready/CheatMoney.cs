using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatMoney : MonoBehaviour
{
    GameManager gmanager;
    float secondTime;
    public string moneyCheat;
    void Start()
    {
        gmanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(moneyCheat != null) secondTime += Time.deltaTime;
        if(secondTime > 3.0f)
        {
            moneyCheat = null;
            secondTime = 0;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            moneyCheat += "A";
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            moneyCheat += "D";
            if (moneyCheat == "AADAAD")
            {
                gmanager.myinfo.money = 999999;
                Destroy(gameObject);
            }
        }      
    }
}
