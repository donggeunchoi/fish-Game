using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
   [SerializeField] private GameObject bubblePrefab;
   [SerializeField] private Transform spawnPoint;
   [SerializeField] private int bubbleCount;
   [SerializeField] private float spawnRadius;
   [SerializeField] private Transform SpawnPosition;

   public void Start()
   {
      for (int i = 0; i < bubbleCount; i++)
      {
         // 스폰포인트를 기준으로 랜덤한 위치 구하기
         Vector3 randomOffset = new Vector3(
            Random.Range(-spawnRadius, spawnRadius),
            Random.Range(-spawnRadius, spawnRadius),
            Random.Range(-spawnRadius, spawnRadius)
         );

         Vector3 spawnPos = spawnPoint.position + randomOffset;

         // 버블 생성
         Instantiate(bubblePrefab, spawnPos, spawnPoint.rotation, SpawnPosition);
      }
   }
   
   
}
   
   
