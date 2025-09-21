using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager instance { get; private set; }
    public int SelectedStage { get; private set; }
    [SerializeField] private string GameSceneName = "GameScene";
    [SerializeField] private string stageSelectSceneName = "StageScene";
    
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    public void SelectStage(int stageNum)
    {
        SelectedStage = stageNum;
    }
    public void OnClickInGame(int stageNum)
    {
        SelectStage(stageNum);
        SceneManager.LoadScene(GameSceneName);
    }

    public void LoadStageSelect()
    {
        SceneManager.LoadScene(stageSelectSceneName);
    }
}
