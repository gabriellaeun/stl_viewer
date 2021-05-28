using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lower_2 : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(-2.4f, -8f, 80f);
        transform.rotation = Quaternion.Euler(new Vector3(-90f, -20f, 0f));
        transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
    }
}
