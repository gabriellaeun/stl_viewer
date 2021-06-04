using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Text;
using System;
using System.IO;


public class InfoText : MonoBehaviour
{

    private Text Number = null;
    private Text ReconstructionType = null;
    private Text ToothLibraryName = null;
    private Text ToothModelFilename = null;
    private Text ImplantType = null;

    void Start()
    {
        Load();
    }

    void Load()
    {
        /*
        -----constructionInfo 확장자 파일을 xml로 바꿔주기---------
        */

        /*
        string FileName = "C:\\Users\\82105\\stl_viewer\\Assets\\Resources\\2018-06-08_162694979.constructionInfo";
        string result = Path.ChangeExtension(FileName, ".xml"); //.constructionInfo 파일의 확장자를 .xml로 변환
        File.Move(FileName, result);
        Debug.Log(result);
        string NAME = Path.GetFileNameWithoutExtension(result);//확장자를 뺀 파일의 이름
        TextAsset textAsset = (TextAsset)Resources.Load(NAME);
        Debug.Log(textAsset);
        */
        string xmlPath = "C:\\Users\\82105\\stl_viewer\\Assets\\Resources\\2018-06-08_162694979.xml";
        string NAME = Path.GetFileNameWithoutExtension(xmlPath);

        XmlReader reader = XmlReader.Create(xmlPath);

        while (reader.Read())
        {
            if (reader.IsStartElement())
            {
                switch (reader.Name.ToString())
                {
                    case "Number":
                        Debug.Log("Number : " + reader.ReadString());
                        Number.text = "Number : " + reader.ReadString();
                        break;
                    case "ReconstructionType":
                        Debug.Log("Type : " + reader.ReadString());
                        ReconstructionType.text = "Type : " + reader.ReadString();
                        break;
                    case "ToothLibraryName":
                        Debug.Log("Tooth Library Name : " + reader.ReadString());
                        ToothLibraryName.text = "Tooth Library Name : " + reader.ReadString();
                        break;
                    case "ToothModelFilename":
                        Debug.Log("Tooth Library File : " + reader.ReadString());
                        ToothModelFilename.text = "Tooth Library File : " + reader.ReadString();
                        break;
                    case "ImplantType":
                        Debug.Log("Implant Type : " + reader.ReadString());
                        ImplantType.text = "Implant Type : " + reader.ReadString();
                        break;
                }
            }
        }
    }
}
