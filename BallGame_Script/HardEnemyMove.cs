using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemyMove : MonoBehaviour
{
    GameObject Player;
    GameObject BossEnemy;
    EnemyBall enemyBall;

    public List<float> speed = new List<float>();
    public List<float> dis = new List<float>();
    public List<float> radian = new List<float>();
    public List<float> degree = new List<float>();
    public List<float> XPos = new List<float>();
    public List<float> YPos = new List<float>();

    List<GameObject> EnemyList = new List<GameObject>();

    void Start()
    {
        Player = GameObject.Find("Player");
        BossEnemy = GameObject.Find("BossEnemy");
        enemyBall = GameObject.Find("Enemy").GetComponent<EnemyBall>();
        EnemyList = enemyBall.HardEnemyList;
        StartCoroutine(MoveOn());
    }

    IEnumerator MoveOn()
    {
        int i = 0;
        
        while (true)
        {
            for (i = 0; i < EnemyList.Count; i++)
            {
                radian[i] = degree[i] * Mathf.Deg2Rad;
                XPos[i] = BossEnemy.transform.position.x + (float)System.Math.Round(dis[i] * Mathf.Cos(radian[i]), 3);
                YPos[i] = BossEnemy.transform.position.y + (float)System.Math.Round(dis[i] * Mathf.Sin(radian[i]), 3);

                EnemyList[i].transform.position = new Vector3(XPos[i], YPos[i], EnemyList[i].transform.position.z);
                degree[i] += Time.deltaTime * (72.0f / enemyBall.HardEnemyTime) * speed[i];
                if (degree[i] > 360.0f)
                {
                    degree[i] = 0;
                }                
            }
            yield return null;
        }
    }
}
