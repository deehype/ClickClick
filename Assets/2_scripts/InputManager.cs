using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            NoteManager.Instance.OnInput(KeyCode.A);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            NoteManager.Instance.OnInput(KeyCode.S);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            NoteManager.Instance.OnInput(KeyCode.D);
        }
    }
}
