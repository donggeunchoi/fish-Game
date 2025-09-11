using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFishData", menuName = "FishMonster")]
public class FishMonster : ScriptableObject
{
    [Header("기본정보")] 
    public string fishName;
    public Sprite sprite;

    [Header("능력치")] 
    public float moveSpeed;

    [Header("행동 설정")] 
    public bool canSwimLeftRight;
    
}
