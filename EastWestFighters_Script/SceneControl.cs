using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public enum Map_List
{
    Ice,
    Pirates
}
public class SceneControl : MonoBehaviour
{
    public GameObject titleCanvas;
    public GameObject SelectCanvas;
    public GameObject startCanvas;
    public GameObject titleImage;
    public int titleNum;
    float FadeGrade;
    float FadeSpeed;
    float startTime;    

    public Map_List map;
    bool Map_Chice_Done;
    // Start is called before the first frame update
    void Start()
    {
        titleNum = 0;
        FadeGrade = 1.0f;
        FadeSpeed = 5;
        startTime = 0;
        titleCanvas.SetActive(true);
        startCanvas.SetActive(false);
        SelectCanvas.SetActive(false);

        map = Map_List.Ice;
        Map_Chice_Done = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch(titleNum)
        {
            case 0:
                titleScene();
                break;
            case 1:
                StartScene();
                break;
            case 2:
                SelectScene();
                break;
        }
        if(Map_Chice_Done == true)
        {
            SceneManager.LoadScene("Player_Choice");
        }
    }

    public void titleScene()
    {
        if(startTime < 3.0f)
        startTime += Time.smoothDeltaTime;

        if (startTime >= 3.0f)
        {
            FadeGrade -= Time.smoothDeltaTime / FadeSpeed;
            titleCanvas.GetComponent<Image>().color = titleImage.GetComponent<Image>().color = new Color(FadeGrade, FadeGrade, FadeGrade);
            if (FadeGrade < 0.0f)
            {
                titleNum = 1;
            }
        }
    }
    public void StartScene()
    {
        titleCanvas.SetActive(false);
        startCanvas.SetActive(true);
    }

    public void SelectScene()
    {
        titleNum = 2;
        startCanvas.SetActive(false);
        SelectCanvas.SetActive(true);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

    public void SceneNum1()
    {
        //SceneManager.LoadScene("IceMap");

        map = Map_List.Ice;
        Map_Chice_Done = true;
    }

    public void SceneNum2()
    {
        //SceneManager.LoadScene("BoatMap"); 
        map = Map_List.Pirates;
        Map_Chice_Done = true;
    }
}
