using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : BasePanel
{
    [SerializeField] private Button play;
    [SerializeField] private Button info;

    private void OnEnable()
    {
        play.onClick.AddListener(ShowCatalog);
        info.onClick.AddListener(ShowInfo);
    }

    private void OnDisable()
    {
        play.onClick.RemoveListener(ShowCatalog);
        info.onClick.RemoveListener(ShowInfo);
    }

    private void ShowCatalog()
    {
        MainMenuUI.Instance.ShowCatalog();
    }

    private void ShowInfo()
    {
        DialogsManager.Instance.ShowOkDialog("This feature is not implemented yet");
    }
}
