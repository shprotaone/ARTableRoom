using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnPlane : MonoBehaviour
{
    private ARRaycastManager _arRayscastManager;

    private Vector2 _touchPosition;

    public GameObject scenePrefab;

    private static List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private void Awake()
    {
        _arRayscastManager = GetComponent<ARRaycastManager>();
        scenePrefab.SetActive(false);
    }

    private void Update()
    {
        if(Input.touchCount > 0 && !scenePrefab.activeInHierarchy)
        {
            _touchPosition = Input.GetTouch(0).position;

            if (_arRayscastManager.Raycast(_touchPosition, _hits, TrackableType.PlaneWithinPolygon) )
            {
                Pose hitPose = _hits[0].pose;

                scenePrefab.SetActive(true);
                scenePrefab.transform.position = hitPose.position;
                LookAtPlayer(scenePrefab.transform);        
            }        
        }
    }

    private void LookAtPlayer(Transform scene)
    {
        var lookDirection = Camera.main.transform.position - scene.position;
        lookDirection.y = 0;

        scene.rotation = Quaternion.LookRotation(lookDirection);
    }
}
