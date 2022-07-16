using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBoard : MonoBehaviour
{
    GameObject gameManager;
    GameObject soundManager; 
    
    public void ReStart()
    {
        SceneManager.LoadScene("Intro");
        Time.timeScale = 1.0f;   
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();       
#endif
    }
}
