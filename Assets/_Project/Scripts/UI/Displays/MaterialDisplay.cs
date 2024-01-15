using System;
using UnityEngine;
using UnityEngine.UI;

public class MaterialDisplay : MonoBehaviour
{
    public Action<FurnitureMaterial> OnSelected;

    [SerializeField] private Image image;
    [SerializeField] private Button button;
    
    private FurnitureMaterial material;
    
    public void Setup(FurnitureMaterial _material)
    {
        material = _material;
        image.sprite = material.Preview;
        if (_material.Material == null)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        button.onClick.AddListener(ChangeMaterial);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(ChangeMaterial);
    }

    private void ChangeMaterial()
    {
        OnSelected?.Invoke(material);
    }
}
