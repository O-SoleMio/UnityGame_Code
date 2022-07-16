using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingColor : MonoBehaviour
{
    SpriteRenderer sprite;
    public GameObject Changer;
    void Start()
    {
        sprite = Changer.GetComponent<SpriteRenderer>();
        StartCoroutine(PingPongColor());
    }
    IEnumerator PingPongColor()
    {      
        float tick = 0;
        float r, g, b;
        r = Random.Range(0, 1.0f);
        g = Random.Range(0, 1.0f);
        b = Random.Range(0, 1.0f);


        while (true)
        {
            sprite.color =
                new Color(Mathf.PingPong(tick,r),
                Mathf.PingPong(tick,g),
                Mathf.PingPong(tick,b));            
            tick += Time.deltaTime * 0.5f;

            if(tick > 3f)
            {
                tick = 0;
                r = Random.Range(0, 1.0f);
                g = Random.Range(0, 1.0f);
                b = Random.Range(0, 1.0f);
            }
            
            yield return null;
        }        
    }    
}
