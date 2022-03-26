using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour
{
    [SerializeField] private InspectorController _inspectorController;
    [SerializeField] private float _waitSeconds = 2;
    private float _timePressed = 0;
    private float _timeLastPress = 0;

    private void Update()
    {
        CheckLongPress();
    }

    private void CheckLongPress()
    {
        if (Input.touchCount > 0)
        {
            
            if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                if(_timePressed > _waitSeconds)
                _inspectorController.Activator(InspectorType.debug);
            }

            if (Input.touches[0].phase == TouchPhase.Began)
            {
                _timeLastPress = Time.time;
            }
            _timePressed = Time.time - _timeLastPress;
        }
    }
}
