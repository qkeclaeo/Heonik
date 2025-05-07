using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  //카메라 타겟 설정
    public float smoothTime = 0.1f;  //더 부드럽게? 만드는데 이게 따라가는 속도가 늦으면 늦을 수록 반응속도가 느려짐 질질 끌리는 느낌 
    private Vector3 velocity = Vector3.zero;

    // 카메라 제한 범위
    public float minX = -8f;
    public float maxX = 7f;
    public float minY = -6f;
    public float maxY = 5.2f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        Vector3 smoothPos = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);

        // 카메라 사이즈 고려해서 Clamp
        float camHeight = Camera.main.orthographicSize;
        float camWidth = camHeight * Camera.main.aspect;

        float clampedX = Mathf.Clamp(smoothPos.x, minX + camWidth, maxX - camWidth);
        float clampedY = Mathf.Clamp(smoothPos.y, minY + camHeight, maxY - camHeight);

        transform.position = new Vector3(clampedX, clampedY, smoothPos.z);
    }
}
