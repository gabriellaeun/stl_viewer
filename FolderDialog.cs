using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms;
using System.IO;
using System;
using UnityEngine.UI;
using System.Xml;
using System.Text;

public class FileDialog : MonoBehaviour
{
    public Text m_text;
    public string DirName;
    string type, libname, libfile, imptype, FilePath, number;
    string upper, lower;
    string c_lower = null;
    string c_upper = null;
    string XmlFile = null;
    string ConFile = null;
    string crown = null;

    void Load(string path, string DirName)
    {
        /*
        -----constructionInfo 확장자 파일을 xml로 바꿔주기---------
        (수정) 확장자를 .xml로 바꿔서 옴
        */

        /*
        string[] files = Directory.GetFiles(path);
        foreach (string s in files)
        {
            string fileName = Path.GetFileName(s);

            /*
            if(Path.GetExtension(fileName) == ".constructionInfo")
            {
                //XmlFile = Path.ChangeExtension(fileName, ".xml");
                //Debug.Log("변환 후 파일 : " + fileName);
                FilePath = Path.Combine(path, fileName);
                string NAME = Path.GetFileNameWithoutExtension(FilePath);
                TextAsset textAsset = (TextAsset)Resources.Load(NAME);
                Debug.Log("xml 파일 : " + textAsset);
            }
            else 
            */

            /*
            if(Path.GetExtension(fileName) == ".xml")
            {
                Debug.Log("파싱할 파일 : " + fileName);
                //FilePath = Path.Combine(path, fileName);
                string NAME = Path.GetFileNameWithoutExtension(fileName);
                TextAsset textAsset = (TextAsset)Resources.Load(DirName + "/" + NAME);
                Debug.Log("text Asset : " + textAsset);
            }
        }*/

        /*
        if (Path.GetExtension(path) == ".xml")
        {
            Debug.Log("파싱할 파일 : " + fileName);
            //FilePath = Path.Combine(path, fileName);
            string NAME = Path.GetFileNameWithoutExtension(fileName);
            TextAsset textAsset = (TextAsset)Resources.Load(DirName + "/" + NAME);
            Debug.Log("text Asset : " + textAsset);
        }
        */

        FilePath = path + "/" + DirName + ".xml";
        Debug.Log("xml 파일 경로 : " + FilePath);
        string NAME = Path.GetFileNameWithoutExtension(FilePath);
        TextAsset textAsset = (TextAsset)Resources.Load(DirName + "/" + NAME);
        Debug.Log(textAsset);

        string str = textAsset.text;

        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml(str);


        XmlNodeList nodes = xmldoc.SelectNodes("ConstuctionInfo/Teeth/Tooth");
        //Debug.Log(nodes);

        foreach(XmlNode node in nodes)
        {
            number = node.SelectSingleNode("Number").InnerText;
            type = node.SelectSingleNode("ReconstructionType").InnerText;
            libname = node.SelectSingleNode("ToothLibraryName").InnerText;
            libfile = node.SelectSingleNode("ToothModelFilename").InnerText;
            imptype = node.SelectSingleNode("ImplantType").InnerText;
        }

        Debug.Log("Number :: " + number);
        Debug.Log("ReconstructionType :: " + type);
        Debug.Log("Tooth Library Name :: " + libname);
        Debug.Log("ToothModel Filename :: " + libfile);
        Debug.Log("Implant Type :: " + imptype);

        string result = "Number : " + number + System.Environment.NewLine
                + "Type : " + type + System.Environment.NewLine
                + "Tooth Library Name : " + libname + System.Environment.NewLine
                + "Tooth Library File : " + libfile + System.Environment.NewLine
                + "Implant Type : " + imptype + System.Environment.NewLine;
        m_text.text = result;

        /*
        XmlReader reader = XmlReader.Create(FilePath);

        
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

                reader.Close();
            }
        }
        */
        GameObject.Find("Up").GetComponent<LoadObjUp>().GetUpObj();

    }


