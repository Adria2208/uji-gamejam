using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletspeed = 1f;
    public int bulletTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    // Update is called once per frame

    void Update()
    {
        if (Time.timeScale == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        transform.position += transform.right * Time.deltaTime * bulletspeed;
        StartCoroutine(BulletDeath());
    }
    void Die()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy") || collision.gameObject.layer == LayerMask.NameToLayer("Default") || collision.CompareTag("Wall"))
        {
            Die();
        }
    }

    IEnumerator BulletDeath()
    {
        yield return new WaitForSeconds(bulletTime);
        Die();
    }


}
