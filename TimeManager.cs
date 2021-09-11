using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeManager : MonoBehaviour
{
    public Text Date;
    public string CurrentTime;
    
    void Start()
    {
        Date = GetComponent<Text>();

        Date.text = DateTime.Now.ToString(("yyyy-MM-dd HH:mm:ss tt"));

        CurrentTime = Date.text;
        //Debug.Log(CurrentTime);
    }
}
