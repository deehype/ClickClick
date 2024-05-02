using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore = 100;
    [SerializeField] private int noteGroupCreateScore = 10;
    public static int score;
    private int nextNoteGroupUnlockCnt;
    private bool isGameClear = false;
    private bool isGameOver = false;

    [SerializeField] private float maxTime = 30f;
    private float currentTime;

    public bool IsGameClear()
    {
        return isGameClear;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public bool IsGameDone
    {
        get
        {
            if (isGameClear)
            {
                SceneManager.LoadScene("Clear");
                return true;
            }else if (isGameOver)
            {
                SceneManager.LoadScene("Over");
                return true;
            }
            else
                return false;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        score = 0;
        DonDestory.Instance.score = score;
        UIManager.Instance.OnScoreChange(score, maxScore);
        NoteManager.Instance.Create();

        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        float currentTime = 0f;

        while (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            UIManager.Instance.OnTimerChange(currentTime, maxTime);
            yield return null;

            if (IsGameDone)
            {
                yield break;
            }
        }

        isGameOver = true;
        SceneManager.LoadScene("Over");
    }

    public void CalculateScore(bool isApple)
    {
        if (isApple)
        {
            score++;
            nextNoteGroupUnlockCnt++;
            DonDestory.Instance.score = score;
            if(DonDestory.Instance.score >= DonDestory.Instance.maxScore)
            {
                DonDestory.Instance.maxScore = DonDestory.Instance.score;
            }
            if (noteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }

            if (maxScore <= score)
            {
                maxScore = score;
                isGameClear = true;
                Debug.Log("Game Clear!..");
            }

        }
        else
        {
            score--;
            DonDestory.Instance.score = score;
            if (DonDestory.Instance.score >= DonDestory.Instance.maxScore)
            {
                DonDestory.Instance.maxScore = DonDestory.Instance.score;
            }
        }
        Debug.Log("Score " + score);
        UIManager.Instance.OnScoreChange(score, maxScore);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
}
