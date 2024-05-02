using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MinTime : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    private int _myScore = 0;
    private int _bestScore = 100;
    public static MinTime Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int myScore
    {
        get => _myScore;
        set
        {
            _myScore = value;
            if (_myScore > _bestScore)
            {
                _bestScore = value;
                PlayerPrefs.SetInt("bestScore", value);
            }
            printScore();
        }
    }

    private void printScore()
    {
        text.text = $"My Scorev : {_myScore}\nBest Score : {_bestScore}";
    }

    public int bestScore
    {
        get => _bestScore;
    }

    void Start()
    {
        _bestScore = PlayerPrefs.GetInt("bestScore", 200);
        printScore();
        GetComponent<TextMeshProUGUI>().text = "Best Score : " + GameManager.score;
    }
}
