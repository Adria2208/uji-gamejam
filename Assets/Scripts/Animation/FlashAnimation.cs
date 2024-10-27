using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FlashAnimation : MonoBehaviour
{

    private SpriteRenderer sprite;
    private Color originalColor;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        originalColor = sprite.color;
    }


    public void StartFlashColorAnimation(Color color, float flashFramerate, int iterations = 5)
    {
        StartCoroutine(PlayFlashAnimation(color, flashFramerate, iterations));
    }

    public void StartFlashOnceAnimation(Color color)
    {
        StartCoroutine(FlashOnce(color));
    }

    private IEnumerator PlayFlashAnimation(Color color, float flashFramerate, int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            sprite.color = color;
            yield return new WaitForSecondsRealtime(flashFramerate);
            sprite.color = originalColor;
            yield return new WaitForSecondsRealtime(flashFramerate);
        }
    }

    private IEnumerator FlashOnce(Color color)
    {
        sprite.color = color;
        yield return new WaitForSeconds((float).02);
        sprite.color = originalColor;
    }
}
