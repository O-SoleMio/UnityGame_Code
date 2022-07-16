using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPooling : MonoBehaviour
{
    //20200411 마지막 폭탄 개수 조정
    //폭탄
    public GameObject bomb;
    public GameObject bombEffect;   
    public Transform MapParent;
    public Transform ProjecterParent;
    GameObject obj;
    GameObject obj2;

    int bombNum = 1;
    [SerializeField]
    int[] randomNum;
    [SerializeField]
    Transform[] Projecter;
    int stackNum;
    [SerializeField]
    int TrueMapNum = 0;
    int limitNum;
    int layerMask;
    
    //이펙트 부모
    public GameObject bombEffectparent;

    [SerializeField]
    List<GameObject> bombPooling = new List<GameObject>();
    [SerializeField]
    List<GameObject> bombEffectPooling = new List<GameObject>();
    [SerializeField]
    List<Transform> TargetMap = new List<Transform>();

    float BombTime;
    float DelayTime;
    float ProjecterTime;
    RaycastHit rayhit;

    canvas_script Cavas_DM;

    // Start is called before the first frame update
    void Awake()
    {
        Cavas_DM = GameObject.FindWithTag("canvas_DM").GetComponent<canvas_script>();

        Projecter = new Transform[3];
        for(int i = 0; i < 3; i++)
        {
            Projecter[i] = ProjecterParent.GetChild(i);
        }

        randomNum = new int[3];
        randomNum[0] = 101;
        randomNum[1] = 102;
        randomNum[2] = 103;
        TrueMapNum = MapParent.childCount;

        layerMask = 1 << LayerMask.NameToLayer("Land");
        for (int i = 0; i < MapParent.childCount; i++)
        {
            TargetMap.Add(MapParent.GetChild(i));
        }

        for (int i = 0; i < 4  ; i++)
        {
            obj = (GameObject)Instantiate(bomb);
            obj2 = (GameObject)Instantiate(bombEffect);
            
            bombPooling.Add(obj);
            bombEffectPooling.Add(obj2);

            obj.transform.parent = this.transform;
            obj2.transform.parent = bombEffectparent.transform;

            bombPooling[i].SetActive(false);
            bombEffectPooling[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (Cavas_DM.doplay && !Cavas_DM.stop_map)
        {
            DelayTime += Time.deltaTime;
            BombTime += Time.deltaTime;
            ProjecterTime += Time.deltaTime;

            for (int i = 0; i < bombNum; i++)
            {
                if (bombPooling[i].activeSelf)
                {                  
                    bombPooling[i].transform.Translate(0.0f, -0.1f, 0.0f);

                    if (Physics.Raycast(bombPooling[i].transform.position, -(bombPooling[i].transform.up), out rayhit, 0.5f, layerMask))
                    {
                        //Debug.Log("Boom");
                        bombPooling[i].SetActive(false);

                        bombEffectPooling[i].transform.position =
                            new Vector3(bombPooling[i].transform.position.x,
                            bombPooling[i].transform.position.y,
                            bombPooling[i].transform.position.z);


                        rayhit.transform.gameObject.SetActive(false);

                        bombEffectPooling[i].SetActive(false);
                        bombEffectPooling[i].SetActive(true);
                    }
                }
            }

            if (DelayTime > 5.0f && TrueMapNum != 0)
            {

                //bombPooling[0].transform.position =
                //    new Vector3(Random.Range(-(TargetMap[0].localScale.x * 0.3f), TargetMap[0].localScale.x * 0.3f),
                //    Random.Range(10.0f,12.0f),
                //    Random.Range(-(TargetMap[0].localScale.x * 0.3f),TargetMap[0].localScale.x * 0.3f));
                for (int i = 0; i < bombNum; i++)
                {

                    while (true)
                    {
                        randomNum[i] = Random.Range(0, MapParent.childCount); // 발판이 있으면 빠져나가고 없으면 계속 폭격

                        if (TargetMap[randomNum[i]].gameObject.activeSelf == true
                                && randomNum[0] != randomNum[1]
                                && randomNum[1] != randomNum[2]
                                && randomNum[0] != randomNum[2]
                                || TrueMapNum == 0)
                        {
                            if (TrueMapNum != 0)
                            {
                                TrueMapNum -= 1;
                            }

                            break;
                        }
                    }

                }
                for (int i = 0; i < bombNum; i++)
                {
                    bombPooling[i].transform.position =
                        new Vector3(TargetMap[randomNum[i]].position.x, 10.0f, TargetMap[randomNum[i]].position.z);

                    bombPooling[i].SetActive(true);

                    Projecter[i].position =
                            new Vector3(bombPooling[i].transform.position.x,
                            10.0f,
                            bombPooling[i].transform.position.z);

                    Projecter[i].gameObject.SetActive(true);
                }

                DelayTime = 0;
            }

            if (BombTime > 20.0f)
            {
                if (bombNum < 3)
                    bombNum += 1;

                BombTime = 0;
            }
        }
    }
}
