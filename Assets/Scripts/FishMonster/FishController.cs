using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FishController : MonoBehaviour
{
    public FishMonster fishData; // SO 참조

    private SpriteRenderer sr;
    private float direction = 1f;

    public int moveRangeMax;
    public int moveRangeMin;
    public int moveRange;
    private Vector3 spawnPosition;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        if (fishData != null)
        {
            // 데이터 적용
            sr.sprite = fishData.sprite;
            gameObject.name = fishData.fishName;
        }
        
        spawnPosition = transform.position;
        
        moveRange = Random.Range(moveRangeMin, moveRangeMax);
    }

    void Update()
    {
        if (fishData == null) return;
       
        transform.Translate(Vector2.right * fishData.moveSpeed * direction * Time.deltaTime);

        float distanceFromSpawn = transform.position.x - spawnPosition.x;
        
        
        if (Mathf.Abs(distanceFromSpawn) >= moveRange)
        {
            direction *= -1f;
            sr.flipX = direction < 0f;
        }
        
    }
}
