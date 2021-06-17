using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    public GameObject gameobj;

    public void OnToggleOnOff()
    {
        if (gameobj.gameObject.activeSelf)
        {
            gameobj.gameObject.SetActive(false);
        }
        else
        {
            gameobj.gameObject.SetActive(true);
        }
    }
}
