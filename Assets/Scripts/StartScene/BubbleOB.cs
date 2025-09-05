using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleOB : MonoBehaviour
{
    [SerializeField] private float riseSpeed = 1f;     // 상승 속도
    [SerializeField] private float floatRange = 0.2f;  // 좌우/상하 흔들림 범위
    [SerializeField] private float floatSpeed = 2f;    // 흔들림 속도
    [SerializeField] private float destroyHeight = 10f; // 사라질 높이 (월드 Y 좌표 기준)

    private void Update()
    {
        // Y축으로 계속 상승
        transform.position += Vector3.up * riseSpeed * Time.deltaTime;

        // 살짝 흔들림(자연스럽게)
        float offsetX = Mathf.Sin(Time.time * floatSpeed + GetInstanceID()) * floatRange;
        float offsetZ = Mathf.Cos(Time.time * floatSpeed + GetInstanceID()) * floatRange;

        transform.position = new Vector3(
            transform.position.x + offsetX * Time.deltaTime,
            transform.position.y,
            transform.position.z + offsetZ * Time.deltaTime
        );

        // 일정 높이에 도달하면 오브젝트 삭제
        if (transform.position.y >= destroyHeight)
        {
            Destroy(gameObject);
        }
    }
}
