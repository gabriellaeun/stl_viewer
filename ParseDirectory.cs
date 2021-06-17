using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Text;
using System;
using System.IO;

public class ParseDirectory : MonoBehaviour
{
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
                        Debug.Log("Number : " + reader.ReadString());
                        break;
                    case "ReconstructionType":
                        Debug.Log("Type : " + reader.ReadString());
                        break;
                    case "ToothLibraryName":
                        Debug.Log("Tooth Library Name : " + reader.ReadString());
                        break;
                    case "ToothModelFilename":
                        Debug.Log("Tooth Library File : " + reader.ReadString());
                        break;
                    case "ImplantType":
                        Debug.Log("Implant Type : " + reader.ReadString());
                        break;
                }
            }
        }

    }
}
