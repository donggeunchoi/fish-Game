using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Stage Data")] [SerializeField]
    private StageSO stageDB; // StageSO: 스테이지 모음(SO)

    [SerializeField] private int currentStage; // 시작 시 StageManager에서 가져옴

    [Header("Spawn")] [SerializeField] private BoxCollider2D spawnArea; // 스폰 범위(SpawnArea 오브젝트의 BoxCollider2D)
    [SerializeField] private Transform container; // 생성된 물고기 부모(비우면 자동 생성)

    void Awake()
    {
        // 선택된 스테이지 번호 가져오기 (없으면 PlayerPrefs, 최종 폴백 0)
        currentStage = StageManager.instance
            ? StageManager.instance.SelectedStage
            : PlayerPrefs.GetInt("SelectedStage", 0);

        if (container == null)
        {
            var go = new GameObject("FishContainer");
            container = go.transform;
        }
    }

    void Start()
    {
        SpawnStage(currentStage);
    }

    // --------------------------------------------------------------------
    // 스테이지 규칙대로 물고기 스폰
    // --------------------------------------------------------------------
    public void SpawnStage(int stageNumber)
    {
        if (stageDB == null)
        {
            Debug.LogError("[GameManager] StageSO(stageDB)가 비어있습니다.");
            return;
        }

        StageConfig cfg = stageDB.GetByNumber(stageNumber);
        if (cfg == null)
        {
            Debug.LogError($"[GameManager] Stage {stageNumber} 설정을 찾지 못했습니다.");
            return;
        }

        foreach (var rule in cfg.fishRules)
        {
            if (rule == null || rule.fish == null || rule.maxCount < 1) continue;

            int count = Random.Range(rule.minCount, rule.maxCount + 1);

            for (int i = 0; i < count; i++)
            {
                Vector2 spawnPoint = RandomPointInArea();
                
                GameObject fish = Instantiate(rule.fish, spawnPoint, Quaternion.identity);
                
            }
        }
    }


    // 스폰 영역 안의 랜덤 좌표 반환
    Vector2 RandomPointInArea()
    {
        if (spawnArea == null)
        {
            // 영역이 없으면 GameManager 주변 원형 범위로 폴백
            return (Vector2)transform.position + Random.insideUnitCircle * 2f;
        }
    
        Bounds b = spawnArea.bounds;
        float x = Random.Range(b.min.x, b.max.x);
        float y = Random.Range(b.min.y, b.max.y);
        return new Vector2(x, y);
    }
    
    // (디버그) 에디터에서 스폰 영역 보이기
    void OnDrawGizmosSelected()
    {
        if (!spawnArea) return;
        Gizmos.color = new Color(0f, 1f, 1f, 0.6f);
        Gizmos.DrawWireCube(spawnArea.bounds.center, spawnArea.bounds.size);
    }
}
