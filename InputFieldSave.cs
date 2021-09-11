using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldSave : MonoBehaviour
{
    public InputField inputField;
    public string fieldText;

    public void InputFieldSave()
    {
        fieldText = inputField.text;
    }

}
