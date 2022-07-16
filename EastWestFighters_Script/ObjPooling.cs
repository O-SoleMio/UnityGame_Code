using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPooling : MonoBehaviour
{
    public static ObjPooling current;

    public GameObject PoolObj;
    public GameObject Play_Obj;
    public int PoolAmount = 5;
    public List<GameObject> PoolObjs;

    void Awake()
    {
        current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PoolObjs = new List<GameObject>();
        for(int i = 0;i<PoolAmount ;i++)
        {
            GameObject obj = (GameObject)Instantiate(PoolObj);
            obj.transform.parent = Play_Obj.transform;

            obj.SetActive(false);
            PoolObjs.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < PoolObjs.Count;i++)
        {
            if(!PoolObjs[i].activeInHierarchy)
            {
                return PoolObjs[i];
            }
        }
        return null;
    }

    // Update is called once per frame
}
