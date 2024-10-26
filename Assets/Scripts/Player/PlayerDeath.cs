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
                    harm();
                }
            }
            else
            {
                Die();
            }
        }
    }


    private void harm()
    {
        canHarm = false;
        GameManager.Instance.SubtractLife();
        rb.AddForce(Vector2.up * knockBackForceUp, ForceMode2D.Impulse);
        StartCoroutine(DeathHandler());
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    IEnumerator DeathHandler()
    {

        yield return new WaitForSeconds(time);
        canHarm = true;
    }
}

