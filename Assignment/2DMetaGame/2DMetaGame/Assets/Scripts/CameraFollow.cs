using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  //ī�޶� Ÿ�� ����
    public float smoothTime = 0.1f;  //�� �ε巴��? ����µ� �̰� ���󰡴� �ӵ��� ������ ���� ���� �����ӵ��� ������ ���� ������ ���� 
    private Vector3 velocity = Vector3.zero;

    // ī�޶� ���� ����
    public float minX = -8f;
    public float maxX = 7f;
    public float minY = -6f;
    public float maxY = 5.2f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        Vector3 smoothPos = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);

        // ī�޶� ������ ����ؼ� Clamp
        float camHeight = Camera.main.orthographicSize;
        float camWidth = camHeight * Camera.main.aspect;

        float clampedX = Mathf.Clamp(smoothPos.x, minX + camWidth, maxX - camWidth);
        float clampedY = Mathf.Clamp(smoothPos.y, minY + camHeight, maxY - camHeight);

        transform.position = new Vector3(clampedX, clampedY, smoothPos.z);
    }
}
