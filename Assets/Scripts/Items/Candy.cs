using UnityEngine;

public class Candy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.Instance.AddCandy(1);
            SoundManager.PlaySound(SoundType.JUMP, 1, false, (float).5);
        }
    }
}
