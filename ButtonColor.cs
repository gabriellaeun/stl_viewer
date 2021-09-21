using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml;

public class ButtonColor : MonoBehaviour
{
    DataSave dataSave;
    string filename;
    //public Button AntagBut;
    public string name;
    public string name_ant;
    XmlDocument xmlDoc;
    XmlNodeList nodes;

    void Start()
    {
        dataSave = GameObject.Find("DataSave").GetComponent<DataSave>();

        filename = dataSave.name;
        //Debug.Log(filename);

        TextAsset textAsset = (TextAsset)Resources.Load("Data/" + filename); //xml 파일 로드
        Debug.Log(textAsset);
        xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);

        nodes = xmlDoc.SelectNodes("Treatment/Teeth/Tooth");
    }

    public void Click()
    {
        Button b = GetComponent<Button>();
        ColorBlock cb = b.colors;

        XmlNode Position = nodes[0];

        //cb.normalColor = Color.red;
        //cb.pressedColor = Color.blue;
        //b.colors = cb;

        if (cb.normalColor == Color.white)
        {
            cb.normalColor = Color.red;
            cb.selectedColor = Color.red;
            b.colors = cb;

            name = gameObject.name;
            Debug.Log(name);
            Position.SelectSingleNode("Number").InnerText = name;
            xmlDoc.Save("Assets/Resources/Data/" + filename + ".xml");
        }
        else
        {
            cb.normalColor = Color.white;
            cb.selectedColor = Color.white;
            b.colors = cb;

            name = "1";
            Debug.Log(name);
            Position.SelectSingleNode("Number").InnerText = name;
            xmlDoc.Save("Assets/Resources/Data/" + filename + ".xml");
        }
    }

    public void Antag()
    {
        Button Ant = GetComponent<Button>();
        ColorBlock colB = Ant.colors;
        name_ant = gameObject.name;

        XmlNode Position_ant = nodes[3];

        if (colB.normalColor == Color.white)
        {
            colB.normalColor = Color.blue;
            Ant.colors = colB;

            name_ant = gameObject.name;
            Debug.Log(name_ant);
            Position_ant.SelectSingleNode("Number").InnerText = name_ant;
            xmlDoc.Save("Assets/Resources/Data/" + filename + ".xml");
        }
        else
        {
            colB.normalColor = Color.white;
            Ant.colors = colB;

            name_ant = "1";
            Debug.Log(name_ant);
            Position_ant.SelectSingleNode("Number").InnerText = name_ant;
            xmlDoc.Save("Assets/Resources/Data/" + filename + ".xml");
        }
        
    }
    

}
