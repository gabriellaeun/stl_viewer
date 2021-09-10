using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{
    
    public GameObject targetL;
    public GameObject targetU;
    public GameObject Abut;
    public GameObject Crown;

    CameraZoom camerazoom;
    GameObject margin;

    Toggle toggleU;
    Toggle toggleL;
    Toggle toggleA;
    Toggle toggleM;
    Toggle toggleC;

    public void GetObj()
    {
        FileDialog name = GameObject.Find("folder").GetComponent<FileDialog>();
        //name.DirName 사용

        targetL = Resources.Load<GameObject>(name.DirName + "/2-copy");
        camerazoom = GameObject.Find("Main Camera").GetComponent<CameraZoom>();
        margin = GameObject.Find("MarginLine");

        Debug.Log(name.crownName);
        Crown = Resources.Load<GameObject>(name.DirName + "/" + name.crownName);

        GameObject cloneC = Instantiate(Crown);//크라운
        toggleC = GameObject.Find("CrownTog").GetComponent<Toggle>();
        toggleC.gameobj = cloneC;

        if (targetL == null)
        {
            targetL = Resources.Load<GameObject>(name.DirName + "/2-COPY");
            if (targetL == null) // 하악에 지대치가 없을 경우(지대치가 상악인 경우)
            {
                targetL = Resources.Load<GameObject>(name.DirName + "/2");
                targetU = Resources.Load<GameObject>(name.DirName + "/1-copy");
                Abut = Resources.Load<GameObject>(name.DirName + "/1");
                if (targetU == null) //상악 이름이 1-COPY인 경우
                {
                    /*
                    targetU = Resources.Load<GameObject>(name.DirName + "/1-COPY");
                    GameObject cloneL = Instantiate(targetL, new Vector3(0.05f, -0.2f, 80f), Quaternion.Euler(new Vector3(-90f, -10f, 0f))); //하악
                    targetL.transform.localScale = new Vector3(1f, 1f, 1f);
                    GameObject cloneU = Instantiate(targetU, new Vector3(0.05f, -0.2f, 80f), Quaternion.Euler(new Vector3(-90f, -10f, 0f))); //상악
                    targetU.transform.localScale = new Vector3(1f, 1f, 1f);
                    GameObject cloneA = Instantiate(Abut, new Vector3(0.05f, -0.2f, 80f), Quaternion.Euler(new Vector3(-90f, -10f, 0f))); //상악 지대치
                    Abut.transform.localScale = new Vector3(1f, 1f, 1f);
                    */

                    targetU = Resources.Load<GameObject>(name.DirName + "/1-COPY");
                    GameObject cloneL = Instantiate(targetL); //하악
                    GameObject cloneU = Instantiate(targetU); //상악
                    GameObject cloneA = Instantiate(Abut); //상악 지대치

                    /*
                    cloneL.AddComponent<Rotate>();
                    cloneL.AddComponent<Zoom>();
                    cloneU.AddComponent<Rotate>();
                    cloneU.AddComponent<Zoom>();
                    cloneA.AddComponent<Rotate>();
                    cloneA.AddComponent<Zoom>();
                    */
                    camerazoom.target = cloneL;

                    toggleU = GameObject.Find("UpperTog").GetComponent<Toggle>();
                    toggleU.gameobj = cloneU;
                    toggleL = GameObject.Find("LowerTog").GetComponent<Toggle>();
                    toggleL.gameobj = cloneL;
                    toggleA = GameObject.Find("AbutmentTog").GetComponent<Toggle>();
                    toggleA.gameobj = cloneA;

                    toggleM = GameObject.Find("MarginTog").GetComponent<Toggle>();
                    toggleM.gameobj = margin;

                    /*
                    initU = GameObject.Find("initialize").GetComponent<start>();
                    initU.upper = cloneU;
                    initL = GameObject.Find("initialize").GetComponent<start>();
                    initL.lower = cloneL;
                    initA = GameObject.Find("initialize").GetComponent<start>();
                    initA.abut = cloneA;
                    */
                }
                else //상악 이름이 1-copy인 경우
                {
                    GameObject cloneL = Instantiate(targetL); //하악
                    GameObject cloneU = Instantiate(targetU); //상악
                    GameObject cloneA = Instantiate(Abut); //상악 지대치

                    /*
                    cloneL.AddComponent<Rotate>();
                    cloneL.AddComponent<Zoom>();
                    cloneU.AddComponent<Rotate>();
                    cloneU.AddComponent<Zoom>();
                    cloneA.AddComponent<Rotate>();
                    cloneA.AddComponent<Zoom>();
                    */
                    camerazoom.target = cloneL;

                    toggleU = GameObject.Find("UpperTog").GetComponent<Toggle>();
                    toggleU.gameobj = cloneU;
                    toggleL = GameObject.Find("LowerTog").GetComponent<Toggle>();
                    toggleL.gameobj = cloneL;
                    toggleA = GameObject.Find("AbutmentTog").GetComponent<Toggle>();
                    toggleA.gameobj = cloneA;

                    toggleM = GameObject.Find("MarginTog").GetComponent<Toggle>();
                    toggleM.gameobj = margin;

                    /*
                    initU = GameObject.Find("initialize").GetComponent<start>();
                    initU.upper = cloneU;
                    initL = GameObject.Find("initialize").GetComponent<start>();
                    initL.lower = cloneL;
                    initA = GameObject.Find("initialize").GetComponent<start>();
                    initA.abut = cloneA;
                    */
                }
            }
            else //하악에 지대치가 있을 경우(하악 이름이 2-COPY(COPY 대문자로 되어있는 경우))
            {
                targetL = Resources.Load<GameObject>(name.DirName + "/2-COPY");
                targetU = Resources.Load<GameObject>(name.DirName + "/1");
                Abut = Resources.Load<GameObject>(name.DirName + "/2");
                GameObject cloneL = Instantiate(targetL); //하악
                GameObject cloneU = Instantiate(targetU); //상악
                GameObject cloneA = Instantiate(Abut); //상악 지대치

                /*
                cloneL.AddComponent<Rotate>();
                cloneL.AddComponent<Zoom>();
                cloneU.AddComponent<Rotate>();
                cloneU.AddComponent<Zoom>();
                cloneA.AddComponent<Rotate>();
                cloneA.AddComponent<Zoom>();
                */

                camerazoom.target = cloneL;

                toggleU = GameObject.Find("UpperTog").GetComponent<Toggle>();
                toggleU.gameobj = cloneU;
                toggleL = GameObject.Find("LowerTog").GetComponent<Toggle>();
                toggleL.gameobj = cloneL;
                toggleA = GameObject.Find("AbutmentTog").GetComponent<Toggle>();
                toggleA.gameobj = cloneA;

                toggleM = GameObject.Find("MarginTog").GetComponent<Toggle>();
                toggleM.gameobj = margin;

                /*
                initU = GameObject.Find("initialize").GetComponent<start>();
                initU.upper = cloneU;
                initL = GameObject.Find("initialize").GetComponent<start>();
                initL.lower = cloneL;
                initA = GameObject.Find("initialize").GetComponent<start>();
                initA.abut = cloneA;
                */
            }
        }
        else //하악에 지대치가 있을 경우(하악 이름이 2-copy)
        {
            targetL = Resources.Load<GameObject>(name.DirName + "/2-copy");
            targetU = Resources.Load<GameObject>(name.DirName + "/1");
            Abut = Resources.Load<GameObject>(name.DirName + "/2");
            GameObject cloneL = Instantiate(targetL); //하악
            GameObject cloneU = Instantiate(targetU); //상악
            GameObject cloneA = Instantiate(Abut); //상악 지대치

            /*
            cloneL.AddComponent<Rotate>();
            cloneL.AddComponent<Zoom>();
            cloneU.AddComponent<Rotate>();
            cloneU.AddComponent<Zoom>();
            cloneA.AddComponent<Rotate>();
            cloneA.AddComponent<Zoom>();
            */
            camerazoom.target = cloneL;

            toggleU = GameObject.Find("UpperTog").GetComponent<Toggle>();
            toggleU.gameobj = cloneU;
            toggleL = GameObject.Find("LowerTog").GetComponent<Toggle>();
            toggleL.gameobj = cloneL;
            toggleA = GameObject.Find("AbutmentTog").GetComponent<Toggle>();
            toggleA.gameobj = cloneA;

            toggleM = GameObject.Find("MarginTog").GetComponent<Toggle>();
            toggleM.gameobj = margin;

            /*
            initU = GameObject.Find("initialize").GetComponent<start>();
            initU.upper = cloneU;
            initL = GameObject.Find("initialize").GetComponent<start>();
            initL.lower = cloneL;
            initA = GameObject.Find("initialize").GetComponent<start>();
            initA.abut = cloneA;
            */
        }

    }
}
