using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore = 100;
    private int score;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UIManager.Instance.OnScoreChange(this.score, maxScore);

    }

    public void CalculateScore(bool isApple)
    {
        if(isApple)
        {
            score++;    
        } else
        {
            score--;
        }
        UIManager.Instance.OnScoreChange(score, maxScore);
    }
}
