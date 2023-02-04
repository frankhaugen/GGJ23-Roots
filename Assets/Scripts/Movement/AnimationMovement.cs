using System;
using System.Linq;
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
        if (!animationSprites.Any()) return;

        timer += Time.deltaTime; 
        if (timer >= animationFrames)
        {
            
            try
            {
                currentSprite++; // add 1 to current sprite
                if (currentSprite >= animationSprites.Length)
                {
                    currentSprite = 0;
                }
                
                spriteRenderer.sprite = animationSprites[currentSprite]; //update sprite renderer with new sprite
                
                timer = 0; //reset timer
            }
            catch (Exception e)
            {
                Logger.LogError(e);
            }
        }
    }
}
