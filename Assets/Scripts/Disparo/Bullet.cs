using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletspeed = 1f;
    public int bulletTime = 5;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * bulletspeed;
        StartCoroutine(BulletDeath());
    }
    void Die()
    {
        Destroy (gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Die();
        }
        
         if (collision.CompareTag("Wall"))
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
