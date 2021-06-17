using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Text;
using System;
using System.IO;

public class ParseDirectory : MonoBehaviour
{
    public Text m_text;
    string number, type, libname, libfile, imptype;

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
        //파일 찾기 코드 추가해야할 듯


        string FileName = "C:\\Users\\82105\\stl_viewer\\Assets\\Resources\\2018-06-08_162694979.constructionInfo";

        if(strcmp(Path.GetExtension(FileName), ".constructionInfo") == 0){
            string result = Path.ChangeExtension(FileName, ".xml"); //.constructionInfo 파일의 확장자를 .xml로 변환
            File.Move(FileName, result);
            Debug.Log(result);
            string NAME = Path.GetFileNameWithoutExtension(result);//확장자를 뺀 파일의 이름
            TextAsset textAsset = (TextAsset)Resources.Load(NAME);
            Debug.Log(textAsset);   
        }
        else if(strcmp(Path.GetExtension(FileName), ".xml") == 0){
            string NAME = Path.GetFileNameWithoutExtension(FileName);
        }
        else{
            Debug.Log("path extension error");
        }

        XmlReader reader = XmlReader.Create(FileName);
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
                        number = reader.ReadString();
                        Debug.Log("Number : " + reader.ReadString());
                        break;
                    case "ReconstructionType":
                        type = reader.ReadString();
                        Debug.Log("Type : " + reader.ReadString());
                        break;
                    case "ToothLibraryName":
                        libname = reader.ReadString();
                        Debug.Log("Tooth Library Name : " + reader.ReadString());
                        break;
                    case "ToothModelFilename":
                        libfile = reader.ReadString();
                        Debug.Log("Tooth Library File : " + reader.ReadString());
                        break;
                    case "ImplantType":
                        imptype = reader.ReadString();
                        Debug.Log("Implant Type : " + reader.ReadString());
                        break;
                }
                string result = "Number : " + number + System.Environment.NewLine
                                + "Type : " + type + System.Environment.NewLine
                                + "Tooth Library Name : " + libname + System.Environment.NewLine
                                + "Tooth Library File : " + libfile + System.Environment.NewLine
                                + "Implant Type : " + imptype + System.Environment.NewLine;
                m_text.text = result;
            }
        }

    }
}
