using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScale : MonoBehaviour //CloudZScale 관련 임시 주석처리함
{
    const int CloudSize = 10;

    //[SerializeField]
    Transform[] Cloudobj = new Transform[CloudSize];
    float[] CloudXpos = new float[CloudSize];
    float[] CloudYpos = new float[CloudSize];
    float[] CloudZpos = new float[CloudSize];

    float[] CloudXScale = new float[CloudSize];
    float[] CloudYScale = new float[CloudSize];
    //float[] CloudZScale = new float[CloudSize];

    float[] CloudXScaleSize = new float[CloudSize];
    float[] CloudYScaleSize = new float[CloudSize];
    //float[] CloudZScaleSize = new float[CloudSize];

    float CloudXScaleLimit;
    float CloudYScaleLimit;
    //float[] CloudZScaleLimit = new float[CloudSize];

    float[] CloudSpeed = new float[CloudSize];

    float TickCount;
    float TickCount2;

    Camera PickMainCamera;

    Vector3[] screenPoint = new Vector3[CloudSize];

    void Start()//초기설정
    {
        PickMainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        for(int i = 0; i < transform.childCount; i++)
        {
            Cloudobj[i] = transform.GetChild(i);
            CloudXpos[i] = Cloudobj[i].position.x;
            CloudYpos[i] = Cloudobj[i].position.y;
            CloudZpos[i] = Cloudobj[i].position.z;

            CloudXScale[i] = 0;
            CloudYScale[i] = 0;
            //CloudZScale[i] = 0;

            CloudXScaleSize[i] = Cloudobj[i].localScale.x;
            CloudYScaleSize[i] = Cloudobj[i].localScale.y;
            //CloudZScaleSize[i] = Cloudobj[i].localScale.z;
        }
        CloudXScaleLimit = Cloudobj[0].localScale.x * 1.5f;
        CloudYScaleLimit = Cloudobj[0].localScale.y * 1.2f;
        //CloudZScaleLimit = Cloudobj.localScale.z * 2;
    }

    // Update is called once per frame
    void Update()
    {
        TickCount += Time.deltaTime;
        TickCount2 += Time.deltaTime;

        if(TickCount > 0.1f)
        {
            for(int i =0; i < transform.childCount;i++)
            {
                CloudSpeed[i] = Random.Range(0.001f, 0.002f); // 각자 다른 속도 배정                              
            }
            TickCount = 0;
        }

        if (TickCount2 > 1.0f)
        {
            for (int k = 0; k < transform.childCount; k++)
            {
                CloudXScale[k] = Random.Range(-0.0002f, 0.0002f);
                CloudYScale[k] = Random.Range(-0.0002f, 0.0002f);
                //CloudZScale[k] = Random.Range(-0.001f, 0.001f);
            }
            TickCount2 = 0;
        }

        for (int i = 0; i < transform.childCount; i++) //실질적 구름 크기,속도 조절
        {
            for(int j = 0;j < 5 ;j++)//부드러운 이동을 위해 나눠서 연산
            {
                CloudXpos[i] += CloudSpeed[i];

                Cloudobj[i].transform.position =
                    new Vector3(CloudXpos[i], CloudYpos[i], CloudZpos[i]);               
            }
            
            for(int j = 0; j < 2 ;j++)//부드러운 변화를 위해 나눠서 연산
            {
                if(CloudXScaleLimit < CloudXScaleSize[i])//크기 제한
                    CloudXScale[i] = -0.001f;
                if (CloudXScaleLimit * 0.5f > CloudXScaleSize[i])
                    CloudXScale[i] = 0.001f;

                if (CloudYScaleLimit < CloudYScaleSize[i])//크기 제한
                    CloudYScale[i] = -0.001f;
                if (CloudYScaleLimit * 0.5f > CloudYScaleSize[i])
                    CloudYScale[i] = 0.001f;

                CloudXScaleSize[i] += CloudXScale[i];
                CloudYScaleSize[i] += CloudYScale[i];
                //CloudZScaleSize[i] += CloudZScale[i];

                Cloudobj[i].transform.localScale =
                 new Vector3(CloudXScaleSize[i], CloudYScaleSize[i], Cloudobj[i].localScale.z/*CloudZScaleSize[i]*/);
            }
                

            //안에 구름이 있는지 확인
            screenPoint[i] = PickMainCamera.WorldToViewportPoint(Cloudobj[i].transform.position);

            if (screenPoint[i].x > 1.1f)
            {
                CloudXpos[i] = -45.0f;
                CloudYpos[i] = Random.Range(1.0f, 13.0f);
            }
        }
    }
}
