using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;

public class Margin : MonoBehaviour
{
    FileDialog filedialog;
    public string name, Dir;
    int nodeNum;
    float x, y, z;
    float m_zoomMax = 100f;
    float m_zoomMin = -100f;
    float scale, scale_x, scale_y, scale_z;


    public void MarginExtract()
    {
        //xml 파일 위치를 알아야 함
        //FileDialog.cs의 FilePath, target_path, DirName 변수 가져와야 함
        filedialog = GameObject.Find("folder").GetComponent<FileDialog>();

        name = filedialog.NAME;
        Dir = filedialog.DirName;


        //Debug.Log("name : " + name);
        //Debug.Log("Dir : " + Dir);


        //Vector 값을 파싱해서 바로 LineRenderer의 element로 넣어주도록 코드 설계
        TextAsset textAsset = (TextAsset)Resources.Load(Dir + "/" + name);
        Debug.Log(textAsset);

        string str = textAsset.text;

        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml(str);


        XmlNodeList VectorNodes = xmldoc.SelectNodes("ConstuctionInfo/Teeth/Tooth/Margin/Vec3");
        nodeNum = VectorNodes.Count;
        Debug.Log("노드 개수 : " + VectorNodes.Count);
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.positionCount = nodeNum + 1; //positionCount가 lineRenderer positions의 size를 결정해줌!
        XmlNodeList nodes = xmldoc.SelectNodes("ConstuctionInfo/Teeth/Tooth/Margin");


        for (int i=0; i<nodeNum; i++)
        {
            XmlNodeList number = VectorNodes[i].ChildNodes;

            x = float.Parse(number[0].InnerText);
            y = float.Parse(number[1].InnerText);
            z = float.Parse(number[2].InnerText);

            Debug.Log("x : " + x + ", y : " + y + ", z : " + z);
            lineRenderer.SetPosition(i, new Vector3(x, y, z));
        }

        XmlNodeList numberEND = VectorNodes[0].ChildNodes; //끝 점은 시작점과 동일하게

        x = float.Parse(numberEND[0].InnerText);
        y = float.Parse(numberEND[1].InnerText);
        z = float.Parse(numberEND[2].InnerText);

        Debug.Log("x : " + x + ", y : " + y + ", z : " + z);
        lineRenderer.SetPosition(nodeNum, new Vector3(x, y, z));

    }
}
