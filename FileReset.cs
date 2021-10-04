using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FileReset : MonoBehaviour
{
    TimeManager date;
    public InputField inputField;
    public InputField inputFieldPat;
    public InputField inputFieldPos;

    public void Reset()
    {
        date = GameObject.Find("Date").GetComponent<TimeManager>();

        date.Date.text = DateTime.Now.ToString(("yyyy-MM-dd HH:mm:ss tt"));
        date.buildDate = DateTime.Now.ToString(("yyyy-MM-dd"));
        date.xmlName = DateTime.Now.ToString(("yyyy-MM-dd-HHmmss"));

        inputField.text = null;
        inputFieldPat.text = null;
        inputFieldPos.text = null;

    }
}
