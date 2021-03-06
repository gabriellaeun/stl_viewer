using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

public class DataSave : MonoBehaviour
{
    TimeManager timeManager;
    public string DentProjName;

    void MakeXml()
    {
        XmlDocument doc = new XmlDocument();
        XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        doc.AppendChild(xmlDeclaration);

        //Treatment
        XmlElement Root = doc.CreateElement("Treatment");
        doc.AppendChild(Root);
        Root.AppendChild(doc.CreateElement("DateTime")).InnerText = "1";
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
        Prac.AppendChild(doc.CreateElement("PracticeName")).InnerText = "??????";


        XmlElement Pat = (XmlElement)Root.AppendChild(doc.CreateElement("Patient"));
        Pat.AppendChild(doc.CreateElement("PatientId")).InnerText = "1";
        Pat.AppendChild(doc.CreateElement("PatientFirstName")).InnerText = "??????";

        Root.AppendChild(doc.CreateElement("DentalDBBuildDate")).InnerText = "??????";
        Root.AppendChild(doc.CreateElement("DentalDBProductName")).InnerText = "DentalDB";
        Root.AppendChild(doc.CreateElement("ToothColor")).InnerText = "A1";
        Root.AppendChild(doc.CreateElement("AntagonistType")).InnerText = "RegisteredJaws";

        timeManager = GameObject.Find("Date").GetComponent<TimeManager>();


        //doc.Save("Assets/Resources/Data/default.dentalProject");
        DentProjName = timeManager.xmlName + ".xml";
        string filepath = "Assets/Resources/Data/" + DentProjName;
        
        doc.Save(filepath);
    }
    void Start()
    {
        MakeXml();
    }

}

    
