using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjZoom : MonoBehaviour
{
    [SerializeField] float m_zoomSpeed = 0f;
    [SerializeField] float m_zoomMax = 0f;
    [SerializeField] float m_zoomMin = 0f;
    //확대 축소를 해보며 max값과 min값 조절
    float z_position;

    float Zoom()
    {
        float t_zoomDirection = Input.GetAxis("Mouse ScrollWheel");//휠 위로 돌리면 1, 아래로 돌리면 -1 리턴

        if (transform.position.z >= m_zoomMax && t_zoomDirection > 0) //최대 범위 넘으면 확대 그만
            return gameObject.transform.position.z;
        
        if (transform.position.z <= m_zoomMin && t_zoomDirection < 0) //최소 범위보다 작으면 축소 그만
            return gameObject.transform.position.z;
   
        transform.position += -1* transform.forward * t_zoomDirection * m_zoomSpeed;
        //Debug.Log(gameObject.transform.position.z);
        return gameObject.transform.position.z;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, gameObject.transform.position.z);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.transform.position.z);
        z_position = Zoom();
        //Debug.Log(gameObject.transform.position.z);
        //z_position = gameObject.transform.position.z;

        if (Input.GetMouseButton(0))
        {
            OnMouseDrag();
        }
    }
}
