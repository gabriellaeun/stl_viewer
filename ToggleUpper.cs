using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUpper : MonoBehaviour
{
    public GameObject m_gameObject;

    public void OnToggleOnOff()
    {
        if (m_gameObject.gameObject.activeSelf)
        {
            m_gameObject.gameObject.SetActive(false);
        }
        else
        {
            m_gameObject.gameObject.SetActive(true);
        }
    }

}
