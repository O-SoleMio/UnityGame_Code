using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBreak : MonoBehaviour
{
    public Transform EffectParent;
    public Transform CubeParent;
    public Transform PointParent;

    float getTime;
    float cubeSpeed;
    float limitSpeed;
    float randomSpeed;

    [SerializeField]
    float dist;
    int wallNum;
    [SerializeField]
    int goPoint;
    [SerializeField]
    int resultPoint;
    WallMove WallCube;
    bool cubeMove = false;

    [SerializeField]
    List<Transform> effectSlot= new List<Transform>();
    [SerializeField]
    List<Transform> cubeSlot = new List<Transform>();
    [SerializeField]
    List<Transform> cubeSlot2 = new List<Transform>();
    [SerializeField]
    List<Transform> pointSlot = new List<Transform>();

    canvas_script Cavas_DM;

    // Start is called before the first frame update
    void Awake()
    {        
        for(int i = 0; i <EffectParent.childCount;i++)
        {
            effectSlot.Add(EffectParent.GetChild(i));
        }

        for(int i = 0; i < 4; i++)
        {
            cubeSlot.Add(CubeParent.GetChild(i));

            effectSlot[i].position = cubeSlot[i].position;
        }

        for(int i = 4; i <CubeParent.childCount - 1;i++)
        {
            cubeSlot2.Add(CubeParent.GetChild(i));
        }

        for(int i = 0; i < PointParent.childCount;i++)
        {
            pointSlot.Add(PointParent.GetChild(i));
        }

        resultPoint = 0;
        goPoint = 1;
        wallNum = 0;
        dist = 0;
        cubeSpeed = 1;
        limitSpeed = 5.0f;
        randomSpeed = 1;

        Cavas_DM = GameObject.FindWithTag("canvas_DM").GetComponent<canvas_script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Cavas_DM.doplay && !Cavas_DM.stop_map)
        {
            getTime += Time.deltaTime;

            if (getTime > 4.5f && wallNum < 4 && effectSlot[4].gameObject.activeSelf == false)
            {
                effectSlot[4].position = cubeSlot[wallNum].position;
                effectSlot[4].gameObject.SetActive(true);
            }

            if (getTime > 7.5f && wallNum < 4)
            {
                cubeSlot[wallNum].gameObject.SetActive(false);
                effectSlot[wallNum].gameObject.SetActive(true);
                effectSlot[4].gameObject.SetActive(false);

                wallNum += 1;
                getTime = 0;
            }

            if (wallNum == 4)
            {
                cubeMove = true;
            }

            if (cubeMove)
            {

                for (int i = 0; i < cubeSlot2.Count; i++)
                {

                    resultPoint = goPoint + i;

                    if (resultPoint >= 4)
                    {
                        resultPoint = resultPoint - 4;
                    }

                    cubeSlot2[i].position =
                        Vector3.MoveTowards(cubeSlot2[i].position, pointSlot[resultPoint].position, cubeSpeed * Time.deltaTime);
                    dist = Vector3.Distance(cubeSlot2[i].position, pointSlot[resultPoint].position);


                }
                randomSpeed = Random.Range(1.0f, 3.0f);
                if (cubeSpeed < limitSpeed)
                {
                    cubeSpeed += Time.deltaTime * randomSpeed;
                    limitSpeed = 7.5f;
                }
                else if (cubeSpeed > limitSpeed)
                {
                    cubeSpeed -= Time.deltaTime * randomSpeed;
                    limitSpeed = 1.0f;
                }

                if (dist < 0.01f)
                {
                    if (goPoint == 4)
                    {
                        goPoint -= 4;
                    }
                    else
                    {
                        goPoint += 1;
                    }

                }
                //WallCube.enabled = true;           //this.enabled = false;           
            }
        }
    }
}
