using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class Replay : MonoBehaviour
{
    public TMP_Text min;
    public TMP_Text max;
    public void ReplayGame()
    {
        
    }

    void Start()
    {
        min.text = "Score : " + DonDestory.Instance.score;
        max.text = "MaxScore : " + DonDestory.Instance.maxScore;
        //Debug.Log($"myTime " + GameManager.myTime);
        //Debug.Log($"minTime " + GameManager.minTime);

        //Debug.Log($"GameOver : {GameManager.Instance.IsGameOver()},GameClear: {GameManager.Instance.IsGameClear()}");
    }

    void Update()
    {
        
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("Main");
    }
}
