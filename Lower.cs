using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lower : MonoBehaviour
{
    // 하악은 상악의 child로 들어가있기 때문에 상악의 위치로부터 바뀌는 위치 표시
    void Start()
    {
        transform.localPosition = new Vector3(-0.002f, -6.2f, 80f);
        transform.rotation = Quaternion.Euler(new Vector3(-90f, -10f, 0f));
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
