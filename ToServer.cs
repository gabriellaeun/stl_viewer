using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Text;
using LitJson;

public class ToServer : MonoBehaviour
{
    public static string margin;
    public static string marginURL;
    public static string marginPoint;
    int result;
    string txt;

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

        byte[] bytes = File.ReadAllBytes(@"C:\Users\82105\Desktop\ClearTech\다른치아_샘플\2017-11-14_100217566\2.stl");

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
            Debug.Log(marginURL + " : Get하는 중");

            //get.downloadHander = new DownloadHandlerBuffer();
            
            
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

                    //get.downloadHander = new DownloadHandlerBuffer();
                    txt = get.downloadHandler.text.Replace("&quot;", "\"");
                    Debug.Log(txt);
                    result = SecondParser(txt);


                }
            }

            


            Debug.Log("마진 추출 완료!");
            /*
            if(result == 1)
            {
                Debug.Log("마진 추출 전");

            }
            */

            //File.WriteAllBytes(@"C:\Users\File", get.downloadHander.text);

            string path = DataSave.target_path;

            string marginPath = path + "/" + DataSave.dirName + "-" + margin + ".xyz";

            File.WriteAllText(@marginPath, txt, Encoding.Default);
        }
        
    }

}


