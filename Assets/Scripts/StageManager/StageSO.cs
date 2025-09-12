using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "Game/StageData")]
public class StageSO : ScriptableObject
{
    public List<StageConfig> stage = new();

    public StageConfig GetByNumber(int stageNum)
    {
        return stage.Find(s => s.stageNumber == stageNum);
    }
}
