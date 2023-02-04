using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMovement : MonoBehaviour
{
    public Sprite[] animationSprites;
    private SpriteRenderer spriteRenderer;


    public Sprite idle;
    //private int currentSprite = 0;
    private float animationTime=0.25f;
    private float animationFrames;

    public bool isIdle = true;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //get reference to the sprite renderer component
    }

    private void OnEnable() {

        spriteRenderer.enabled = true;

    }

    private void OnDisable() {
        spriteRenderer.enabled = false;
        
    }
    private void Start()
    {
        InvokeRepeating(nameof(UpdateNextSprite), 0, animationTime);

    }

    //update the sprite renderer with the next sprite in the array
    void NextFrame()
    {
        animationFrames ++;
        if (animationFrames >= animationSprites.Length)
        {
            animationFrames = 0;
        }
        if (isIdle)
        {
            spriteRenderer.sprite = idle;
        }
        else
        {
            spriteRenderer.sprite = animationSprites[animationFrames];
        }
    }

    
    
}
