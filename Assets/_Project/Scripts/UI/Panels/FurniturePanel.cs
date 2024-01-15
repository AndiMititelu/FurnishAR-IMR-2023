using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FurniturePanel : BasePanel
{
    [SerializeField] private Button close;
    [SerializeField] private Image preview;
    [SerializeField] private TextMeshProUGUI nameDisplay;
    [SerializeField] private TextMeshProUGUI priceDisplay;
    [SerializeField] private TextMeshProUGUI descriptionDisplay;
    [SerializeField] private Button viewInAr;

    private void OnEnable()
    {
        close.onClick.AddListener(ShowCatalog);    
        viewInAr.onClick.AddListener(ViewInAr);
    }

    private void OnDisable()
    {
        close.onClick.RemoveListener(ShowCatalog);
        viewInAr.onClick.RemoveListener(ViewInAr);
    }

    private void ShowCatalog()
    {
        MainMenuUI.Instance.ShowCatalog();
    }

    private void ViewInAr()
    {
        SceneManager.LoadArScene();
    }

    protected override void OnSetup()
    {
        var _selectedObject = CatalogPanel.SelectedObject;

        preview.sprite = _selectedObject._variant.Preview;
        preview.SetNativeSize();
        nameDisplay.text = _selectedObject._arObject.Name;
        priceDisplay.text = $"{_selectedObject._variant.Price}$";
        descriptionDisplay.text = _selectedObject._arObject.Description;
    }
}
