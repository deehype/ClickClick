using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;

    [SerializeField] private GameObject noteGroupPrefeb;
    [SerializeField] private float noteGroupGap = 1f;
    [SerializeField]
    private KeyCode[] wholeKeyCodesArr = new KeyCode[]
    {
        KeyCode.A,KeyCode.S, KeyCode.D,KeyCode.F,
        KeyCode.G,KeyCode.H, KeyCode.J,KeyCode.K, KeyCode.L
    };
    [SerializeField] private int initNoteGroupNum = 2;
    private List<NoteGroup> noteGroupList = new List<NoteGroup>();

    public void Create()
    {
        for (int i = 0; i < initNoteGroupNum; i++)
        {
            CreateNoteGroup(wholeKeyCodesArr[i]);
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    public void CreateNoteGroup()
    {
        int noteGroupCount = noteGroupList.Count;
        KeyCode keyCode = this.wholeKeyCodesArr[noteGroupCount];
        CreateNoteGroup(keyCode);
    }

    private void CreateNoteGroup(KeyCode keycode)
    {
        GameObject noteGroupObj = Instantiate(noteGroupPrefeb);
        noteGroupObj.transform.position = Vector3.right * noteGroupList.Count * noteGroupGap;

        NoteGroup noteGroup = noteGroupObj.GetComponent<NoteGroup>();
        noteGroup.Create(keycode);

        noteGroupList.Add(noteGroup);
    }

    public void OnInput(KeyCode keyCode)
    {
        int randId = Random.Range(0, 2);
        bool isApple = randId == 0 ? true : false;

        foreach (NoteGroup noteGroup in noteGroupList)
        {
            if (keyCode == noteGroup.KeyCode)
            {
                noteGroup.OnInput(isApple);
                break;
            }
        }
        Debug.Log("Keycode = " + keyCode);
    }
}
