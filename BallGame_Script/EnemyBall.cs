using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : MonoBehaviour
{ 
    public List<GameObject> EasyEnemyList = new List<GameObject>();
    public List<GameObject> HardEnemyList = new List<GameObject>();

    HardEnemyMove hardEnemyMove;
    EnemyMove enemyMove;

    IEnumerator moveOn;

    GameObject enemyParent;
    public GameObject Player;
    public GameObject BossEnemy;
    public GameObject EasyEnemy;
    public GameObject HardEnemy;
    public GameObject EasyEnemyParent;
    public GameObject HardEnemyParent;

    GameManager gameManager;

    float delayTime;
    int easyEnemyNum = 0;
    float easyEnemyDelay = 0f;
    public float HardEnemyTime = 0.5f;//하드적 생성 시간. HardEnemyMove에 넘겨주기 위함  

    Vector2 targetRot;
    void Start()
    {
        Player = GameObject.Find("Player");
        enemyParent = GameObject.Find("Enemy");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyMove = enemyParent.GetComponent<EnemyMove>();
        hardEnemyMove = enemyParent.GetComponent<HardEnemyMove>();
        
        moveOn = enemyMove.MoveOn();
        StartCoroutine(EnemyCreate());
        StartCoroutine(moveOn);        
    }
    
    IEnumerator EnemyCreate()
    {
        int i = 0;
        easyEnemyNum = gameManager.easyEnemyNum;
        easyEnemyDelay = gameManager.easyEnemyDelay;
        while(true)
        {
            Instantiate(EasyEnemy, BossEnemy.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)), EasyEnemyParent.transform);
            EasyEnemyList.Add(EasyEnemyParent.transform.GetChild(i).gameObject);
            
            i += 1;
            if(i == easyEnemyNum)
            {
                StartCoroutine(HardEnemyCreate());
                BossEnemyMove();
                break;//생성이 끝났다면 HardEnemy 소환
            }
                         
            yield return new WaitForSeconds(easyEnemyDelay);//n초 마다 생성
        }               
    }

    IEnumerator HardEnemyCreate()
    {
        int i = 0;
        float degree = 0;
        while (true)
        {
            Instantiate(HardEnemy, BossEnemy.transform.position, Quaternion.Euler(0, 0, degree), HardEnemyParent.transform);
            HardEnemyList.Add(HardEnemyParent.transform.GetChild(i).gameObject);
            
            hardEnemyMove.speed.Add(1);
            hardEnemyMove.dis.Add(1);
            hardEnemyMove.radian.Add(0);
            hardEnemyMove.degree.Add(0);
            hardEnemyMove.XPos.Add(0);
            hardEnemyMove.YPos.Add(0);

            i += 1;
            
            if(i == 5)
            {
                for (int j = 0; j < 5; j++)
                {
                    hardEnemyMove.speed[j] += 0.5f;
                    hardEnemyMove.dis[j] += 0.5f;
                }
            }
            if(i == 10)
            {
                for (int j = 0; j < 10; j++)
                {
                    hardEnemyMove.speed[j] += 0.5f;
                    hardEnemyMove.dis[j] += 0.5f;
                }
            }
            if(i == 15)
            {
                StartCoroutine(HardEnemyRot());
                break;                
            }
            yield return new WaitForSeconds(HardEnemyTime);
        }
    }

    IEnumerator HardEnemyRot()//n초 마다 회전 방향 반전
    {
        while(true)
        {
            for(int i =0; i < 15;i++)
            {
                hardEnemyMove.speed[i] *= -1.0f;
            }           
            yield return new WaitForSeconds(5.0f);
        }       
    }
    void BossEnemyMove()
    {
        int bossPattern = Random.Range(0, 10);

        if(bossPattern < 3)
        {      
            StartCoroutine(BossRushX());          
        }
        else if(bossPattern < 6)
        {
            StartCoroutine(BossRushY());
        }
        else if(bossPattern < 8)
        {         
            Invoke("TargetPlayer", 5.0f);
        }
        else if(bossPattern < 10)
        {            
            StartCoroutine(BossIn());
        }       
    }
    IEnumerator BossRushX()
    {
        float rushPoint = Player.transform.position.x;

        while (true)
        {
            BossEnemy.transform.position =
                new Vector3
                (Mathf.MoveTowards(BossEnemy.transform.position.x, rushPoint, Time.deltaTime),
                 BossEnemy.transform.position.y
                , BossEnemy.transform.position.z);

            if (Mathf.Approximately(BossEnemy.transform.position.x, rushPoint))//근사값
            {
                Invoke("BossEnemyMove", 1.0f);
                break;
            }
            yield return null;
        }
    }
    IEnumerator BossRushY()
    {
        float rushPoint = Player.transform.position.y;
        
        while(true)
        {            
            BossEnemy.transform.position =
                new Vector3
                (BossEnemy.transform.position.x,
                 Mathf.MoveTowards(BossEnemy.transform.position.y,rushPoint, Time.deltaTime)
                ,BossEnemy.transform.position.z);

            if (Mathf.Approximately(BossEnemy.transform.position.y, rushPoint))//근사값
            {
                Invoke("BossEnemyMove", 1.0f);
                break;
            }
            yield return null;
        }       
    }
    void TargetPlayer()
    {
        int i;
        
        for (i = 0; i < EasyEnemyList.Count; i++)
        {
            targetRot.x = Player.transform.position.x - EasyEnemyList[i].transform.position.x;
            targetRot.y = Player.transform.position.y - EasyEnemyList[i].transform.position.y;

            EasyEnemyList[i].transform.rotation =
                Quaternion.Euler(0, 0, -1 * Mathf.Atan2(targetRot.x, targetRot.y) * Mathf.Rad2Deg);        
        }
        BossEnemyMove();
    }

    IEnumerator BossIn()
    {
        StopCoroutine(moveOn);
        float result = 0;
        while(true)
        {
            int i;
            for (i = 0; i < EasyEnemyList.Count ;i++)
            {
                EasyEnemyList[i].transform.position =
                    Vector3.MoveTowards(EasyEnemyList[i].transform.position,BossEnemy.transform.position,Time.deltaTime * 2);
                result +=
                    Vector3.Distance(BossEnemy.transform.position, EasyEnemyList[i].transform.position);              
            }
            if (result < 0.1f)
            {
                Invoke("RandomShot", 1.0f);
                break;
            }                
            else 
                result = 0;

            yield return null;
        }
    }
    void RandomShot()
    {
        int i;        
        for (i = 0; i < EasyEnemyList.Count; i++)
        {
            EasyEnemyList[i].transform.rotation =
                Quaternion.Euler(0, 0, Random.Range(0, 360));
        }
        StartCoroutine(moveOn);
        Invoke("BossEnemyMove",5.0f);
    }
}
