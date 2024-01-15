using UnityEngine;

public static class SceneManager
{
    private const string AR = "ArScene";
    private const string AR_EDITOR = "ArSceneEditor";
    private const string MAIN_MENU = "MainMenu";
    
    public static void LoadArScene()
    {
        LoadScene(Application.isEditor ? AR_EDITOR : AR);
    }

    public static void LoadMainMenu()
    {
        LoadScene(MAIN_MENU);
    }

    private static void LoadScene(string _key)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_key);
    }
}
