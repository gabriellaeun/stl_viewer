using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    //float m_zoomSpeed = 10f;
    float m_zoomMax = 100f;
    float m_zoomMin = -100f;
    float scale, scale_x, scale_y, scale_z;
    //Inspector 창 보면서 확대 축소를 해보며 max값과 min값 조절

    void ObjZoom()
    {
        float t_zoomDirection = Input.GetAxis("Mouse ScrollWheel");//휠 위로 돌리면 1, 아래로 돌리면 -1 리턴

        if (transform.position.z <= m_zoomMin && t_zoomDirection < 0) //최소 범위보다 작으면 축소 그만
            return;
        if (transform.position.z >= m_zoomMax && t_zoomDirection > 0) //최대 범위 넘으면 확대 그만
            return;

        
        transform.localScale = new Vector3(transform.localScale.x + t_zoomDirection * 0.5f,transform.localScale.y + t_zoomDirection * 0.5f,transform.localScale.z + t_zoomDirection * 0.5f);
        //숫자 커질수록 zoom in/out 속도가 빨라짐
    }
    
    void Update()
    {
        ObjZoom();
    }
}
