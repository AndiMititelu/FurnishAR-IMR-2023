using System;
using UnityEngine;

public class ArManagerBase : MonoBehaviour
{
    protected const string FLOOR_LAYER = "Floor";
    public static ArManagerBase Instance { get; private set; }
    
    
    [SerializeField] protected ObjectHandler objectHandler;
    
    protected ArState currentState = ArState.PlacingObject;
    protected Camera mainCamera;

    public ArState CurrentState => currentState;

    private void Awake()
    {
        Instance = this;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (currentState == ArState.PlacingObject)
        {
            SpawnObject();
        }
    }

    protected  virtual void SpawnObject()
    {
        
    }

    public void ChangeState(ArState _newState)
    {
        if (CurrentState == ArState.PlacingObject)
        {
            return;
        }

        currentState = _newState;
    }

    public void ChangeMaterial(FurnitureVariant _variant)
    {
        objectHandler.SetMaterial(_variant);
    }

    public void TakeScreenshot()
    {
        var _selectedObject = CatalogPanel.SelectedObject;
        string _date = $"{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}";
        string _fileName = $"{_selectedObject._arObject.Name}_{_date}.png";
        ScreenCapture.CaptureScreenshot(_fileName);
        DialogsManager.Instance.ShowOkDialog("Saved!");
    }
}
