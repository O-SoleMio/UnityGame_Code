using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl : MonoBehaviour
{
    GameManager gameManager;
    GameObject Player;
    Vector3 viewPos;
    Touch touch;
    Vector2 touchPos;
    
    Camera cam;
    public bool gameOver = true;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();       
        Player = GameObject.Find("Player");
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        StartCoroutine("MoveOn");
    }
    IEnumerator MoveOn()
    {
        while (true)
        {
            viewPos = cam.WorldToViewportPoint(Player.transform.position);//화면 밖으로 못나가게 하기위함         

            if (Input.GetKey(KeyCode.RightArrow) && viewPos.x < 0.97f)
            {
               
                Player.transform.Translate(Vector2.right * Time.deltaTime * gameManager.speed);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && viewPos.x > 0.03f)
            {
                Player.transform.Translate(Vector2.left * Time.deltaTime * gameManager.speed);
            }
            if (Input.GetKey(KeyCode.UpArrow) && viewPos.y < 0.97f)
            {
                Player.transform.Translate(Vector2.up * Time.deltaTime * gameManager.speed);
            }
            if (Input.GetKey(KeyCode.DownArrow) && viewPos.y > 0.03f)
            {
                Player.transform.Translate(Vector2.down * Time.deltaTime * gameManager.speed);
            }
            yield return null;
        }
    }
}
