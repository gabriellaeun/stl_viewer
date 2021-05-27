using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lower : MonoBehaviour
{
    // 하악은 상악의 child로 들어가있기 때문에 상악의 위치로부터 바뀌는 위치 표시
    void Start()
    {
        transform.localPosition = new Vector3(0f, 0f, -4f);
        transform.Rotate(0, 0, 20);
    }
}
