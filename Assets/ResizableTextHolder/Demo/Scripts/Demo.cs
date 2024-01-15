using TMPro;
using UnityEngine;

namespace ResizableTextDemo
{
    public class Demo : MonoBehaviour
    {
        [SerializeField] private ResizableText textDisplay;
        [SerializeField] private TMP_InputField input;

        private void OnEnable()
        {
            input.onValueChanged.AddListener(SetText);
            ResizableButton.OnClicked += ShowSelectedOption;
        }

        private void OnDisable()
        {
            input.onValueChanged.RemoveListener(SetText);
            ResizableButton.OnClicked -= ShowSelectedOption;
        }

        private void SetText(string _text)
        {
            textDisplay.Setup(_text);
        }
        
        private void ShowSelectedOption(string _text)
        {
            Debug.Log("Selected option: "+_text);
        }
    }
}