using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(HouseSpriteManager))]
public class HouseHealth : MonoBehaviour
{
    public int life = 50;
    public Sprite completedSprite;
    public bool complete = false;

    private HouseSpriteManager houseSpriteManager;

    [SerializeField] private FlashAnimation flashAnimation;

    private void Start()
    {
        houseSpriteManager = GetComponent<HouseSpriteManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag(this.gameObject.tag) && collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            if (life <= 0)
            {
                Die();
                transform.parent.GetComponent<HouseList>().housesCompleted++;
            }
            else
            {
                SoundManager.PlaySound(SoundType.HIT, 0, false, (float).2);
                flashAnimation.StartFlashOnceAnimation(Color.yellow);
                life--;
            }
        }
        else if ((collision.CompareTag("Treat") || collision.CompareTag("Trick")) && collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            SoundManager.PlaySound(SoundType.HIT, 1, false, (float).5);
        }

    }
    private void Die()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        houseSpriteManager.ChangeSprite();
        SoundManager.PlaySound(SoundType.DEATH, 3, false, 3);
        GameManager.Instance.AddCandy(50);
    }

}
