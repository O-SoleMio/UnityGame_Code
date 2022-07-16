using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Camera cam;    
    Vector3 viewPos;
    List<GameObject> EnemyList = new List<GameObject>();
   
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        EnemyList = GameObject.Find("Enemy").GetComponent<EnemyBall>().EasyEnemyList;                      
    }

   
    public IEnumerator MoveOn()
    {
        int i;
        while (true)
        {
            for (i = 0; i < EnemyList.Count; i++)
            {               
                viewPos = cam.WorldToViewportPoint(EnemyList[i].transform.position);
                EnemyList[i].transform.Translate(Vector2.up * Time.deltaTime);

                if (viewPos.x > 1.0f || viewPos.x < 0f)
                {
                    EnemyList[i].transform.rotation = Quaternion.Euler(0, 0, -1 * EnemyList[i].transform.eulerAngles.z);
                    EnemyList[i].transform.Translate(Vector2.up * Time.deltaTime * 5);
                }
                if (viewPos.y > 1.0f || viewPos.y < 0f)
                {
                    EnemyList[i].transform.rotation = Quaternion.Euler(0, 0, (-1 * EnemyList[i].transform.eulerAngles.z + 180));
                    EnemyList[i].transform.Translate(Vector2.up * Time.deltaTime * 5);
                }              
            }
            yield return null;
        }
    }          
}
