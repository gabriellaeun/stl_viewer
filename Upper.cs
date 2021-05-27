using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upper : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(-2.4f, -2.5f, 80f);
        transform.rotation = Quaternion.Euler(new Vector3(-90f, -20f, 0f));
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
