using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public bool canHarm = true;
    private Rigidbody2D rb;
    public int time;
    private Vector2 velocity;

    //Knockback
    public PlayerMovement force;
    public float knockBackForce = 10;
    public float knockBackForceUp = 2;
    public float KBCounter;
    public float KBTotalTime;

    public bool knockFromRight;

    [SerializeField] private SpriteRenderer playerSprite;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (GameManager.Instance.GetCurrentLives() > 0)
            {
                if (canHarm)
                {
                    Harm();
                }
            }
            else
            {
                Die();
            }
        }
    }


    private void Harm()
    {
        canHarm = false;
        GameManager.Instance.SubtractLife();
        rb.AddForce(Vector2.up * knockBackForceUp, ForceMode2D.Impulse);
        StartCoroutine(DeathHandler());
    }
    private void Die()
    {
        SoundManager.PlaySound(SoundType.DEATH, 2, false);
        Destroy(gameObject);
    }
    IEnumerator DeathHandler()
    {
        SoundManager.PlaySound(SoundType.DEATH, 1, false);
        yield return new WaitForSeconds(time);
        canHarm = true;
    }

    public void StartFlashColorAnimation(Color color, float flashFramerate, int iterations = 5)
    {
        StartCoroutine(PlayRedFlashAnimation(color, flashFramerate, iterations));
    }

    private IEnumerator PlayRedFlashAnimation(Color color, float flashFramerate, int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            playerSprite.color = color;
            yield return new WaitForSecondsRealtime(flashFramerate);
            playerSprite.color = Color.white;
            yield return new WaitForSecondsRealtime(flashFramerate);
        }
    }
}

