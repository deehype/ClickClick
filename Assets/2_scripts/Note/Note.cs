using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite appleSprite;
    [SerializeField] Sprite blueberrySprite;
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void SetSprite(bool isApple)
    {
        spriteRenderer.sprite = isApple ? appleSprite : blueberrySprite;
    }
}
