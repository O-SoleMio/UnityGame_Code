using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    [SerializeField]
    float speed = 20.0f;
    [SerializeField]
    float h;
    [SerializeField]
    float v;

    [SerializeField]
    Vector3 getPosition;
    void Update()
    {
        getPosition = transform.position;
        h = Input.GetAxisRaw("Horizontal_1");
        v = Input.GetAxisRaw("Vertical_1");

        h = h * speed * Time.deltaTime;
        v = v * speed * Time.deltaTime;

        transform.Translate(Vector3.right * h);
        transform.Translate(Vector3.forward * v);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(GetComponent<Collider>());
    }
}
