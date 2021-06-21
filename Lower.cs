using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lower : MonoBehaviour
{
    // 하악과 상악을 따로 제어
    void Start()
    {
        transform.localPosition = new Vector3(0f, 0f, 80f); //상악, 하악 교합면 맞추기
        transform.rotation = Quaternion.Euler(new Vector3(-90f, -10f, 0f));
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
