using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upper : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(0.05f, -0.2f, 80f);
        transform.rotation = Quaternion.Euler(new Vector3(-90f, -10f, 0f));
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
