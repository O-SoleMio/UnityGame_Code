using UnityEngine;

public class EnemyIce : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject obj;
    public GameObject House;
    public float change;
    public float dist;
    public bool InOut;
    float speed;
    bool Direction;
    float random;
    float time;
    float Ptime;
    public int number;
    // Start is called before the first frame update
    void Start()
    {
        number = 1;
        InOut = false;
        Direction = true;
        change = 1;
        dist = 0;
        speed = 0.5f;
        random = 180;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //speed += Time.deltaTime * 5;
        switch(number)
        {
            case 1:
                Pattern();
                break;
            case 2:
                dist = Vector3.Distance(obj.transform.position, Enemy.transform.position);
                Pattern2();
                break;
            case 3:
                Pattern3();
                break;
        }
        
    }

    void Pattern() // 출발좌표 잡아주기
    {
        speed = 0.5f;
        Enemy.SetActive(true);
        Enemy.transform.position = new Vector3
           (House.transform.position.x - 2,
            House.transform.position.y,
            House.transform.position.z);

        Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation,
                Quaternion.LookRotation((House.transform.transform.position - Enemy.transform.position)), 1.0f);

        number = 2;
        Debug.Log("Start");
    }

    void Pattern2() // 방해이동
    {
        Ptime += Time.deltaTime;

        speed += Time.deltaTime * 5;

        Enemy.transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (Direction == true)
        {
            Enemy.transform.rotation = Quaternion.Euler(0.0f, 0, random + change);//캐릭터 변경 시 변경해주기
        }

        if (time > 1.0f && dist >= 6 && dist < 6.5f)
        {
            Direction = true;
            if (random > 90)
            {
                random = Random.Range(-20.0f, 20.0f);
            }
            else
            {
                random = Random.Range(160.0f, 200.0f);
            }

            time = 0;
            speed = 0.5f;
        }
        else if(dist > 6.5f && time > 1.0f)
        {
            Direction = false;

            Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation,
                Quaternion.LookRotation(obj.transform.transform.position - Enemy.transform.position), 1.0f);

            //Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation,
                //Quaternion.LookRotation(House.transform.transform.position - Enemy.transform.position), 1.0f);

            time = 0;
            speed = 0.5f;
        }

        if(Ptime > 7.0f)
        {
            Ptime = 0;
            number = 3;
            speed = 0.5f;
        }
    }

    void Pattern3()///돌아가기
    {
        speed += Time.deltaTime * 5;
        Enemy.transform.Translate(Vector3.forward * Time.deltaTime * speed); // 앞으로 이동
        Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation,
                Quaternion.LookRotation(House.transform.transform.position - Enemy.transform.position), 1.0f); // 집 방향으로 고개 돌리기
        if (Enemy.activeSelf == false)
        {
            Ptime += Time.deltaTime;
        }       
        if(Ptime > 5.0f)
        {
            number = 1;
            Ptime = 0;
        }
    }
    ///////////////////////////////////////
    void OnTriggerEnter(Collider col)///집과 충돌하면 사라지게,복귀기능
    {
       
        if (col.CompareTag("EnemyIce"))
        {
            Enemy.SetActive(false);
            Debug.Log("Bang");
        }
    }
}
