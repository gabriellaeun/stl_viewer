using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using Newtonsoft.Json;
using System.Text;

public class ToServer : MonoBehaviour
{
    
    public void MarginExtract()
    {
        StartCoroutine(DataPost());
    }

    IEnumerator DataPost()
    {
        string url = "http://dentalcad.ai:6003/margin/req_nonblock/";

        byte[] bytes = File.ReadAllBytes(@"C:\Users\82105\Desktop\ClearTech\다른치아_샘플\2017-11-14_100217566\2.stl");

        WWWForm form = new WWWForm();
        form.AddField("content", "CONTENT");
        form.AddField("title", "TITLE");
        form.AddBinaryData("file", bytes, @"C:\Users\82105\Desktop\ClearTech\다른치아_샘플\2017-11-14_100217566\2.stl", "application/octet-stream");


        UnityWebRequest www = UnityWebRequest.Post(url, form);
        //www.downloadHander = new DownloadHandlerBuffer();
        //www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("성공");
            /*
            JObject decoded = JObject.Parse(www.downloadHandler.text);

            JToken datas = decoded["arrayKey"];
            foreach(JToken data in datas)
            {
                Debug.Log(data["key1"].ToObject<string>());
                Debug.Log(data["key2"].ToObject<string>());
            }
            */
            //Debug.LogFormat("{0}\n{1}\n{2}", www.responseCode, www.downloadHandler.data, www.downloadHandler.text);
            
        }


    }
    
}


