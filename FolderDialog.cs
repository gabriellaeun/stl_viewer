using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Forms;

public class FileDialog : MonoBehaviour
{
       
    public void FileOpen()
    {
        FolderBrowserDialog dialog = new FolderBrowserDialog();
        dialog.ShowDialog();
        string select_path = dialog.SelectedPath;
        Debug.Log("선택된 폴더" + select_path);
    }

}
