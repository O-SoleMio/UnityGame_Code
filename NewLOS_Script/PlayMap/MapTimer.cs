using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapTimer : MonoBehaviour
{
    public int timeCount;
    public float secondtime;
    public Text textTimer;
    BoatControl PlayerScript;
    string scenename;
    void Start()
    {
        timeCount = 150;
        textTimer = GameObject.Find("TIMER").GetComponent<Text>();
        PlayerScript = GameObject.Find("Player").GetComponent<BoatControl>();
        scenename = SceneManager.GetActiveScene().name;
        if (scenename == "BonusMap") timeCount = 100;
        textTimer.text = timeCount.ToString();
    }
    void Update()
    {
        if (PlayerScript.MapClear == false && PlayerScript.MapFail == false)
        {
            secondtime += Time.deltaTime;
            if (secondtime > 1.0f)
            {
                timeCount -= 1;
                secondtime = 0;
                textTimer.text = timeCount.ToString();
            }
        }        
    }
}
