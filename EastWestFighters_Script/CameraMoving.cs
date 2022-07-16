using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public GameObject myCamera;
    public int MovingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        MovingSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //카메라 좌표
        if(Input.GetKey("up"))
            {
            myCamera.transform.Translate(Vector3.up * Time.deltaTime * MovingSpeed);
            }
        if (Input.GetKey("down"))
        {
            myCamera.transform.Translate(Vector3.down * Time.deltaTime * MovingSpeed);
        }
        if (Input.GetKey("right"))
        {
            myCamera.transform.Translate(Vector3.right * Time.deltaTime * MovingSpeed);
        }
        if (Input.GetKey("left"))
        {
            myCamera.transform.Translate(Vector3.left * Time.deltaTime * MovingSpeed);
        }
        //카메라 회전
        if(Input.GetKey("w"))
        {
            myCamera.transform.Rotate(Vector3.up * Time.deltaTime * MovingSpeed);
        }
        if (Input.GetKey("s"))
        {
            myCamera.transform.Rotate(Vector3.down * Time.deltaTime * MovingSpeed);
        }
        if (Input.GetKey("d"))
        {
            myCamera.transform.Rotate(Vector3.right * Time.deltaTime * MovingSpeed);
        }
        if (Input.GetKey("a"))
        {
            myCamera.transform.Rotate(Vector3.left * Time.deltaTime *MovingSpeed);
        }
        //카메라 스피드
        if (Input.GetKeyUp("q"))
        {
            if(MovingSpeed <= 10)
            MovingSpeed += 1;
        }
        if (Input.GetKeyUp("e"))
        {
            if(MovingSpeed >= 2 )
            MovingSpeed -= 1;
        }
    }
}