    public void FileOpen()
    {
        FolderBrowserDialog dialog = new FolderBrowserDialog();
        dialog.ShowDialog();
        string select_path = dialog.SelectedPath;
        Debug.Log("선택된 폴더 : " + select_path);
        DirName = Path.GetFileName(@select_path);//폴더 이름
        Debug.Log("폴더 이름 : " + DirName);

        DirectoryInfo di = new DirectoryInfo(@select_path);
        foreach (FileInfo file in di.GetFiles())
        {
            ConFile = file.Name;
            if(Path.GetExtension(ConFile) == ".constructionInfo")
            {
                string con_path = Path.Combine(select_path, ConFile);
                string result = Path.ChangeExtension(con_path, ".xml");
                File.Move(con_path, result);
                Debug.Log(con_path + ">>" + result);
            }
        }

        //ConFile = Directory.GetFiles(select_path, "*.constructionInfo");

        /*
        if (String.Contains(Directory.GetFiles(@select_path, "*.constructionInfo")))
        {
            string[] con_files = Directory.GetFiles(@select_path, "*.constructionInfo");

            foreach (string con in con_files)
            {
                ConFile = con;
                Debug.Log("con file : " + ConFile);
            }

            string con_path = Path.Combine(select_path, ConFile);
            string result = Path.ChangeExtension(con_path, ".xml");
            File.Move(con_path, result);
            Debug.Log(con_path + ">>" + result);
        }
        */

        //string[] con_files = Directory.GetFiles(@select_path, "*.constructionInfo");
        /*foreach(string con in con_files)
        {
            ConFile = con;
            Debug.Log("con file : " + ConFile);
        }*/

        /*
        if (Path.GetExtension(ConFile) == ".constructionInfo") 
        {
            //ConFile = fname;
            string con_path = Path.Combine(select_path , ConFile);
            string result = Path.ChangeExtension(con_path, ".xml");
            File.Move(con_path, result);
            Debug.Log(con_path + ">>" + result);
            
            string result = Path.ChangeExtension(fname, ".xml");
            Debug.Log("변환 후 파일 : " + result);
            XmlFile = result;
            
        }*/
      

        //DirectoryInfo di = new DirectoryInfo(@select_path);

        foreach (FileInfo file in di.GetFiles())
        {
            //Debug.Log("파일명 : " + file.Name);
            string fname = file.Name;

            if ((fname == "1.stl")||(fname == "1.STL"))
            {
                upper = fname;
            }
            else if ((fname == "2.stl")||(fname == "2.STL"))
            {
                lower = fname;
            }
            else if ((fname == "2-copy.stl")||(fname=="2-COPY.STL")||(fname=="2-copy.STL")||(fname=="2-COPY.stl"))
            {
                c_lower = fname;
            }
            else if ((fname == "1-copy.stl") || (fname == "1-COPY.STL") || (fname == "1-copy.STL") || (fname == "1-COPY.stl"))
            {
                c_upper = fname;
            }
            else if (Path.GetExtension(fname) == ".stl")
            {
                crown = fname;
            }
            else if (Path.GetExtension(fname) == ".xml")
            {
                XmlFile = fname;
                Debug.Log("xml : " + XmlFile);
            }

        }

        /*
        유니티 에셋에 추가하려면 이 폴더 자체를 유니티 Asset 폴더로 옮겨야 함
        → 현 프로젝트의 경로를 우선 알아야 함 ....
        1. 프로젝트 저장된 경로 찾는 코드 구현
            1) Application.persistentDataPath : C:\Users\사용자이름\AppData\LocalLow\회사이름
            2) Application.streamingAssetsPath : 해당 프로젝트 폴더 경로\Assets\StreamingAssets
            3) Application.dataPath : 해당 프로젝트 폴더\Assets

        2. select_path 폴더를 현 프로젝트의 Asset/Resources 로 옮기는 코드 구현
        */
        string proj_path = UnityEngine.Application.dataPath; //1. 프로젝트 Assets 경로
        Debug.Log(proj_path);

        string target_path = proj_path + "/Resources/" + DirName;

        Directory.CreateDirectory(target_path);

        //2.select_path 폴더를 현 프로젝트의 Asset으로 옮기는 코드
        
                
        string[] files = Directory.GetFiles(@select_path);
        
        foreach (string s in files)
        {
            string fileName = Path.GetFileName(s);
            string destFile = Path.Combine(target_path, fileName);
            string sourceFile = Path.Combine(select_path, fileName);

            if (fileName == upper)
            {
                File.Copy(sourceFile, destFile, true);
            }
            else if (fileName == lower)
            {
                File.Copy(sourceFile, destFile, true);
            }
            else if (fileName == c_lower)
            {
                File.Copy(sourceFile, destFile, true);
            }
            else if (fileName == c_upper)
            {
                File.Copy(sourceFile, destFile, true);
            }
            else if (fileName == crown)
            {
                File.Copy(sourceFile, destFile, true);
            }
            /*else if(fileName == ConFile)
            {
                XmlFile = Path.ChangeExtension(s, ".xml");
                File.Move(s, XmlFile);
                destFile = Path.Combine(target_path, fileName);
                sourceFile = Path.Combine(select_path, fileName);
                File.Copy(sourceFile, destFile, true);
            }*/
            else if(fileName == XmlFile)
            {
                File.Copy(sourceFile, destFile, true);
            }

        }
        Debug.Log("target : " + target_path);
        Load(target_path, DirName);

    }
}
