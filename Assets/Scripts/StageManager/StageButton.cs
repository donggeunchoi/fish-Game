using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    public int stageNumber;

    public void OnClickStage()
    {
        if (StageManager.instance != null)
        {
            StageManager.instance.OnClickInGame(stageNumber);
        }
    }
}
