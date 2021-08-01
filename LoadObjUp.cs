using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObjUp : MonoBehaviour
{
    //public Transform spPos;
    public GameObject target;

    public void GetUpObj()
    {
        FileDialog name = GameObject.Find("folder").GetComponent<FileDialog>();
        //name.DirName 사용
        target = Resources.Load<GameObject>(name.DirName + "/1");

        Instantiate(target, new Vector3(0.05f, -0.2f, 80f), Quaternion.Euler(new Vector3(-90f, -10f, 0f)));
        target.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
