using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FishController : MonoBehaviour
{

    public FishMonster fishData; // SO 참조

    private SpriteRenderer sr;
    private float direction = 1f;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        if (fishData != null)
        {
            // 데이터 적용
            sr.sprite = fishData.sprite;
            gameObject.name = fishData.fishName;
        }
    }

    void Update()
    {
        if (fishData == null) return;

        // 좌우 이동 예시
        if (fishData.canSwimLeftRight)
        {
            transform.Translate(Vector2.right * fishData.moveSpeed * direction * Time.deltaTime);

            // 화면 양쪽 끝에서 반전 (예: x 좌표 5 넘어가면 방향 전환)
            if (Mathf.Abs(transform.position.x) > 5f)
            {
                direction *= -1f;
                sr.flipX = direction < 0f;
            }
        }
    }
}
