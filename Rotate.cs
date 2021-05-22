using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    void Update()
    {
        RotateFunc();
    }

    public float speed_rot = 0f;

    void RotateFunc()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0f, -1 * mouseX * speed_rot, 0f, Space.World);
            transform.Rotate(-1 * mouseY * speed_rot, 0f, 0f);
        }
    }
}
