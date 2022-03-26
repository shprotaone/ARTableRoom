using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class UIController : MonoBehaviour
{
    public Text debugText;

    private ARPlaneManager _aRPlaneManager;
    private ARPointCloudManager _arPointCloudManager;

    [SerializeField] private GameObject _handAnimation;

    private void Start()
    {
        _aRPlaneManager = GetComponent<ARPlaneManager>();
        _arPointCloudManager = GetComponent<ARPointCloudManager>();

        _aRPlaneManager.planesChanged += PlaneController;
    }

    private void PlaneController(ARPlanesChangedEventArgs obj)
    {
        foreach (var item in obj.added)
        {
            _handAnimation.SetActive(false);          
            break;
        }
    }

    public void DisableVizualization(bool value)
    {
        _aRPlaneManager.enabled = value;
        _arPointCloudManager.enabled = value;

        foreach (var plane in _aRPlaneManager.trackables)
            plane.gameObject.SetActive(value);

        foreach (var point in _arPointCloudManager.trackables)
            point.gameObject.SetActive(value);
    }

    private void OnDisable()
    {
        _aRPlaneManager.planesChanged -= PlaneController;
    }

    private void DebugUI(string value)
    {
        debugText.text = "PlaneManager is " + value;
    }
}
