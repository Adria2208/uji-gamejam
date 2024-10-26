using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HouseSpriteManager : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite trickSprite;
    [SerializeField] Sprite treatSprite;
    [SerializeField] Sprite completeTrickSprite;
    [SerializeField] Sprite completeTreatSprite;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(gameObject.tag == "Trick"){
            spriteRenderer.sprite = trickSprite;
        } else if (gameObject.tag == "Treat") {
            spriteRenderer.sprite = treatSprite;
        } else {
            Debug.LogWarning("CUIDADO! Hay una casa con un tag incorrecto. (Correctos: Trick, Treat)");
            spriteRenderer.sprite = treatSprite;
        }

    }



}
