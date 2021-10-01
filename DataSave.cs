using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml;

public class DataSave : MonoBehaviour
{
    TimeManager timeManager;
    public string DentProjName;
    public string name;
    public InputField inputField;
    public InputField inputFieldPat;
    public InputField inputFieldPos;

    public void MakeXml()
    {
        timeManager = GameObject.Find("Date").GetComponent<TimeManager>();

        XmlDocument doc = new XmlDocument();
        XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        doc.AppendChild(xmlDeclaration);

        //Treatment
        XmlElement Root = doc.CreateElement("Treatment");
        doc.AppendChild(Root);
        Root.AppendChild(doc.CreateElement("DateTime")).InnerText = timeManager.CurrentTime;
        Root.AppendChild(doc.CreateElement("TrayNo")).InnerText = "1";
        Root.AppendChild(doc.CreateElement("Notes")).InnerText = "1";
        Root.AppendChild(doc.CreateElement("ProjectGUID")).InnerText = "1";

        //Teeth, Tooth
        XmlElement Item = (XmlElement)Root.AppendChild(doc.CreateElement("Teeth"));
        XmlElement Item1 = (XmlElement)Item.AppendChild(doc.CreateElement("Tooth"));
        Item1.AppendChild(doc.CreateElement("Number")).InnerText = "1";
        Item1.AppendChild(doc.CreateElement("ReconstructionType")).InnerText = "AnatomicCrown";
        Item1.AppendChild(doc.CreateElement("MesialConnector")).InnerText = "false";

        Item1.AppendChild(doc.CreateElement("MaterialName")).InnerText = "Zirconia";
        Item1.AppendChild(doc.CreateElement("Material")).InnerText = "ZI";
        Item1.AppendChild(doc.CreateElement("ImplantType")).InnerText = "None";
        Item1.AppendChild(doc.CreateElement("PreparationType")).InnerText = "Crown";
        Item1.AppendChild(doc.CreateElement("Color")).InnerText = "---";

        XmlElement Near1 = (XmlElement)Item.AppendChild(doc.CreateElement("Tooth"));
        Near1.AppendChild(doc.CreateElement("Number")).InnerText = "1";
        Near1.AppendChild(doc.CreateElement("ReconstructionType")).InnerText = "HealthyTooth";
        Near1.AppendChild(doc.CreateElement("MesialConnector")).InnerText = "false";
        Near1.AppendChild(doc.CreateElement("MaterialName")).InnerText = "Healthy";
        Near1.AppendChild(doc.CreateElement("Material")).InnerText = "Healthy";
        Near1.AppendChild(doc.CreateElement("PreparationType")).InnerText = "Healthy";

        XmlElement Near2 = (XmlElement)Item.AppendChild(doc.CreateElement("Tooth"));
        Near2.AppendChild(doc.CreateElement("Number")).InnerText = "1";
        Near2.AppendChild(doc.CreateElement("ReconstructionType")).InnerText = "HealthyTooth";
        Near2.AppendChild(doc.CreateElement("MesialConnector")).InnerText = "false";
        Near2.AppendChild(doc.CreateElement("MaterialName")).InnerText = "Healthy";
        Near2.AppendChild(doc.CreateElement("Material")).InnerText = "Healthy";
        Near2.AppendChild(doc.CreateElement("PreparationType")).InnerText = "Healthy";

        XmlElement Antag = (XmlElement)Item.AppendChild(doc.CreateElement("Tooth"));
        Antag.AppendChild(doc.CreateElement("Number")).InnerText = "1";
        Antag.AppendChild(doc.CreateElement("ReconstructionType")).InnerText = "Antagonist";
        Antag.AppendChild(doc.CreateElement("MesialConnector")).InnerText = "false";
        Antag.AppendChild(doc.CreateElement("MaterialName")).InnerText = "Healthy";
        Antag.AppendChild(doc.CreateElement("Material")).InnerText = "Healthy";
        Antag.AppendChild(doc.CreateElement("PreparationType")).InnerText = "Antagonist";

        XmlElement Prac = (XmlElement)Root.AppendChild(doc.CreateElement("Practice"));
        Prac.AppendChild(doc.CreateElement("PracticeId")).InnerText = "1";
        Prac.AppendChild(doc.CreateElement("PracticeName")).InnerText = "치과";


        XmlElement Pat = (XmlElement)Root.AppendChild(doc.CreateElement("Patient"));
        Pat.AppendChild(doc.CreateElement("PatientId")).InnerText = "1";
        Pat.AppendChild(doc.CreateElement("PatientFirstName")).InnerText = "이름";

        Root.AppendChild(doc.CreateElement("DentalDBBuildDate")).InnerText = timeManager.buildDate;
        Root.AppendChild(doc.CreateElement("DentalDBProductName")).InnerText = timeManager.xmlName;
        Root.AppendChild(doc.CreateElement("ToothColor")).InnerText = "A1";
        Root.AppendChild(doc.CreateElement("AntagonistType")).InnerText = "RegisteredJaws";

        XmlNodeList nodes = doc.SelectNodes("Treatment");
        XmlNode Position = nodes[0];

        Position.SelectSingleNode("Notes").InnerText = inputField.text;
        //Debug.Log(inputField.text);


        XmlNodeList nodes1 = doc.SelectNodes("Treatment/Patient");
        XmlNode Position1 = nodes1[0];

        Position1.SelectSingleNode("PatientFirstName").InnerText = inputFieldPat.text;

        XmlNodeList nodes2 = doc.SelectNodes("Treatment/Practice");
        XmlNode Position2 = nodes2[0];

        Position2.SelectSingleNode("PracticeName").InnerText = inputFieldPos.text;

        //doc.Save("Assets/Resources/Data/default.dentalProject");
        DentProjName = timeManager.xmlName + ".dentalProject";

        string proj_path = UnityEngine.Application.dataPath;
        string target_path = proj_path + "/Resources/Data/";


        if (!Directory.Exists(target_path))
        {
            Directory.CreateDirectory(target_path);
        }

        string filepath = target_path + DentProjName;
        name = timeManager.xmlName;

        doc.Save(filepath);
    }

    
}

    
