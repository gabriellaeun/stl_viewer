using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms;
using System.IO;

public class FileDialog : MonoBehaviour
{
       
    public void FileOpen()
    {
        FolderBrowserDialog dialog = new FolderBrowserDialog();
        dialog.ShowDialog();
        string select_path = dialog.SelectedPath;
        Debug.Log("선택된 폴더" + select_path);

        DirectoryInfo di = new DirectoryInfo(@select_path);
        foreach(FileInfo file in di.GetFiles())
        {
            Debug.Log("파일명 : " + file.Name);
        }

        /*
        유니티 에셋에 추가하려면 이 폴더 자체를 유니티 Asset 폴더로 옮겨야 함
        → 현 프로젝트의 경로를 우선 알아야 함 ....
        1. 프로젝트 저장된 경로 찾는 코드 구현
            1) Application.persistentDataPath : C:\Users\사용자이름\AppData\LocalLow\회사이름
            2) Application.streamingAssetsPath : 해당 프로젝트 폴더 경로\Assets\StreamingAssets
            3) Application.dataPath : 해당 프로젝트 폴더\Assets

        2. select_path 폴더를 현 프로젝트의 Asset으로 옮기는 코드 구현
        */
        string proj_path = UnityEngine.Application.dataPath; //1. 프로젝트 Assets 경로
        Debug.Log(proj_path);

        //2.select_path 폴더를 현 프로젝트의 Asset으로 옮기는 코드

    }

}
