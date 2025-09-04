using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollImage : MonoBehaviour
{
    [SerializeField] private RawImage landImage;
    [SerializeField] private float scrollSpeedX = 0.1f;
    // Update is called once per frame
    void Update()
    {
        Rect uvRect = landImage.uvRect;
        uvRect.x += scrollSpeedX * Time.deltaTime;
        landImage.uvRect = uvRect;
    }
}
