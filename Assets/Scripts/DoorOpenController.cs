using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorOpenController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Text _text;
    [SerializeField] private ParticleSystem _particle;

    private void Update()
    {
        DetectObjTouch();
    }

    private void DetectObjTouch()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit hit;

                Ray ray = _camera.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hit, 300))
                {
                    if (hit.transform.tag == "Door")
                    {
                        hit.transform.GetComponent<Animator>().SetTrigger("DoorOpen");
                        _text.text = hit.transform.name;
                    }
                    else
                    {
                        _text.text = hit.transform.name;
                    }
                }
            }

        }
    }

    private void DetectObjMouse()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 10000f))
            {
                if (hit.transform.tag == "Door")
                {
                    hit.transform.GetComponent<Animator>().SetTrigger("DoorOpen");
                }                
            }

            Debug.DrawRay(ray.origin, ray.direction, Color.red, 1000);
        }

        
    }
}
