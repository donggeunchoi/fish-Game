using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType{CatchFish, SurviveTime, CollectItem}

[System.Serializable]
public class QuestData
{
    public string description;
    public QuestType type;
    public int targetCount;
}

[CreateAssetMenu(fileName = "QuestSo", menuName = "Game/QuestSo")]
public class QuestSo : ScriptableObject
{
    public QuestData[] quests;
}
