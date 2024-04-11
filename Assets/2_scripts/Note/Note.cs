using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite appleSprite;
    [SerializeField] Sprite blueberrySprite;

    private bool isApple;

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void CalScoreAndDeleteNote()
    {
        GameManager.Instance.CalculateScore(isApple);
        Destroy();
    }

    public void SetSprite(bool isApple)
    {
        this.isApple = isApple;
        spriteRenderer.sprite = isApple ? appleSprite : blueberrySprite;
    }
}
