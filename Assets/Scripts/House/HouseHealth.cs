using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(HouseSpriteManager))]
public class HouseHealth : MonoBehaviour
{
    public int life = 100;
    public Sprite completedSprite;
    public bool complete = false;

    private HouseSpriteManager houseSpriteManager;

    private void Start() {
        houseSpriteManager = GetComponent<HouseSpriteManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag(this.gameObject.tag))
        {
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
        houseSpriteManager.ChangeSprite();
    }

}
