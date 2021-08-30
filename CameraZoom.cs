using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public GameObject target;     //추적할 타겟 게임 오브젝트의 Transform 변수
    public float rotateSpeed = 10.0f;
    public float zoomSpeed = 10.0f;

    private Camera mainCam;

    // Use this for initialization
    void Start()
    {
        mainCam = GetComponent<Camera>();
    }

    void Update()
    {
        Zoom();
        Rotate();
    }

    private void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if (distance != 0)
        {
            mainCam.fieldOfView += distance;
        }
    }

    private void Rotate()
    {
        if (Input.GetMouseButton(0))
        {
            /*
            Vector3 rot = transform.rotation.eulerAngles; // 현재 카메라의 각도를 Vector3로 반환
            rot.y += Input.GetAxis("Mouse X") * rotateSpeed; // 마우스 X 위치 * 회전 스피드
            rot.x += -1 * Input.GetAxis("Mouse Y") * rotateSpeed; // 마우스 Y 위치 * 회전 스피드
            Quaternion q = Quaternion.Euler(rot); // Quaternion으로 변환
            q.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f); // 자연스럽게 회전
            */
            transform.RotateAround(target.transform.position, Vector3.up, Input.GetAxis("Mouse X") * rotateSpeed);
            transform.RotateAround(target.transform.position, Vector3.right, -Input.GetAxis("Mouse Y") * rotateSpeed);
        }
    }
}
