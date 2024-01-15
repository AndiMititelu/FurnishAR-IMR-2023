using System;
using UnityEngine;
using UnityEngine.UI;

public class ResizableButton : ResizableText
{
    public static Action<string> OnClicked;
    
    [SerializeField] private Button button;

    private void OnEnable()
    {
        button.onClick.AddListener(Clicked);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(Clicked);
    }

    private void Clicked()
    {
        OnClicked?.Invoke(Text);
    }
}
