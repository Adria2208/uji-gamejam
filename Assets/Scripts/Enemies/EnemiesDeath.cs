using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDeath : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public int life = 25;

    [SerializeField] private FlashAnimation flashAnimation;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (life <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            if (collision.CompareTag(this.gameObject.tag))
            {
                SoundManager.PlaySound(SoundType.HIT, 0, false, (float).5);
                if (gameObject.CompareTag("Trick"))
                {
                    flashAnimation.StartFlashOnceAnimation(Color.red);
                }
                else
                {
                    flashAnimation.StartFlashOnceAnimation(Color.yellow);
                }
                life--;
            }
            else
            {
                SoundManager.PlaySound(SoundType.HIT, 1, false);

            }
        }
    }

    private void Die()
    {
        SoundManager.PlaySound(SoundType.DEATH, 0, false);
        Destroy(gameObject);
        GameManager.Instance.AddCandy(5);
    }

}
