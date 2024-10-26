using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class House : MonoBehaviour
{
    [SerializeField] private Sprite paperHouse;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            UIManager.Instance.SetInteractTextVisible();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            UIManager.Instance.SetInteractTextInvisible();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (Input.GetButtonDown("Interact"))
            {
                GameManager.Instance.HouseInteracted(this);
            }
        }
    }

    public void Interact()
    {
        spriteRenderer.sprite = paperHouse;
        Debug.Log("Interacted.");
    }


}
