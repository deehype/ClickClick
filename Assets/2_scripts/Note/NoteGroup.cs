using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject notePrefeb;
    [SerializeField] private GameObject noteSpawn;
    [SerializeField] private float noteGap =6f;

    [SerializeField] private SpriteRenderer btnSpriteRenderer;
    [SerializeField] private Sprite normalBtnSprite;
    [SerializeField] private Sprite selectBtnsprite;
    [SerializeField] private Animation anim;
    [SerializeField] private KeyCode keyCode;

    public KeyCode KeyCode
    {
        get
        {
            return keyCode;
        }
    }
    
    private List<Note> noteList = new List<Note>();
    void Start()
    {
        for (int i = 0; i < noteMaxNum; i++)
        {
            CreateNote(true);
        }
    }

    private void CreateNote(bool isApple)
    {
        GameObject noteGameObj = Instantiate(notePrefeb);
        noteGameObj.transform.SetParent(noteSpawn.transform);
        noteGameObj.transform.localPosition = Vector3.up * this.noteList.Count * noteGap;
        Note note = noteGameObj.GetComponent<Note>();
        note.SetSprite(isApple);

        noteList.Add(note);
    }

    void Update()
    {

        
    }

    public void OnInput(bool isApple)
    {
        if (noteList.Count ==0 )
            return;

        //노트 삭제
        Note delNote = noteList[0];
        delNote.DeleteNote();
        noteList.RemoveAt(0);

        //정렬
        for (int i = 0; i < noteList.Count; i++)
            noteList[i].transform.localPosition = Vector3.up * i * noteGap;

        //생성
        CreateNote(isApple);

        //노트 애니메이션
        anim.Play();
        btnSpriteRenderer.sprite = selectBtnsprite;
    }

    public void callAniDone()
    {
        btnSpriteRenderer.sprite = normalBtnSprite;
    }
}
