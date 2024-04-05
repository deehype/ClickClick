using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private KeyCode[] initKeyCodeArr;
    [SerializeField] private GameObject noteGroupPrefeb;
    [SerializeField] private float noteGroupGap = 11;

    public static NoteManager Instance;
    private List<NoteGroup> noteGroupList = new List<NoteGroup>();

    private void Awake()
    {
        Instance = this;
    }

    public void Create()
    {
        foreach (KeyCode keycode in initKeyCodeArr)
        {
            CreateNoteGroup(keycode);
        }
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
        int randId = Random.Range(0, noteGroupList.Count);

        bool isApple = randId == 0 ? true : false;

        foreach (NoteGroup noteGroup in noteGroupList)
        {
            if (keyCode == noteGroup.KeyCode)
            {
                noteGroup.OnInput(isApple);
            }
        }
        Debug.Log("Keycode = " + keyCode);
    }
}
