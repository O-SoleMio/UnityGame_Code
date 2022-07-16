using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DamageText : MonoBehaviour
{
    public List<Text> damageList = new List<Text>();
    [SerializeField] GameObject damagePool; // damageText 부모 오브젝트
    [SerializeField] GameObject damageText; // damageText prefab
    Color startTextColor;
    private void Start()
    {       
        CreateDamageText();      
    }
    void CreateDamageText()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(damageText, damagePool.transform);
            damageList.Add(damagePool.transform.GetChild(i).GetComponent<Text>());
        }
        startTextColor = damageList[0].color;
    }
    
    public void HitMonster(Vector3 HitPos,int damage) // 데미지를 표시할 지점, 표시할 데미지
    {
        HitPos.x -= 1; // 위치 조정
        HitPos.y -= 1; 
        for (int i = 0; i < damageList.Count; i++)
        {
            if (damageList[i].gameObject.activeSelf == false)
            {
                damageList[i].gameObject.transform.position = HitPos;
                damageList[i].text = damage.ToString();
                StartCoroutine(DamageView(damageList[i]));
                break;
            }
            else if(damageList[damageList.Count - 1].gameObject.activeSelf == true)
            {
                Instantiate(damageText, damagePool.transform);
                damageList.Add(damagePool.transform.GetChild(damageList.Count - 1).GetComponent<Text>());
            }
        }
    }

    public IEnumerator DamageView(Text damageText)
    {
        Color color;
        color = startTextColor;
        damageText.color = startTextColor; // 색깔 원래대로    
        damageText.gameObject.SetActive(true);
        //float delayTime = 0.3f; // 0.3초 뒤 사라짐
        while (true)
        {                           
            color.a -= Time.deltaTime * 2f; // color.a 은 1이다.
            damageText.color = color;
            damageText.transform.Translate(Vector2.up * Time.deltaTime * 5.0f); //위로 올라감
            //delayTime -= Time.deltaTime;
            if (color.a < 0)//if(delayTime < 0) // 시간으로 설정도 가능
            {                
                damageText.gameObject.SetActive(false);
                break;
            }
            yield return null;
        }       
    }
}
