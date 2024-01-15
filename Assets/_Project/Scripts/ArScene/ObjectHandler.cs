using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    private GameObject currentObject;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float scaleSpeed;

    private float distanceToScreen;
    private Vector3 offset;
    private Camera mainCamera;

    public void Setup(GameObject _objectInstance,Camera _mainCamera)
    {
        mainCamera = _mainCamera;
        currentObject = _objectInstance;

        if (Application.isMobilePlatform)
        {
            rotationSpeed /= 30;
            scaleSpeed /= 30;
        }
    }

    private void Update()
    {
        if (currentObject==null)
        {
            return;
        }

        if (ArManagerBase.Instance.CurrentState == ArState.Moving)
        {
            Move();
        }
    }
    
    private void Move()
    {
        if (InputManager.HasClicked)
        {
            var _currentTransform = currentObject.transform.position;
            distanceToScreen = mainCamera.WorldToScreenPoint(_currentTransform).z;
            offset = _currentTransform - GetMouseWorldPos();
        }

        if (InputManager.IsClicking)
        {
            currentObject.transform.position = GetMouseWorldPos() + offset;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 _mousePoint = InputManager.InputPosition;
        _mousePoint.z = distanceToScreen;
        return mainCamera.ScreenToWorldPoint(_mousePoint);
    }

    private void FixedUpdate()
    {
        switch (ArManagerBase.Instance.CurrentState)
        {
            case ArState.RotatingObject:
                Rotate();
                break;
            case ArState.ScalingObject:
                Scale();
                break;
        }
    }

    private void Rotate()
    {
        if (!InputManager.IsClicking)
        {
            return;
        }
        
        float _rotation = InputManager.HorizontalInput * rotationSpeed * Time.deltaTime;
        currentObject.transform.Rotate(Vector3.up, _rotation);
    }

    private void Scale()
    {
        if (!InputManager.IsClicking)
        {
            return;
        }
        
        float _scale = InputManager.VerticalInput * scaleSpeed * Time.deltaTime;
        currentObject.transform.localScale += new Vector3(_scale, _scale, _scale);
    }

    public void SetMaterial(FurnitureVariant _variant)
    {
        if (_variant.Material.Material == null)
        {
            return;
        }

        MeshRendererProvider _meshProvider = currentObject.GetComponent<MeshRendererProvider>();
        if (_meshProvider==null)
        {
            Debug.Log("Null found");
            return;
        }
        
        foreach (var _meshRenderer in _meshProvider.MeshRenderers)
        {
            _meshRenderer.materials = new []{_variant.Material.Material};
        }
    }
}
