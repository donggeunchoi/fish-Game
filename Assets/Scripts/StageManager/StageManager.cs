using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager instance { get; private set; }
    public int SelectedStage { get; private set; } = 1;
    [SerializeField] private string GameSceneName = "GameScene";
    [SerializeField] private string stageSelectSceneName = "StageScene";
  
    const string KeySelectedStage = "SelectedStage";
    const string KeyUnlockedMask =  "UnlockedMask";

    public int unlockedMask;
    
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        if (PlayerPrefs.HasKey("SelectedStage"))
        {
            SelectedStage = PlayerPrefs.GetInt("SelectedStage",1);
        }
    }

    public void SelectStage(int stageNum)
    {
        SelectedStage = stageNum;
        PlayerPrefs.SetInt("SelectedStage", stageNum);
    }
    public void OnClickInGame(int stageNum)
    {
        SelectStage(stageNum);
        SceneManager.LoadScene(GameSceneName);
    }
}
