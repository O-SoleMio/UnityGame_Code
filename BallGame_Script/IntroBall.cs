using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroBall : MonoBehaviour
{
    GameObject introBallParent; 
    
    List<Image> introBallList = new List<Image>();
    Color color;
    public float albedo = 0.5f;
    void Start()
    {

        introBallParent = GameObject.Find("ParentBall");
        for(int i = 0;i <  introBallParent.transform.childCount;i++)
        {
            introBallList.Add(introBallParent.transform.GetChild(i).gameObject.GetComponent<Image>());            
        }
        color = introBallList[0].color;
        StartCoroutine(PingPongAlbedo());
    }

    IEnumerator PingPongAlbedo()
    {      
        while(true)
        {
            color.a = Mathf.PingPong(albedo, 1);
            albedo += Time.deltaTime * 0.5f;
            if(albedo > 1.5f)
            {
                albedo = 0.5f;
            }
            for(int i = 0;i < introBallList.Count ;i++)
            {
                introBallList[i].color = color;
            }
            yield return null;
        }      
    }   
}
