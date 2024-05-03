using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageAnim : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Walk()
    {
        anim.CrossFade("Walk", 0, 0);
        Invoke("SetIdle", 2f);
    }

    public void Attack()
    {
        anim.CrossFade("Attack", 0, 0);
        Invoke("SetIdle", 2f);
    }

    private void SetIdle()
    {
        anim.CrossFade("Idle", 0, 0);
    }
}