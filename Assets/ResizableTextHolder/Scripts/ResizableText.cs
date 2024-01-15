using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResizableText : MonoBehaviour
{
    [SerializeField] private string startingText;
    [SerializeField] private TextMeshProUGUI backgroundText;
    [SerializeField] private TextMeshProUGUI foregroundText;

    protected string Text;

    private void OnValidate()
    {
        SetStartingText();
    }

    private void Start()
    {
        SetStartingText(true);
    }

    private void SetStartingText(bool _rebuildLayoutGroups=false)
    {
        if (string.IsNullOrEmpty(startingText))
        {
            return;
        }
        
        Setup(startingText,_rebuildLayoutGroups);
    }

    public void Setup(string _text, bool _rebuildLayoutGroups=false)
    {
        Text = _text;
        backgroundText.text = Text;
        foregroundText.text = Text;
        if (_rebuildLayoutGroups)
        {
            RebuildLayoutGroups();
        }
    }

    private void RebuildLayoutGroups()
    {
        LayoutGroup[] _layoutGroups = GetComponentsInParent<LayoutGroup>();
        foreach (var _layoutGroup in _layoutGroups)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(_layoutGroup.GetComponent<RectTransform>());
        }
    }
}
