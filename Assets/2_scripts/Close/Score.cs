using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public static int bestscore = 0;
    public TextMeshProUGUI scoreTmp;
    public TextMeshProUGUI bestScoreTmp;

    private void Start()
    {
        scoreTmp.text = "Score : " + score;
        bestScoreTmp.text = "Best Score : " + bestscore;
    }
}
