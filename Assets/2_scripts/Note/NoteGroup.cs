using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject notePrefeb;
    [SerializeField] private GameObject noteSpawn;
    [SerializeField] private float noteGap =6f;

    private List<Note> noteList = new List<Note>();
    void Start()
    {
        for (int i = 0; i < noteMaxNum; i++)
        {
            GameObject noteGameObj = Instantiate(notePrefeb);
            noteGameObj.transform.SetParent(noteSpawn.transform);
            noteGameObj.transform.localPosition = Vector3.up * this.noteList.Count * noteGap;
            Debug.Log("noteGameObj.transform.position : " + noteGameObj.transform.position);

            Note note = noteGameObj.GetComponent<Note>();

            noteList.Add(note);
        }

    }

    void Update()
    {
        
    }
}
