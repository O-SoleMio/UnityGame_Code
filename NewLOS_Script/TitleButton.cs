using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public GameObject OptionUI;
    private void Start()
    {
        OptionUI = this.transform.Find("Optionpopup").gameObject;
    }
    public void StartButton()
    {
        SceneManager.LoadScene("ReadyScene");
    }
    public void Exitbutton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();       
#endif
    }
    public void OptionButton()
    {
        if(OptionUI.activeSelf==false)
            OptionUI.SetActive(true);
        else
            OptionUI.SetActive(false);
    }   
}
