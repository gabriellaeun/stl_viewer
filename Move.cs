using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    void OnMouseDrag()
    {
        //오브젝트 z position은 80으로 고정
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 80);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            OnMouseDrag();
        }
    }
}
