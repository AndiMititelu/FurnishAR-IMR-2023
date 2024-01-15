using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ArManager : ArManagerBase
{
    [SerializeField] private ARRaycastManager arRaycastManager;
    
    protected override void SpawnObject()
    {
        if (!InputManager.HasClicked)
        {
            return;
        }
        Vector2 screenPosition = InputManager.InputPosition;
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(screenPosition, hits, TrackableType.PlaneWithinPolygon);

        if (hits.Count == 0)
        {
            return;
        }

        Pose hitPose = hits[0].pose;
        GameObject _currentObject = Instantiate(CatalogPanel.SelectedObject._arObject.Prefab, hitPose.position, hitPose.rotation);
        currentState = ArState.WatchingObject;
        objectHandler.Setup(_currentObject, mainCamera);
        objectHandler.SetMaterial(CatalogPanel.SelectedObject._variant);
        ArUI.Instance.ShowObjectDetails(CatalogPanel.SelectedObject._arObject, CatalogPanel.SelectedObject._variant);
    }
}
