using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{   
    GameObject Player;
    Vector3 viewPos;
    Touch touch;
    Vector2 touchPos;
    float speed = 1.2f;
    Camera cam;
    public bool gameOver = true;
    
    void Start()
    {
        Player = GameObject.Find("Player");
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();       
        StartCoroutine("MoveOn");      
    }
    IEnumerator MoveOn()
    {        
        while(true)
        {
            viewPos = cam.WorldToViewportPoint(Player.transform.position);//화면 밖으로 못나가게 하기위함
            Vector3 touchPoint; 

            if (Input.GetKey(KeyCode.RightArrow) && viewPos.x < 0.97f)
            {
                Player.transform.Translate(Vector2.right * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && viewPos.x > 0.03f)
            {
                Player.transform.Translate(Vector2.left * Time.deltaTime * speed);
            }
            if(Input.GetKey(KeyCode.UpArrow) && viewPos.y < 0.97f)
            {
                Player.transform.Translate(Vector2.up * Time.deltaTime * speed);
            }
            if(Input.GetKey(KeyCode.DownArrow) && viewPos.y > 0.03f)
            {
                Player.transform.Translate(Vector2.down * Time.deltaTime * speed);
            }

            if (Input.touchCount > 0)
            {           
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    touchPos = Input.GetTouch(0).position;
                    touch = Input.GetTouch(0);
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Moved ||
                    Input.GetTouch(0).phase == TouchPhase.Stationary)
                {
                    touchPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    
                    Player.transform.position =
                        Vector3.MoveTowards
                        (Player.transform.position, 
                        new Vector3(touchPoint.x,touchPoint.y,0), 
                        Time.deltaTime * speed);                  
                }                                                         
            }
            yield return null;
        }
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EasyEnemy" || other.tag == "HardEnemy")
        {
            gameOver = true;          
        }
        
        //if(other.name == "EasyEnemy(Clone)") //이런 방식도 가능        
    }
}
