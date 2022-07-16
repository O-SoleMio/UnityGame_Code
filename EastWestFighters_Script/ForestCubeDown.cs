using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//색이 점점 진하게 변하고 최고치에 달하면 중력끄기
public class ForestCubeDown : MonoBehaviour
{
    const int CubeArraySize = 9;
    const int ProjecterSize = 4;
   const int PlayerCharSize = 4;

    RaycastHit rayhit;
    int layerMask;

    

    GameObject CubeParent;
    GameObject ProjecterParent;

    [SerializeField]
    Transform[] CubeArray = new Transform[CubeArraySize];

    GameObject PlayerParent;
    [SerializeField]
    Transform[] PlayerCharter = new Transform[PlayerCharSize]; //배열로 해야함 임시로 선언

    [SerializeField]
    Material[] ForestCubeMat = new Material[ProjecterSize];
    Transform[] ForestProjecter = new Transform[ProjecterSize];

    float[] CubeEmission;
    float[] SetAlpha = new float[4];
    float[] TickTime = new float[4];
    float SetPoint;

    //맵특성 정지용
    canvas_script Cavas_DM;

    void Awake()
    {
        layerMask = 1 << LayerMask.NameToLayer("Land");

        PlayerParent = GameObject.Find("Player");

        CubeParent = GameObject.Find("MapCube");
        ProjecterParent = GameObject.Find("MapDown");

        for (int i = 0; i < CubeParent.transform.childCount; i++)
        {
            CubeArray[i] = CubeParent.transform.GetChild(i);
        }

        for(int i = 0; i < ProjecterSize;i++)//마테리얼 캐싱, 캐릭터 불러오기
        {
            ForestProjecter[i] = ProjecterParent.transform.GetChild(i);

            ForestCubeMat[i] =
                ForestProjecter[i].GetComponent<Projector>().material;

            PlayerCharter[i] = PlayerParent.transform.GetChild(i);

            ForestCubeMat[i].SetFloat("_Alpha", 0.0f);
        }

        //맵특성 정지용
        Cavas_DM = GameObject.FindWithTag("canvas_DM").GetComponent<canvas_script>();
    }

    void Update()
    {
        if (Cavas_DM.doplay && !Cavas_DM.stop_map)
        {
            for (int i = 0; i < ProjecterSize; i++)// 4번 반복
            {
                TickTime[i] += Time.deltaTime;
                //프로젝터 위치 캐릭터에 맞춤
                ForestProjecter[i].transform.position =
                    new Vector3(PlayerCharter[i].position.x,
                    PlayerCharter[i].position.y + 0.5f,
                    PlayerCharter[i].position.z);
                //Debug.DrawRay(ForestProjecter[i].position, ForestProjecter[i].forward, Color.red, 1.0f);
                //레이캐스트 관련문
                if (Physics.Raycast(ForestProjecter[i].position, ForestProjecter[i].forward, out rayhit, 1.0f, layerMask))
                {
                    if (SetAlpha[i] > 1.0f)
                    {
                        rayhit.transform.gameObject.GetComponent<Rigidbody>().constraints =
                             RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ
                             | RigidbodyConstraints.FreezeRotation;
                    }
                    //Debug.Log(TickTime[i]);

                    if (TickTime[i] > 0.1f && SetAlpha[i] <= 1.0f)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            SetAlpha[i] += 0.001f;
                        }
                        TickTime[i] = 0;
                    }
                }
                else
                {
                    if (SetAlpha[i] < 1.0f)
                    {
                        SetAlpha[i] = 0;
                    }
                }
                ForestCubeMat[i].SetFloat("_Alpha", SetAlpha[i]);//큐브 알파값 변경
            }

        }
    }
}
