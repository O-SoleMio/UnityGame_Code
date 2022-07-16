using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject player;
    [SerializeField] GameObject parent;   

    GameManager gameManager;   

    private bool autoMode = false;
    List<GameObject> bulletList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();      
        CreateBullet();
        StartCoroutine(Shot());
        StartCoroutine(Mode());
    }

    void CreateBullet()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(bullet, player.transform.position, player.transform.rotation, parent.transform);
           
            bulletList.Add(parent.transform.GetChild(i).gameObject);
        }       
    }
    IEnumerator Mode()
    {
        while(true)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (autoMode) autoMode = false;
                else autoMode = true;                
            }
            yield return null;
        }
       
    }

    IEnumerator Shot()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && autoMode == false)
            {
                for(int i =0;  i < bulletList.Count;i++)
                {
                    if(bulletList[i].activeSelf == false)
                    {
                        bulletList[i].transform.position = player.transform.position;
                        bulletList[i].SetActive(true);
                        StartCoroutine(BulletMove(bulletList[i]));
                        break;
                    }    
                    else if(bulletList[bulletList.Count - 1].activeSelf == true)
                    {
                        Instantiate(bullet, player.transform.position, Quaternion.Euler(0, 0, 0), parent.transform);

                        bulletList.Add(parent.transform.GetChild(bulletList.Count - 1).gameObject);
                    }
                }
            }

            if(autoMode == true)
            {
                for (int i = 0; i < bulletList.Count; i++)
                {
                    if (bulletList[i].activeSelf == false)
                    {
                        bulletList[i].transform.position = player.transform.position;
                        bulletList[i].SetActive(true);
                        StartCoroutine(BulletMove(bulletList[i]));
                        break;
                    }
                    else if (bulletList[bulletList.Count - 1].activeSelf == true)
                    {
                        Instantiate(bullet, player.transform.position, Quaternion.Euler(0, 0, 0), parent.transform);

                        bulletList.Add(parent.transform.GetChild(bulletList.Count - 1).gameObject);
                    }
                }
                yield return new WaitForSeconds(gameManager.delay);
            }
          
            yield return null;
        }
    }
    IEnumerator BulletMove(GameObject bullet)
    {
        while(true)
        {
            if(bullet.activeSelf == false)
            {               
                break;
            }
            bullet.transform.Translate(Vector2.up * Time.deltaTime * gameManager.bulletSpeed);
            Vector3 Pos = Camera.main.WorldToViewportPoint(bullet.transform.position);
            if(Pos.y > 1.0f)
            {
                bullet.SetActive(false);             
                break;
            }
            yield return null;
        }     
    }
}
