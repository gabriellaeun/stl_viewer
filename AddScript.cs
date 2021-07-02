using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScript : MonoBehaviour
{
    void AddUpper()
    {
        GameObject u0 = GameObject.Find("1(0)");
        GameObject u1 = GameObject.Find("1(1)");
        GameObject u2 = GameObject.Find("1(2)");
        GameObject u3 = GameObject.Find("1(3)");
        GameObject u4 = GameObject.Find("1(4)");
        GameObject u5 = GameObject.Find("1(5)");
        GameObject u6 = GameObject.Find("1(6)");
        GameObject u7 = GameObject.Find("1(7)");
        GameObject u8 = GameObject.Find("1(8)");
        GameObject u9 = GameObject.Find("1(9)");
        GameObject u10 = GameObject.Find("1(10)");

        u0.AddComponent<PointController>();
        u1.AddComponent<PointController>();
        u2.AddComponent<PointController>();
        u3.AddComponent<PointController>();
        u4.AddComponent<PointController>();
        u5.AddComponent<PointController>();
        u6.AddComponent<PointController>();
        u7.AddComponent<PointController>();
        u8.AddComponent<PointController>();
        u9.AddComponent<PointController>();
        u10.AddComponent<PointController>();
    }
    void EnUpper()
    {
        GameObject u0 = GameObject.Find("1(0)");
        GameObject u1 = GameObject.Find("1(1)");
        GameObject u2 = GameObject.Find("1(2)");
        GameObject u3 = GameObject.Find("1(3)");
        GameObject u4 = GameObject.Find("1(4)");
        GameObject u5 = GameObject.Find("1(5)");
        GameObject u6 = GameObject.Find("1(6)");
        GameObject u7 = GameObject.Find("1(7)");
        GameObject u8 = GameObject.Find("1(8)");
        GameObject u9 = GameObject.Find("1(9)");
        GameObject u10 = GameObject.Find("1(10)");

        u0.GetComponent<PointController>().enabled = false;
        u1.GetComponent<PointController>().enabled = false;
        u2.GetComponent<PointController>().enabled = false;
        u3.GetComponent<PointController>().enabled = false;
        u4.GetComponent<PointController>().enabled = false;
        u5.GetComponent<PointController>().enabled = false;
        u6.GetComponent<PointController>().enabled = false;
        u7.GetComponent<PointController>().enabled = false;
        u8.GetComponent<PointController>().enabled = false;
        u9.GetComponent<PointController>().enabled = false;
        u10.GetComponent<PointController>().enabled = false;

    }
    void AddLower()
    {
        GameObject l0 = GameObject.Find("2(0)");
        GameObject l1 = GameObject.Find("2(1)");
        GameObject l2 = GameObject.Find("2(2)");
        GameObject l3 = GameObject.Find("2(3)");
        GameObject l4 = GameObject.Find("2(4)");
        GameObject l5 = GameObject.Find("2(5)");
        GameObject l6 = GameObject.Find("2(6)");
        GameObject l7 = GameObject.Find("2(7)");
        GameObject l8 = GameObject.Find("2(8)");
        GameObject l9 = GameObject.Find("2(9)");
        GameObject l10 = GameObject.Find("2(10)");

        l0.AddComponent<PointController>();
        l1.AddComponent<PointController>();
        l2.AddComponent<PointController>();
        l3.AddComponent<PointController>();
        l4.AddComponent<PointController>();
        l5.AddComponent<PointController>();
        l6.AddComponent<PointController>();
        l7.AddComponent<PointController>();
        l8.AddComponent<PointController>();
        l9.AddComponent<PointController>();
        l10.AddComponent<PointController>();
    }
    void EnLower()
    {
        GameObject l0 = GameObject.Find("2(0)");
        GameObject l1 = GameObject.Find("2(1)");
        GameObject l2 = GameObject.Find("2(2)");
        GameObject l3 = GameObject.Find("2(3)");
        GameObject l4 = GameObject.Find("2(4)");
        GameObject l5 = GameObject.Find("2(5)");
        GameObject l6 = GameObject.Find("2(6)");
        GameObject l7 = GameObject.Find("2(7)");
        GameObject l8 = GameObject.Find("2(8)");
        GameObject l9 = GameObject.Find("2(9)");
        GameObject l10 = GameObject.Find("2(10)");

        l0.GetComponent<PointController>().enabled = false;
        l1.GetComponent<PointController>().enabled = false;
        l2.GetComponent<PointController>().enabled = false;
        l3.GetComponent<PointController>().enabled = false;
        l4.GetComponent<PointController>().enabled = false;
        l5.GetComponent<PointController>().enabled = false;
        l6.GetComponent<PointController>().enabled = false;
        l7.GetComponent<PointController>().enabled = false;
        l8.GetComponent<PointController>().enabled = false;
        l9.GetComponent<PointController>().enabled = false;
        l10.GetComponent<PointController>().enabled = false;
    }

    void AddLowAb()
    {
        GameObject LowAb0 = GameObject.Find("2(0)");
        GameObject LowAb1 = GameObject.Find("2(1)");
        GameObject LowAb2 = GameObject.Find("2(2)");
        GameObject LowAb3 = GameObject.Find("2(3)");

        LowAb0.AddComponent<PointController>();
        LowAb1.AddComponent<PointController>();
        LowAb2.AddComponent<PointController>();
        LowAb3.AddComponent<PointController>();
    }

    void EnLowAb()
    {
        GameObject LowAb0 = GameObject.Find("2(0)");
        GameObject LowAb1 = GameObject.Find("2(1)");
        GameObject LowAb2 = GameObject.Find("2(2)");
        GameObject LowAb3 = GameObject.Find("2(3)");

        LowAb0.GetComponent<PointController>().enabled = false;
        LowAb1.GetComponent<PointController>().enabled = false;
        LowAb2.GetComponent<PointController>().enabled = false;
        LowAb3.GetComponent<PointController>().enabled = false;
    }

    void AddUpAb()
    {
        GameObject UpAb0 = GameObject.Find("1(0)");
        GameObject UpAb1 = GameObject.Find("1(1)");
        GameObject UpAb2 = GameObject.Find("1(2)");
        GameObject UpAb3 = GameObject.Find("1(3)");

        UpAb0.AddComponent<PointController>();
        UpAb1.AddComponent<PointController>();
        UpAb2.AddComponent<PointController>();
        UpAb3.AddComponent<PointController>();
    }

    void EnUpAb()
    {
        GameObject UpAb0 = GameObject.Find("1(0)");
        GameObject UpAb1 = GameObject.Find("1(1)");
        GameObject UpAb2 = GameObject.Find("1(2)");
        GameObject UpAb3 = GameObject.Find("1(3)");

        UpAb0.GetComponent<PointController>().enabled = false;
        UpAb1.GetComponent<PointController>().enabled = false;
        UpAb2.GetComponent<PointController>().enabled = false;
        UpAb3.GetComponent<PointController>().enabled = false;
    }

    void AddCopyUp()
    {
        GameObject cu0 = GameObject.Find("1-copy(0)");
        GameObject cu1 = GameObject.Find("1-copy(1)");
        GameObject cu2 = GameObject.Find("1-copy(2)");
        GameObject cu3 = GameObject.Find("1-copy(3)");
        GameObject cu4 = GameObject.Find("1-copy(4)");
        GameObject cu5 = GameObject.Find("1-copy(5)");
        GameObject cu6 = GameObject.Find("1-copy(6)");
        GameObject cu7 = GameObject.Find("1-copy(7)");
        GameObject cu8 = GameObject.Find("1-copy(8)");
        GameObject cu9 = GameObject.Find("1-copy(9)");
        GameObject cu10 = GameObject.Find("1-copy(10)");

        cu0.AddComponent<PointController>();
        cu1.AddComponent<PointController>();
        cu2.AddComponent<PointController>();
        cu3.AddComponent<PointController>();
        cu4.AddComponent<PointController>();
        cu5.AddComponent<PointController>();
        cu6.AddComponent<PointController>();
        cu7.AddComponent<PointController>();
        cu8.AddComponent<PointController>();
        cu9.AddComponent<PointController>();
        cu10.AddComponent<PointController>();
    }

    void EnCopyUp()
    {
        GameObject cu0 = GameObject.Find("1-copy(0)");
        GameObject cu1 = GameObject.Find("1-copy(1)");
        GameObject cu2 = GameObject.Find("1-copy(2)");
        GameObject cu3 = GameObject.Find("1-copy(3)");
        GameObject cu4 = GameObject.Find("1-copy(4)");
        GameObject cu5 = GameObject.Find("1-copy(5)");
        GameObject cu6 = GameObject.Find("1-copy(6)");
        GameObject cu7 = GameObject.Find("1-copy(7)");
        GameObject cu8 = GameObject.Find("1-copy(8)");
        GameObject cu9 = GameObject.Find("1-copy(9)");
        GameObject cu10 = GameObject.Find("1-copy(10)");

        cu0.GetComponent<PointController>().enabled = false;
        cu1.GetComponent<PointController>().enabled = false;
        cu2.GetComponent<PointController>().enabled = false;
        cu3.GetComponent<PointController>().enabled = false;
        cu4.GetComponent<PointController>().enabled = false;
        cu5.GetComponent<PointController>().enabled = false;
        cu6.GetComponent<PointController>().enabled = false;
        cu7.GetComponent<PointController>().enabled = false;
        cu8.GetComponent<PointController>().enabled = false;
        cu9.GetComponent<PointController>().enabled = false;
        cu10.GetComponent<PointController>().enabled = false;
    }

    void AddCopyLow()
    {
        GameObject cl0 = GameObject.Find("2-copy(0)");
        GameObject cl1 = GameObject.Find("2-copy(1)");
        GameObject cl2 = GameObject.Find("2-copy(2)");
        GameObject cl3 = GameObject.Find("2-copy(3)");
        GameObject cl4 = GameObject.Find("2-copy(4)");
        GameObject cl5 = GameObject.Find("2-copy(5)");
        GameObject cl6 = GameObject.Find("2-copy(6)");
        GameObject cl7 = GameObject.Find("2-copy(7)");
        GameObject cl8 = GameObject.Find("2-copy(8)");
        GameObject cl9 = GameObject.Find("2-copy(9)");
        GameObject cl10 = GameObject.Find("2-copy(10)");

        cl0.AddComponent<PointController>();
        cl1.AddComponent<PointController>();
        cl2.AddComponent<PointController>();
        cl3.AddComponent<PointController>();
        cl4.AddComponent<PointController>();
        cl5.AddComponent<PointController>();
        cl6.AddComponent<PointController>();
        cl7.AddComponent<PointController>();
        cl8.AddComponent<PointController>();
        cl9.AddComponent<PointController>();
        cl10.AddComponent<PointController>();
    }

    void EnCopyLow()
    {
        GameObject cl0 = GameObject.Find("2-copy(0)");
        GameObject cl1 = GameObject.Find("2-copy(1)");
        GameObject cl2 = GameObject.Find("2-copy(2)");
        GameObject cl3 = GameObject.Find("2-copy(3)");
        GameObject cl4 = GameObject.Find("2-copy(4)");
        GameObject cl5 = GameObject.Find("2-copy(5)");
        GameObject cl6 = GameObject.Find("2-copy(6)");
        GameObject cl7 = GameObject.Find("2-copy(7)");
        GameObject cl8 = GameObject.Find("2-copy(8)");
        GameObject cl9 = GameObject.Find("2-copy(9)");
        GameObject cl10 = GameObject.Find("2-copy(10)");

        cl0.GetComponent<PointController>().enabled = false;
        cl1.GetComponent<PointController>().enabled = false;
        cl2.GetComponent<PointController>().enabled = false;
        cl3.GetComponent<PointController>().enabled = false;
        cl4.GetComponent<PointController>().enabled = false;
        cl5.GetComponent<PointController>().enabled = false;
        cl6.GetComponent<PointController>().enabled = false;
        cl7.GetComponent<PointController>().enabled = false;
        cl8.GetComponent<PointController>().enabled = false;
        cl9.GetComponent<PointController>().enabled = false;
        cl10.GetComponent<PointController>().enabled = false;
    }

    public void ObjAddScript()
    {
        if(null != GameObject.Find("1-copy"))
        {
            AddCopyUp();
            AddUpAb();
            AddLower();
        }
        else if (null != GameObject.Find("2-copy"))
        {
            AddCopyLow();
            AddLowAb();
            AddUpper();
        }
        else if(null == GameObject.Find("1-copy") && null == GameObject.Find("2-copy"))
        {
            AddLower();
            AddUpper();
        }
    }

    public void ObjremoveScript()
    {
        if(null != GameObject.Find("1-copy"))
        {
            EnCopyUp();
            EnUpAb();
            EnLower();
        }
        else if (null != GameObject.Find("2-copy"))
        {
            EnCopyLow();
            EnLowAb();
            EnUpper();
        }
        else if (null == GameObject.Find("1-copy") && null == GameObject.Find("2-copy"))
        {
            EnLower();
            EnUpper();
        }

    }


}
