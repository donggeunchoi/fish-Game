using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stage_Config", menuName = "Game/Stage Config")]
public class StageConfig : ScriptableObject
{
    [Serializable]
    public class FishRule
    {
        public GameObject fish;
        [Min(0)] public int minCount = 1;
        [Min(0)] public int maxCount = 3; // 실제 스폰은 [min, max] 랜덤
    }

    [Header("Stage")]
    public int stageNumber = 1;

    [Header("Fish Rules")]
    public List<FishRule> fishRules = new();
}