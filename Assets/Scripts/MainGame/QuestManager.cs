using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QuestManager : MonoBehaviour
{
    public QuestSo stageQuest;
    private int currentQuest = 0;
    private int currentCount = 0;
    
    public GameObject gameClearPanel;
    
    public TMP_Text missionText;
    
    // Start is called before the first frame update
    void Start()
    {
        ShowQuest();
    }

    public void ProgressQuest()
    {
        currentCount++;

        if (currentCount >= stageQuest.quests[currentQuest].targetCount)
        {
            currentQuest++;
            currentCount = 0;

            if (currentQuest >= stageQuest.quests.Length)
            {
                GameClear();
            }
            else
            {
                ShowQuest();
            }
        }
    }

    void ShowQuest()
    {
        //UI 표출 기능 작성할 예정
    }

    public void GameClear()
    {
        //gameClearPanel.SetActive(true);
    }
}
