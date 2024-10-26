using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PlayerMovement movement;

    public Sprite idle;
    public Sprite jump;
    public Sprite slide;
    public AnimatedSprite run;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<PlayerMovement>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
        run.enabled = false;
    }

    private void LateUpdate()
    {
        run.enabled = movement.isRunning;

        if (movement.isJumping)
        {
            spriteRenderer.sprite = jump;
            spriteRenderer.flipX = false;
        }
        else if (movement.isSliding)
        {
            spriteRenderer.sprite = slide;
            spriteRenderer.flipX = true;
        }
        else if (!movement.isRunning)
        {
            spriteRenderer.sprite = idle;
        }
        else if (!movement.isSliding)
        {
            spriteRenderer.flipX = false;
        }


    }
}
