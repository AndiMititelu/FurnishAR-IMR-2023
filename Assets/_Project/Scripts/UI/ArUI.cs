using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArUI : MonoBehaviour
{
    public static ArUI Instance;
    [SerializeField] private Button view;
    [SerializeField] private Button rotate;
    [SerializeField] private Button scale;
    [SerializeField] private Button move;

    [SerializeField] private TextMeshProUGUI nameDisplay;
    [SerializeField] private TextMeshProUGUI priceDisplay;
    [SerializeField] private Button buyButton;

    [SerializeField] private MaterialDisplay materialPrefab;
    [SerializeField] private Transform materialsHolder;
    [SerializeField] private Button close;
    [SerializeField] private Button screenshot;

    private ArObject arObject;
    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        view.onClick.AddListener(View);
        rotate.onClick.AddListener(Rotate);
        scale.onClick.AddListener(Scale);
        move.onClick.AddListener(Move);
        buyButton.onClick.AddListener(Buy);
        close.onClick.AddListener(Close);
        screenshot.onClick.AddListener(Screenshot);
    }

    private void OnDisable()
    {
        view.onClick.RemoveListener(View);
        rotate.onClick.RemoveListener(Rotate);
        scale.onClick.RemoveListener(Scale);
        move.onClick.RemoveListener(Move);
        buyButton.onClick.RemoveListener(Buy);
        close.onClick.RemoveListener(Close);
        screenshot.onClick.RemoveListener(Screenshot);
    }

    private void View()
    {
        ArManagerBase.Instance.ChangeState(ArState.WatchingObject);
    }

    private void Rotate()
    {
        ArManagerBase.Instance.ChangeState(ArState.RotatingObject);
    }

    private void Scale()
    {
        ArManagerBase.Instance.ChangeState(ArState.ScalingObject);
    }

    private void Move()
    {
        ArManagerBase.Instance.ChangeState(ArState.Moving);
    }

    private void Buy()
    {
        DialogsManager.Instance.ShowOkDialog("This feature is not implemented yet");
    }

    private void Close()
    {
        SceneManager.LoadMainMenu();
    }
    
    private void Screenshot()
    {
        ArManagerBase.Instance.TakeScreenshot();
    }

    public void ShowObjectDetails(ArObject _arObject, FurnitureVariant _selectedVariant)
    {
        arObject = _arObject;
        nameDisplay.text = arObject.Name;
        
        foreach (var _variant in _arObject.Variants)
        {
            MaterialDisplay _materialDisplay = Instantiate(materialPrefab, materialsHolder);
            _materialDisplay.Setup(_variant.Material);
            _materialDisplay.OnSelected += ChangeVariant;
        }
        
        ChangeVariant(_selectedVariant);
    }
    
    private void ChangeVariant(FurnitureMaterial _material)
    {
        ChangeVariant(arObject.Variants.FirstOrDefault(_element => _element.Material== _material));
    }
    
    private void ChangeVariant(FurnitureVariant _variant)
    {
        priceDisplay.text = $"{_variant.Price}$";
        ArManagerBase.Instance.ChangeMaterial(_variant);
    }
}
