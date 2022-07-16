using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateChar : MonoBehaviour
{
    public GameObject startChar;    
    public GameManager Gmanager;
    public GameObject ChildCamera;
    Rigidbody CharRigid;
    BoxCollider CharBox;

    float radian;
    float degree;
   
    public struct Cam
    {
        public float XPos;
        public float YPos;
        public float ZPos;
    }
    public struct startPos
    {
        public float XPos;
        public float YPos;
        public float ZPos;
    }
    
    // Start is called before the first frame update
    void Awake()
    {        
        Gmanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ChildCamera = GameObject.Find("Camera");
        startChar = Instantiate(Gmanager.Pickboat);
        startChar.name = "Player";
        startChar.transform.position = transform.position;
        startChar.AddComponent<BoatControl>();
        startChar.AddComponent<SFXManager>();
        startChar.AddComponent<Buoyancy>();
        
        StartCoroutine(CamMove());               
    }
    
    IEnumerator CamMove()
    {
        Cam Cam;
        startPos sPos;
        float dis = 10;// 카메라와 캐릭터의 z좌표값의 차이
        sPos.XPos = -1 * startChar.transform.position.x;
        sPos.ZPos = -1 * startChar.transform.position.z;
        
        while (true)
        {            
            degree = 270 + (-1 * startChar.transform.eulerAngles.y); // 플레이어 방향에 따른 각도 조절,
            //캐릭터의 y각도는 시계방향 == 양수이기 때문에 -1 을 곱해줘서 역뱡향으로 바꿔줌           
            radian = degree * Mathf.PI / 180; // 라디안값으로 변환                 
            Cam.XPos = (startChar.transform.position.x + sPos.XPos) + (float)System.Math.Round(dis * Mathf.Cos(radian), 3);                     
            Cam.YPos = ChildCamera.transform.position.y;
            Cam.ZPos = startChar.transform.position.z + (float)System.Math.Round(dis * Mathf.Sin(radian), 3);

            ChildCamera.transform.position = new Vector3(Cam.XPos, Cam.YPos, Cam.ZPos);

            ChildCamera.transform.rotation =
                Quaternion.Euler(30, startChar.transform.eulerAngles.y, 0);// x 시점은 고정

            yield return null;
        }
    } 
}


