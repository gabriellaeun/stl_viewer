using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    public GameObject lower;
    public GameObject upper;
    public GameObject abut;

    public void PushButton()
    {
        lower.gameObject.transform.position = new Vector3(0f, 0f, 80f);
        lower.gameObject.transform.rotation = Quaternion.Euler(new Vector3(-90f, -10f, 0f));
        lower.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

        upper.gameObject.transform.position = new Vector3(0.05f, -0.2f, 80f);
        upper.gameObject.transform.rotation = Quaternion.Euler(new Vector3(-90f, -10f, 0f));
        upper.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

        
        if (abut.gameObject.name == "2")//지대치가 하악일 경우
        {
            abut.gameObject.transform.position = new Vector3(0f, 0f, 80f);
            abut.gameObject.transform.rotation = Quaternion.Euler(new Vector3(-90f, -10f, 0f));
            abut.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else //지대치가 상악일 경우
        {
            abut.gameObject.transform.position = new Vector3(0.05f, -0.2f, 80f);
            abut.gameObject.transform.rotation = Quaternion.Euler(new Vector3(-90f, -10f, 0f));
            abut.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
    }
}
