using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public static MainMenuUI Instance;
    [SerializeField] private MainMenuPanel mainMenu;
    [SerializeField] private CatalogPanel catalog;
    [SerializeField] private FurniturePanel furniture;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        ShowPanel(mainMenu);
    }

    public void ShowCatalog()
    {
        ShowPanel(catalog);
    }

    public void ShowFurniture()
    {
        ShowPanel(furniture);
    }

    private void ShowPanel(BasePanel _panel)
    {
        mainMenu.Close();
        catalog.Close();
        furniture.Close();
        
        _panel.Setup();
    }
}
