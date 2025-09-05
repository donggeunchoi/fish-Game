using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;      // 이동 속도
    [SerializeField] private float moveRange;      // 좌우 이동 범위
    [SerializeField] private bool startRight = true;    // 시작 방향

    private Vector3 startPos;
    private int direction; // 1 = 오른쪽, -1 = 왼쪽

    private void Start()
    {
        startPos = transform.position;
        direction = startRight ? 1 : -1;
    }

    private void Update()
    {
        // 좌우 이동
        transform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);

        // 시작 위치 기준으로 moveRange를 벗어나면 반대 방향으로 전환
        if (Mathf.Abs(transform.position.x - startPos.x) >= moveRange)
        {
            direction *= -1; // 방향 반전

            // 물고기 방향 전환 (y축 회전)
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
