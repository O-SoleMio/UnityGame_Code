using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapParent : MonoBehaviour
{
    public Transform ParentObj;

    [SerializeField]
    List<Transform> ObjChild = new List<Transform>();

    [SerializeField]
    List<Transform> PlayerChar = new List<Transform>();

    GameObject PlayerParent;
    RaycastHit rayhit;
    int LayMaskNum;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerParent = GameObject.Find("Player");

        for(int i = 0; i < PlayerParent.transform.childCount ;i++)
        {
            PlayerChar.Add(PlayerParent.transform.GetChild(i));
        }

       for(int i = 0;i < ParentObj.childCount ;i++)
        {
            ObjChild.Add(ParentObj.GetChild(i));
        }

        LayMaskNum = 1 << LayerMask.NameToLayer("Land");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i =0; i < PlayerChar.Count ;i++)
        {
            if (Physics.Raycast(PlayerChar[i].position, -(PlayerChar[i].up), out rayhit, 0.01f, LayMaskNum))
            {
                //Debug.DrawRay(PlayerChar[i].position, -(PlayerChar[i].up), Color.red,0.1f);
                if(PlayerChar[i].parent != null)
                PlayerChar[i].parent = rayhit.transform;
            }
            else
            {
                PlayerChar[i].parent = PlayerParent.transform;
            }
        }
    }

    
    
}
