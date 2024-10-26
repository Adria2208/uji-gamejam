using Unity.VisualScripting;
using UnityEngine;


public class HouseHealth : MonoBehaviour
{
    public int live = 100;
    public Sprite completedSprite;
    public bool complet = false;
    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        
            if (collision.CompareTag(this.gameObject.tag))
            {
                Debug.Log("Collision");
            if(live <= 0)
            {
                Die();
                transform.parent.GetComponent<HouseList>().housesCompleted ++;
            }
            else
            {
                live --;
            }
            }

        
    }
    private void Die()
    {
        
        this.GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = completedSprite;
    }

}
