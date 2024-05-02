using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DonDestory : MonoBehaviour
{
    public int score;
    public int maxScore;
    public static DonDestory Instance;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }



}
