using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMovement : MonoBehaviour
{
    public Sprite[] animationSprites;
    private SpriteRenderer spriteRenderer;
    private int currentSprite = 0;
    private float animationFrames=0.25f;
    private float timer = 0f;  


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //get reference to the sprite renderer component
    }

    // Update is called once per frame
    void Update()
    {
        timer +=Time.deltaTime; 
        if (timer >= animationFrames)
        {
            try
            {
                spriteRenderer.sprite = animationSprites[currentSprite];
                currentSprite++;
                timer = 0f;
            }
            catch (Exception e)
            {
                Logger.LogError(e);
            }
        }
    }
}
