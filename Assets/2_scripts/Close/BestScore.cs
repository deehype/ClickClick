using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Best Score : " + Score.bestscore.ToString();
    }
}
