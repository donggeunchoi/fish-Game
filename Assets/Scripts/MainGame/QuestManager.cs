using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QuestManager : MonoBehaviour
{
    public QuestSo stageQuest;
    private int currentQuest = 0;
    public int currentCount;
    
    public GameObject gameClearPanel;
    
    public TMP_Text missionText;
    
    // Start is called before the first frame update
    void Start()
    {
        ShowQuest();
    }

    void Update()
    {
        ShowQuest();
    }

    private void ShowQuest()
    {
        missionText.text = $"{currentCount}/{stageQuest.stageQuests.Count}";
    }
    
    public void GameClear()
    {
        gameClearPanel.SetActive(true);
    }
    
    
}
