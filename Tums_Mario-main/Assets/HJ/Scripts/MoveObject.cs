using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private Vector3 targetPosition;
    private bool startMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = transform.position + (Vector3.forward * -1.5f); // 목표 위치 설정
        startMoving = true;
    }

    void FixedUpdate()
    {
        if (startMoving)
        {
            // 현재 위치에서 목표 위치로의 방향 벡터 계산
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            // 목표 위치에 도달하지 않았으면, Rigidbody의 MovePosition을 사용하여 이동
            if ((targetPosition - transform.position).magnitude > 0.1f) // 목표와의 거리가 충분히 가까워질 때까지
            {
                rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
            }
            else
            {
                startMoving = false; // 목표에 도달하면 이동 중지
                Debug.Log("이동 중단");
            }
        }
    }
}