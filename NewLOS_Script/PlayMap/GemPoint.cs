using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPoint : MonoBehaviour
{
    public List<GameObject> GemList = new List<GameObject>();
    public GameObject Player;
    public GameObject MoneyEffect;
    SFXManager SFXObj;
    public float dis;
    public int GetGem;
    void Start()
    {
        Player = GameObject.Find("Player");
        MoneyEffect = GameObject.Find("MoneyBoom");//이펙트수는 보석수와 같게
        SFXObj = Player.GetComponent<SFXManager>();
        GetGem = 0;
        for(int i = 0;i < gameObject.transform.childCount;i++)
        {
            GemList.Add(gameObject.transform.GetChild(i).gameObject);
            GemList[i].transform.position = new Vector3(gameObject.transform.position.x + (Random.Range(-600, 600)),0,
                gameObject.transform.position.z + (Random.Range(-1000, 1000)));
            MoneyEffect.transform.GetChild(i).position = GemList[i].transform.position;//보석과 이펙트의 위치를 같게 만들었음
        }
    }

    void Update()
    {
        for (int i = 0;i < GemList.Count ;i++)
        {
            //GemList[i].transform.Rotate(new Vector3(0,1.0f * Time.deltaTime,0)); // 회전 효과
            dis = Vector3.Distance(GemList[i].transform.position, Player.transform.position);
            if (dis < 5.0f && GemList[i].activeSelf == true) //거리가 5.0보다 작으면
            {
                GemList[i].SetActive(false);
                GetGem += 1;
                MoneyEffect.transform.GetChild(i).gameObject.SetActive(true);
                SFXObj.GetGemSFX();
            }                
        }
    }
}
