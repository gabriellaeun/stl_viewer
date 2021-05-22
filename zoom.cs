using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] float m_zoomSpeed = 0f; 
    [SerializeField] float m_zoomMax = 0f; 
    [SerializeField] float m_zoomMin = 0f; 
    //Camera Inspector 창 보면서 확대 축소를 해보며 max값과 min값 조절


    void CameraZoom()
    {
        float t_zoomDirection = Input.GetAxis("Mouse ScrollWheel");//휠 위로 돌리면 1, 아래로 돌리면 -1 리턴

        if (transform.position.z >= m_zoomMax && t_zoomDirection > 0) //최대 범위 넘으면 확대 그만
            return;
        if (transform.position.z <= m_zoomMin && t_zoomDirection < 0) //최소 범위보다 작으면 축소 그만
            return;

        transform.position += transform.forward * t_zoomDirection * m_zoomSpeed; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraZoom();
    }
}
