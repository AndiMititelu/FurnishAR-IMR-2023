using UnityEngine;

public class ArManagerEditor : ArManagerBase
{
    protected override void SpawnObject()
    {
        if (!InputManager.HasClicked)
        {
            return;
        }
        Ray _ray = mainCamera.ScreenPointToRay(InputManager.InputPosition);

        if (!Physics.Raycast(_ray, out var _hit) || _hit.collider.gameObject.layer != LayerMask.NameToLayer(FLOOR_LAYER))
        {
            return;
        }
        GameObject _currentObject = Instantiate(CatalogPanel.SelectedObject._arObject.Prefab, _hit.point, Quaternion.identity);
        currentState = ArState.WatchingObject;
        objectHandler.Setup(_currentObject,mainCamera);
        objectHandler.SetMaterial(CatalogPanel.SelectedObject._variant);
        ArUI.Instance.ShowObjectDetails(CatalogPanel.SelectedObject._arObject,CatalogPanel.SelectedObject._variant);
    }
}
