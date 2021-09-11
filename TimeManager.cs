using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeManager : MonoBehaviour
{
    public Text Date;
    public string CurrentTime;
    public string buildDate;
    public string xmlName;

    void Start()
    {
        Date = GetComponent<Text>();

        Date.text = DateTime.Now.ToString(("yyyy-MM-dd HH:mm:ss tt"));
        buildDate = DateTime.Now.ToString(("yyyy-MM-dd"));
        CurrentTime = Date.text;
        xmlName = DateTime.Now.ToString(("yyyy-MM-dd-HHmmss"));
        //Debug.Log(CurrentTime);
    }
}
