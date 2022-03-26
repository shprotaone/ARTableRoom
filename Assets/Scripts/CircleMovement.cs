using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _speed;

    [SerializeField] private GameObject _center;

    private void Update()
    {       
        transform.RotateAround(_center.transform.position, Vector3.up * _distance, _speed * Time.deltaTime);
    }
}
        