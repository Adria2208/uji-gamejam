using Unity.VisualScripting;
using UnityEngine;


public class HouseHealth : MonoBehaviour
{
    public int life = 100;
    public Sprite completedSprite;
    public bool complete = false;

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag(this.gameObject.tag))
        {
            Debug.Log("Collision");
            if (life <= 0)
            {
                Die();
                transform.parent.GetComponent<HouseList>().housesCompleted++;
            }
            else
            {
                life--;
            }
        }


    }
    private void Die()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = completedSprite;
    }

}
