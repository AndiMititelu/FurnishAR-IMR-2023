using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatalogPanel : BasePanel
{
    [SerializeField] private ResizableButton optionPrefab;
    [SerializeField] private Transform optionsHolder;
    [SerializeField] private FurnitureDisplay furniturePrefab;
    [SerializeField] private Transform furnitureHolder;
    [SerializeField] private Button close;
    
    private bool isInit;
    private FurnitureType currentType = FurnitureType.Bed;
    private List<GameObject> furnitures = new();
    private Dictionary<FurnitureType, Button> options = new ();

    public static (ArObject _arObject, FurnitureVariant _variant ) SelectedObject;

    private void OnEnable()
    {
        close.onClick.AddListener(ShowMainMenu);
        ResizableButton.OnClicked += ShowFurniture;
        FurnitureDisplay.OnSelected += ShowArObject;
    }

    private void OnDisable()
    {
        close.onClick.RemoveListener(ShowMainMenu);
        ResizableButton.OnClicked -= ShowFurniture;
        FurnitureDisplay.OnSelected -= ShowArObject;
    }

    private void ShowFurniture(string _furniture)
    {
        FurnitureType _type = Enum.Parse<FurnitureType>(_furniture);
        ShowFurniture(_type);
    }
    
    private void ShowArObject(ArObject _arObject, FurnitureVariant _furniture)
    {
        SelectedObject = new ValueTuple<ArObject, FurnitureVariant>(_arObject,_furniture);
        MainMenuUI.Instance.ShowFurniture();
    }

    private void ShowMainMenu()
    {
        MainMenuUI.Instance.ShowMainMenu();
    }

    protected override void OnSetup()
    {
        if (!isInit)
        {
            isInit = true;
            CreateOptions();
            ShowFurniture(0);
        }
        
        void CreateOptions()
        {
            string[] _options = Enum.GetNames(typeof(FurnitureType));
            AddEmptyObject();
            foreach (var _option in _options)
            {
                ResizableButton _optionDisplay = Instantiate(optionPrefab, optionsHolder);
                _optionDisplay.Setup(_option,true);
                options.Add(Enum.Parse<FurnitureType>(_option),_optionDisplay.GetComponentInChildren<Button>());
            }
            AddEmptyObject();
            
            void AddEmptyObject()
            {
                GameObject _object = Instantiate(new GameObject(), optionsHolder);
                _object.transform.localScale = Vector3.one / 2;
                _object.AddComponent<Image>().color = Color.clear;
            }
        }
    }

    private void ShowFurniture(FurnitureType _type)
    {
        if (currentType==_type)
        {
            return;   
        }

        currentType = _type;
        ClearFurniture();
        List<ArObject> _furnitureToShow = ArObject.Get(_type);
        foreach (var _furniture in _furnitureToShow)
        {
            FurnitureDisplay _furnitureDisplay = Instantiate(furniturePrefab, furnitureHolder);
            _furnitureDisplay.Setup(_furniture);
            furnitures.Add(_furnitureDisplay.gameObject);
        }

        foreach (var (_furnitureType,_button) in options)
        {
            _button.image.color = _furnitureType!=_type ? Color.white : Color.gray;
        }

        void ClearFurniture()
        {
            foreach (var _furniture in furnitures)
            {
                Destroy(_furniture);
            }
            
            furnitures.Clear();
        }
    }
}
