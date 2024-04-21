using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int index;
    public Mark mark;
    public bool isMarked;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        index = transform.GetSiblingIndex();
        mark = Mark.None;
        isMarked = false;
    }

    public void SetAsMarked(Sprite sprite, Mark mark, Color color){
        isMarked = true;
        this.mark = mark;

        spriteRenderer.color = color;
        spriteRenderer.sprite = sprite;

        // Disable the CircleConllider2D (to avoid marking it twice)
        GetComponent<CircleCollider2D>().enabled = false;
    }
}
