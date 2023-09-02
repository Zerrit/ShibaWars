using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float cameraSpeed = 8f;
    private Vector3 startPosition;
    private float targetPosition;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) startPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0))
        {
            float pos = cam.ScreenToWorldPoint(Input.mousePosition).x - startPosition.x;
            targetPosition = Mathf.Clamp(transform.position.x - pos, 28f, 170f);
        }

        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPosition, cameraSpeed * Time.deltaTime), transform.position.y, transform.position.z);
    }
}
