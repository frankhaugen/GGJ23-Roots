using UnityEngine;

public class MovementController : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    private Vector2 direction = Vector2.down;
    public float speed = 5f;


    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    public AnimationMovement animationUp;
    public AnimationMovement animationDown;
    public AnimationMovement animationLeft;
    public AnimationMovement animationRight;



    private AnimationMovement activeSprite;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        activeSprite = animationDown;
    }

    private void Update()
    {
        if (Input.GetKey(inputUp))
        {
            SetDirection(Vector2.up, animationUp);
        }
        else if (Input.GetKey(inputDown))
        {
            SetDirection(Vector2.down, animationDown);
        }
        else if (Input.GetKey(inputRight))
        {
            SetDirection(Vector2.right, animationRight);
        }
        else if (Input.GetKey(inputLeft))
        {
            SetDirection(Vector2.left, animationLeft);
        }
        else
        {
            SetDirection(Vector2.zero, activeSprite);
            
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;
        rigidbody.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, AnimationMovement spriteRenderer)
    {
        direction = newDirection;
        
        animationUp.enabled = spriteRenderer == animationUp;
        animationDown.enabled = spriteRenderer == animationDown;
        animationLeft.enabled = spriteRenderer == animationLeft;
        animationRight.enabled = spriteRenderer == animationRight;
        

        activeSprite = spriteRenderer;
        activeSprite.isIdle = direction == Vector2.zero;

    }
}