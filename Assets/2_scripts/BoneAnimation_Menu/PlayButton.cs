using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        string sceneName = "Main";
        SceneManager.LoadScene("Main");
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
