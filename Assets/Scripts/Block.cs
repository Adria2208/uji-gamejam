using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Block : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] Sprite usedSprite;
    public Item[] objectList;
    private Queue<Item> objects;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        objects = new Queue<Item>(objectList);
    }

    private void Hit()
    {
        int objectsCount = objects.Count;
        if (objectsCount > 0)
        {
            Item currentItem = objects.Dequeue();
            if (currentItem is Coin)
            {
                Debug.Log("Coin get!");
            }
            else if (currentItem is Mushroom)
            {
                Debug.Log("Mushroom get!");
            }
        }
        if (objectsCount <= 0)
        {
            spriteRenderer.sprite = usedSprite;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (isCollisionFromBottom(collision.GetContact(0)))
            {
                Hit();
            }
        }
    }

    private bool isCollisionFromBottom(ContactPoint2D contact)
    {
        return Vector3.Dot(contact.normal, Vector3.up) > 0.5;
    }
}
