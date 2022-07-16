using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{   
    Camera mainCamera;
    bool shakePlay = false;
    Vector3 staticPos;
    Vector3 mainPos;
    int a = 0;
    void Start()
    {
        mainCamera = Camera.main;       
        StartCoroutine(KeyDown());
    }

    IEnumerator KeyDown()
    {
        while(true)
        {
            if(Input.GetKeyDown(KeyCode.S) && shakePlay == false)// S를 눌렀을 때,shakePlay가 false 일 때 활성화
            {
                staticPos = mainCamera.transform.position; // 카메라 원래 좌표 저장
                StartCoroutine(Shake(0.1f,0.5f)); // 움직일 범위, 움직일 시간
            }
            yield return null;
        }
    }

    IEnumerator Shake(float shakeRange, float shakeTime)
    {
        while (true)
        {
            shakePlay = true;
            shakeTime -= Time.deltaTime;
            if (shakeTime < 0f) break; // shakeTime 만큼 실행

            mainPos.x = staticPos.x + Random.Range(-shakeRange, shakeRange);
            mainPos.y = staticPos.y + Random.Range(-shakeRange, shakeRange);
            mainPos.z = staticPos.z; // 2d 상 고정

            mainCamera.transform.position = mainPos;            
            yield return null;
        }
        mainCamera.transform.position = staticPos;//끝난 시점, 카메라 원상복구 및 shakePlay 비활성화
        shakePlay = false;
    }
}
