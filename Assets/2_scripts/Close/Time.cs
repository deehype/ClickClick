using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TimeScore : MonoBehaviour
{
    public static int time = 0;
    public static int MinTime = 0;
    TextMeshPro uiText;

    void Start()
    {
        uiText = GetComponent<TextMeshPro>();
        time = 0;
    }

    void Update()
    {
        uiText.text = time.ToString();
    }
}
