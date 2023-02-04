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
            currentSprite = (currentSprite + 1) % animationSprites.Length; //next sprite in the array 
            spriteRenderer.sprite = animationSprites[currentSprite]; //update sprite renderer with new sprite
            timer = 0; //reset timer
        }
    }
}
