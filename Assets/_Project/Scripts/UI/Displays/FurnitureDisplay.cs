using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureDisplay : MonoBehaviour
{
    public static Action<ArObject, FurnitureVariant> OnSelected;
    
    [SerializeField] private new TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Image preview;
    [SerializeField] private MaterialDisplay materialPrefab;
    [SerializeField] private Transform materialHolder;
    [SerializeField] private Button select;

    private ArObject arObject;
    private FurnitureVariant variant;

    private void OnEnable()
    {
        select.onClick.AddListener(Select);
    }

    private void OnDisable()
    {
        select.onClick.RemoveListener(Select);
    }

    private void Select()
    {
        OnSelected?.Invoke(arObject,variant);
    }

    public void Setup(ArObject _arObject)
    {
        arObject = _arObject;
        name.text = arObject.Name;
        description.text = arObject.Description;
        foreach (var _variant in arObject.Variants)
        {
            MaterialDisplay _materialDisplay = Instantiate(materialPrefab, materialHolder);
            _materialDisplay.Setup(_variant.Material);
            _materialDisplay.OnSelected += ChangeVariant;
        }
        ChangeVariant(arObject.Variants[0]);
    }

    private void ChangeVariant(FurnitureMaterial _material)
    {
        ChangeVariant(arObject.Variants.FirstOrDefault(_element => _element.Material== _material));
    }

    private void ChangeVariant(FurnitureVariant _variant)
    {
        variant = _variant;
        price.text = $"{_variant.Price}$";
        preview.sprite = _variant.Preview;
        preview.SetNativeSize();
    }
}
