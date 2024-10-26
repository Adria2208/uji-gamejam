using System;
using TMPro;
using UnityEngine;

public class InteractText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    public bool isVisible { get; private set; } = false;

    private void Start()
    {
        text.alpha = 0;
    }

    public void SetVisible()
    {
        text.alpha = 255;
        isVisible = true;
    }

    public void SetInvisible()
    {
        text.alpha = 0;
        isVisible = false;
    }
    public void ToggleVisible()
    {
        if (isVisible)
        {
            text.alpha = 0;
            isVisible = false;
        }
        else
        {
            text.alpha = 255;
            isVisible = true;
        }
    }
}
