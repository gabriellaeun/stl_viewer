using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Text;
using LitJson;
using System;

public class ToServer : MonoBehaviour
{
    public static string margin;
    public static string marginURL;
    public static string marginPoint;
    int result;
    string txt;
    float x, y, z;
    float firstX, firstY, firstZ;
    int nodeNum;

    public void MarginExtract()
    {
        StartCoroutine(DataPost());
    }

    private void FirstParser(string jsonString)
    {
        JsonData jsonParser = JsonMapper.ToObject(jsonString);
        margin = jsonParser["margin id"].ToString();
        marginURL = jsonParser["check URL"].ToString();

        Debug.Log("margin : " + margin);
        Debug.Log("URL : " + marginURL);
    }

    private int SecondParser(string jString)
    {
        JsonData Parser = JsonMapper.ToObject(jString);

        string margin2 = Parser["id"].ToString();
        marginPoint = Parser["margin"].ToString();

        Debug.Log("margin : " + margin2);
        Debug.Log("Point : " + marginPoint);

        if (marginPoint == "")
            return 1;
        else
            return 2;
    }

    IEnumerator DataPost()
    {
        string url = "http://dentalcad.ai:6003/margin/req_nonblock/";
        UnityWebRequest www;

        string stlPath;

        if(FileDialog.c_upper == null)
        {
            stlPath = DataSave.target_path + "/2.stl";
        }
        else
        {
            stlPath = DataSave.target_path + "/1.stl";
        }
        //byte[] bytes = File.ReadAllBytes(@"C:\Users\82105\Desktop\ClearTech\다른치아_샘플\2017-11-14_100217566\2.stl");
        byte[] bytes = File.ReadAllBytes(@stlPath);

        WWWForm form = new WWWForm();
        form.AddField("content", "CONTENT");
        form.AddField("title", "TITLE");
        form.AddBinaryData("file", bytes, @"C:\Users\82105\Desktop\ClearTech\다른치아_샘플\2017-11-14_100217566\2.stl", "application/octet-stream");


        www = UnityWebRequest.Post(url, form);

        yield return www.SendWebRequest();
        
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            FirstParser(www.downloadHandler.text);

            StartCoroutine(DataGet());
        }


    }

    IEnumerator DataGet()
    {
        UnityWebRequest get;
        
        get = UnityWebRequest.Get(marginURL);

        yield return get.SendWebRequest();

        if (get.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(get.error);
        }
        else
        {
            //Debug.Log(marginURL + " : Get하는 중");
            
            //추출된 json 파일에서 ""이 &quot;로 보여서 json 파싱에 에러가 생김 → &quot;를 "로 바꿔주는 작업 수행
            txt = get.downloadHandler.text.Replace("&quot;", "\"");
            Debug.Log(txt);
            result = SecondParser(txt);

            
            while (result == 1)
            {
                txt = null;
                get = UnityWebRequest.Get(marginURL);

                yield return get.SendWebRequest();

                if (get.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(get.error);
                }
                else
                {
                    Debug.Log(marginURL + " : Get하는 중");
                    txt = get.downloadHandler.text.Replace("&quot;", "\"");
                    Debug.Log(txt);
                    result = SecondParser(txt);


                }
            }
                        
            Debug.Log("마진 추출 완료!");
            
            string path = DataSave.target_path;

            string marginPath = path + "/" + DataSave.dirName + "-" + margin + ".xyz";

            File.WriteAllText(@marginPath, txt, Encoding.Default);

            Margin();
        }
        
        void Margin()
        {
            StringReader reader = new StringReader(marginPoint);

            
            string line;
            int count = 0;
            int init = 0;
            int second = 1;

            string[] first;
            //int[3] firstInt;
            string[] extra;

            GameObject obj = GameObject.Find("MarginLine");
            LineRenderer lineRenderer = obj.GetComponent<LineRenderer>();
            lineRenderer.startWidth = 0.5f;
            lineRenderer.endWidth = 0.5f;

            

            while ((line = reader.ReadLine()) != null)
            {
                if(count == init)
                {
                    nodeNum = Convert.ToInt32(line);
                    lineRenderer.positionCount = nodeNum + 1; //positionCount가 lineRenderer positions의 size를 결정해줌!

                    Debug.Log(nodeNum);
                    count++;
                }
                else if(count == second)
                {
                    first = line.Split(new char[] { ' ' });
                    for(int i=0; i < first.Length; i++)
                    { 
                        Debug.Log(first[i]);
                    }

                    firstX = float.Parse(first[0]);
                    firstY = float.Parse(first[1]);
                    firstZ = float.Parse(first[2]);

                    lineRenderer.SetPosition(0, new Vector3(firstX, firstY, firstZ));
                    count++;
                }
                else
                {
                    extra = line.Split(new char[] { ' ' });

                    for(int i = 0; i < extra.Length; i++)
                    {
                        //Debug.Log(extra[i]);
                    }

                    x = float.Parse(extra[0]);
                    y = float.Parse(extra[1]);
                    z = float.Parse(extra[2]);

                    lineRenderer.SetPosition(count-1, new Vector3(x, y, z));

                    count++;
                }

            }

            lineRenderer.SetPosition(nodeNum, new Vector3(firstX, firstY, firstZ));

        }


    }

}


