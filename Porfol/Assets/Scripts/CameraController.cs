using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // ** 카메라 고정 및 이동
    private bool doMovement = true;

    // ** 스크린이 움직일 속도
    public float panSpeed = 30.0f;
    // ** 스크린을 움직일 가장자리 두께
    public float panBorderThickness = 10.0f;

    // ** 카메라가 오르락내리락할 속도
    public float scrollSpeed = 5.0f;
    // ** 카메라의 y축 최소 높이
    public float minY = 10.0f;
    // ** 카메라의 y축 최대 높이
    public float maxY = 80.0f;

    void Update()
    {
        // ** 게임 오버 시, 카메라를 비활성화 한다
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        // ** ESC 버튼 입력 시
        if (Input.GetKeyDown(KeyCode.Escape))
            // ** 카메라를 고정한다
            doMovement = !doMovement;

        // ** 카메라 고정 시 여기서 반환한다
        if (!doMovement)
            return;

        // ** 키 입력 혹은 마우스 포인터를 스크린 가장자리로 이동할 시, 카메라 이동
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        // ** 마우스 휠 스크롤
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // ** 카메라의 위치
        Vector3 pos = transform.position;

        // ** 카메라의 y축을 휠 스크롤에 따라 변경한다
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        // ** 카메라의 y축 최소최대 높이를 제한한다
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        // ** 카메라의 위치를 설정한다
        transform.position = pos;
    }
}
