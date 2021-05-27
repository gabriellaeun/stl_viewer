using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    //float m_zoomSpeed = 10f;
    float m_zoomMax = 110f;
    float m_zoomMin = 20f;
    float scale, scale_x, scale_y, scale_z;
    //Inspector 창 보면서 확대 축소를 해보며 max값과 min값 조절

    void ObjZoom()
    {
        float t_zoomDirection = Input.GetAxis("Mouse ScrollWheel");//휠 위로 돌리면 1, 아래로 돌리면 -1 리턴

        if (transform.position.z <= m_zoomMin && t_zoomDirection > 0) //최소 범위보다 작으면 축소 그만
            return;
        if (transform.position.z >= m_zoomMax && t_zoomDirection < 0) //최대 범위 넘으면 확대 그만
            return;

        //scale += t_zoomDirection * m_zoomSpeed;

        //scale_x = transform.localScale.x;
        //scale_y = transform.localScale.y;
        //scale_z = transform.localScale.z;

        transform.localScale = new Vector3(transform.localScale.x + t_zoomDirection * 0.05f,transform.localScale.y + t_zoomDirection * 0.05f,transform.localScale.z + t_zoomDirection * 0.05f);

        //transform.localScale = new Vector3((float)0.1* scale + scale_x, (float)0.1*scale + scale_y, (float)0.1*scale + scale_y);
    }
    
    void Update()
    {
        ObjZoom();
    }
}
