using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // ** ī�޶� ���� �� �̵�
    private bool doMovement = true;

    // ** ��ũ���� ������ �ӵ�
    public float panSpeed = 30.0f;
    // ** ��ũ���� ������ �����ڸ� �β�
    public float panBorderThickness = 10.0f;

    // ** ī�޶� �������������� �ӵ�
    public float scrollSpeed = 5.0f;
    // ** ī�޶��� y�� �ּ� ����
    public float minY = 10.0f;
    // ** ī�޶��� y�� �ִ� ����
    public float maxY = 80.0f;

    void Update()
    {
        // ** ���� ���� ��, ī�޶� ��Ȱ��ȭ �Ѵ�
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        // ** ESC ��ư �Է� ��
        if (Input.GetKeyDown(KeyCode.Escape))
            // ** ī�޶� �����Ѵ�
            doMovement = !doMovement;

        // ** ī�޶� ���� �� ���⼭ ��ȯ�Ѵ�
        if (!doMovement)
            return;

        // ** Ű �Է� Ȥ�� ���콺 �����͸� ��ũ�� �����ڸ��� �̵��� ��, ī�޶� �̵�
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

        // ** ���콺 �� ��ũ��
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // ** ī�޶��� ��ġ
        Vector3 pos = transform.position;

        // ** ī�޶��� y���� �� ��ũ�ѿ� ���� �����Ѵ�
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        // ** ī�޶��� y�� �ּ��ִ� ���̸� �����Ѵ�
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        // ** ī�޶��� ��ġ�� �����Ѵ�
        transform.position = pos;
    }
}
