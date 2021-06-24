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
        string select_path = @dialog.SelectedPath;
        Debug.Log("선택된 폴더 : " + select_path);
        string DirName = Path.GetFileName(Path.GetDirectoryName(select_path));
        Debug.Log("폴더 이름 : " + DirName);

        DirectoryInfo di = new DirectoryInfo(select_path);
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

        string target_path = @Path.Combine(proj_path, "File");//디렉토리 이름이 File이 아니고 사실 복사하는 디렉토리의 이름과 같아야 함

        Directory.CreateDirectory(target_path);

        //2.select_path 폴더를 현 프로젝트의 Asset으로 옮기는 코드
        //File 디렉토리는 생기는데 폴더 내의 파일이 옮겨지지가 않음     
        if (Directory.Exists(select_path))
        {
            string[] files = Directory.GetFiles(select_path);
            foreach(string s in files)
            {
                string fileName = Path.GetFileName(s);
                string destFile = Path.Combine(target_path, fileName);
                File.Copy(s, destFile, true);
            }
        }
        else
        {
            Debug.Log("Source path does not exist");
        }
    }

    

}
