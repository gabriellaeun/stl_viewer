using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    
    //public Button AntagBut;

    public void Click()
    {
        Button b = GetComponent<Button>();
        ColorBlock cb = b.colors;

        //cb.normalColor = Color.red;
        //cb.pressedColor = Color.blue;
        //b.colors = cb;

        if(cb.normalColor == Color.white)
        {
            cb.normalColor = Color.red;
            cb.selectedColor = Color.red;
            b.colors = cb;
        }
        else
        {
            cb.normalColor = Color.white;
            cb.selectedColor = Color.white;
            b.colors = cb;
        }
    }

    public void Antag()
    {
        Button Ant = GetComponent<Button>();
        ColorBlock colB = Ant.colors;

        if(colB.normalColor == Color.white)
        {
            colB.normalColor = Color.blue;
            Ant.colors = colB;
        }
        else
        {
            colB.normalColor = Color.white;
            Ant.colors = colB;
        }
        
    }
    

}
