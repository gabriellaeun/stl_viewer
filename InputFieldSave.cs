using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml;

/*
 * 거래처 이름 저장하는 스크립트
 */
public class InputFieldSave : MonoBehaviour
{
    public InputField inputField;
    public string fieldText;
    DataSave dataSave;

    public void Save()
    {
        dataSave = GameObject.Find("DataSave").GetComponent<DataSave>();

        string filename = dataSave.name;
        Debug.Log(filename);

        TextAsset textAsset = (TextAsset)Resources.Load("Data/" + filename); //xml 파일 로드
        Debug.Log(textAsset);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes("Treatment/Practice");
        XmlNode Position = nodes[0];

        Position.SelectSingleNode("PracticeName").InnerText = inputField.text;
        Debug.Log(inputField.text);
        xmlDoc.Save("Assets/Resources/Data/" + filename + ".xml");
    }

}
