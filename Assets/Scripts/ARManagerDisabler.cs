using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARManagerDisabler : MonoBehaviour
{
    [SerializeField] private UIController _uiController;

    private void OnEnable()
    {
        _uiController.DisableVizualization(false);
    }
}
