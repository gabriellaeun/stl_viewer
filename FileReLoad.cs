using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms;
using Ookii.Dialogs;
using System.IO;
using System;
using UnityEngine.UI;
using System.Xml;
using System.Text;

public class FileReLoad : MonoBehaviour
{
    public VistaOpenFileDialog OpenFileDialog = new VistaOpenFileDialog();
    public string filename; //선택한 파일의 경로(파일이름 포함)
    public string m_FilePaths;

    public Text text;

    string notes, patient, position, time;

    public InputField inputField;
    public InputField inputFieldPat;
    public InputField inputFieldPos;
    public InputField inputFieldPerson;

    public void ReLoad()
    {
        SetOpenFileDialog();
        m_FilePaths = FileOpen(OpenFileDialog);
        //Debug.Log("파일 경로 : " + m_FilePaths);

        ParseDentProj(m_FilePaths);
    }

    string FileOpen(VistaOpenFileDialog openFileDialog)
    {
        var result = openFileDialog.ShowDialog();
        
        if(result == DialogResult.OK)
        {
            filename = openFileDialog.FileName;
            //Debug.Log(filename);
        }
        
        openFileDialog.Dispose();

        return filename;
    }

    void SetOpenFileDialog()
    {
        OpenFileDialog.Title = "파일 열기";
        OpenFileDialog.Filter
            = "dentalProject 파일 |*.dentalProject" +
            "|모든 파일|*.*";
        OpenFileDialog.FilterIndex = 1;
        OpenFileDialog.Multiselect = true;
    }

    void ParseDentProj(string FilePath)
    {
        if (Path.GetExtension(@FilePath) == ".dentalProject")
        {
            string NAME = Path.GetFileNameWithoutExtension(@FilePath);//확장자를 뺀 파일의 이름
            TextAsset textAsset = (TextAsset)Resources.Load(NAME);
            Debug.Log(textAsset);
        }
        

        XmlReader reader = XmlReader.Create(@FilePath);

        while (reader.Read())
        {
            if (reader.IsStartElement())
            {
                switch (reader.Name.ToString())
                {
                    case "Notes":
                        notes = reader.ReadString();
                        Debug.Log("notes : " + notes);
                        inputField.text = notes;
                        break;
                    case "PracticeName":
                        position = reader.ReadString();
                        Debug.Log("position : " + position);
                        inputFieldPos.text = position;
                        break;
                    case "PatientFirstName":
                        patient = reader.ReadString();
                        Debug.Log("patient : " + patient);
                        inputFieldPat.text = patient;
                        break;
                    case "DateTime":
                        time = reader.ReadString();
                        Debug.Log("date : " + time);
                        text.text = time;
                        break;
                }
              
            }
        }


    }

}
