using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDeath : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public int live = 25;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(live <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            if (collision.CompareTag(this.gameObject.tag))
            {
                // Debug.Log("Collision");
                live --;
            }
        }
    }

    private void Die()
    {
        SoundManager.PlaySound(SoundType.DEATH, 0, false);
        Destroy (gameObject);
    }

}
