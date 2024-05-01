using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore = 100;
    [SerializeField] private int noteGroupCreateScore = 10;
    private bool isGameClear = false;
    private bool isGameOver = false;
    private int nextNoteGroupUnlockCnt;

    [SerializeField] private float maxTime = 30f;
    public float myTime;
    public float minTime;
    


    public bool IsGameDone
    {
        get
        {
            if (isGameClear || isGameOver)
            {
                minTime = PlayerPrefs.GetFloat("minTime", 1000f);
                if (minTime > minTime)
                {
                    minTime = myTime;
                }
                SceneManager.LoadScene("Main");
                return true;
            }
            else
                return false;
        }
    }

    private void Awake()
    {
        Instance = this;
        minTime = maxScore;
    }

    private void Start()
    {
        UIManager.Instance.OnScoreChange(Score.score, maxScore);
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
                SceneManager.LoadScene("Close");
                yield break;
            }
        }

        isGameOver = true;
        
        SceneManager.LoadScene("Close");
        Debug.Log("Game Over");
    }

    public void CalculateScore(bool isApple)
    {
        if(isApple)
        {
            Score.score++;    
            nextNoteGroupUnlockCnt++;

            if(noteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.Instance.CreateNoteGroup();  
            }

            if (maxScore <= Score.score)
            {
                if (Score.score > Score.bestscore)
                {
                    Score.bestscore = Score.score;
                }
                isGameClear = true;
                Debug.Log("Game Clear!..");
                SceneManager.LoadScene("Close");
            }

        } else
        {
            Score.score--;
        }
        UIManager.Instance.OnScoreChange(Score.score, maxScore);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
}
