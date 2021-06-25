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
    //public string xmlPath;
    //public string FilePath;
    string number, type, libname, libfile, imptype, FilePath;
    string upper, lower;
    string c_lower = null;
    string c_upper = null;
    string ConFile = null;
    string XmlFile = null; 

    void Load(string path, string DirName)
    {
        /*
        -----constructionInfo 확장자 파일을 xml로 바꿔주기---------
        */

        //파일 찾기 코드 추가해야할 듯
        string[] files = Directory.GetFiles(path);
        foreach (string s in files)
        {
            string fileName = Path.GetFileName(s);
            if(Path.GetExtension(fileName) == ".constructionInfo")
            {
                FilePath = Path.Combine(path, fileName);
            }
            else if(Path.GetExtension(fileName) == ".xml")
            {
                FilePath = Path.Combine(path, fileName);
            }
        }
        //string FilePath = "C:\\Users\\82105\\stl_viewer\\Assets\\Resources\\2018-06-08_162694979.xml";

        if (Path.GetExtension(@FilePath) == ".constructionInfo")
        {
            string result = Path.ChangeExtension(@FilePath, ".xml"); //.constructionInfo 파일의 확장자를 .xml로 변환
            //File.Move(@FilePath, result);
            //Debug.Log(result);
            string NAME = Path.GetFileNameWithoutExtension(result);//확장자를 뺀 파일의 이름
            TextAsset textAsset = (TextAsset)Resources.Load(NAME);
            Debug.Log(textAsset);
        }
        else if (Path.GetExtension(@FilePath) == ".xml")
        {
            string NAME = Path.GetFileNameWithoutExtension(FilePath);
            TextAsset textAsset = (TextAsset)Resources.Load(NAME);
            Debug.Log(textAsset);
        }
        else
        {
            Debug.Log("path extension error");
        }

        XmlReader reader = XmlReader.Create(@FilePath);

        //xmlPath = "C:\\Users\\82105\\stl_viewer\\Assets\\Resources\\2018-06-08_162694979.xml";
        //string NAME = Path.GetFileNameWithoutExtension(xmlPath);

        //XmlReader reader = XmlReader.Create(xmlPath);

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


    public void FileOpen()
    {
        FolderBrowserDialog dialog = new FolderBrowserDialog();
        dialog.ShowDialog();
        string select_path = dialog.SelectedPath;
        Debug.Log("선택된 폴더 : " + select_path);
        string DirName = Path.GetFileName(@select_path);//폴더 이름
        Debug.Log("폴더 이름 : " + DirName);


        DirectoryInfo di = new DirectoryInfo(@select_path);

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
            else if(Path.GetExtension(fname) == ".constructionInfo")
            {
                ConFile = fname;
            }
            else if (Path.GetExtension(fname) == ".xml")
            {
                XmlFile = fname;
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

        string target_path = @Path.Combine(proj_path, "Resources", DirName);//디렉토리 이름이 File이 아니고 사실 복사하는 디렉토리의 이름과 같아야 함

        Directory.CreateDirectory(target_path);

        //2.select_path 폴더를 현 프로젝트의 Asset으로 옮기는 코드
        
        /*

        if (Directory.Exists(@select_path))
        {
            string[] files = Directory.GetFiles(@select_path);
            string destFile = Path.Combine(target_path, fileName);
            foreach (string s in files)
            {
                string fileName = Path.GetFileName(s);
                if (s == upper || s == lower || s == c_upper || s == c_lower || s = ConFile || s == XmlFile)
                {
                    File.Copy(s, destFile, true);
                }
            }
        }
        else
        {
            Debug.Log("Source path does not exist");
        }

        */

        
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
            else if (fileName == ConFile)
            {
                File.Copy(sourceFile, destFile, true);
            }
            else if (fileName == XmlFile)
            {
                File.Copy(sourceFile, destFile, true);
            }

        }
        
        Load(target_path, DirName);

    }

    

}
