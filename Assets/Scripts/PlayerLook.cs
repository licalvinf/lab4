using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    [SerializeField] private float sensX = 100f;
    [SerializeField] private float sensY = 100f;
    Camera cam;

    float mouseX;
    float mouseY;
    float multiplier = 0.01f;

    float xRotation;
    float yRotation;

    private void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        UserInput();
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation,0);
    }
    void UserInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * sensX * multiplier;
        xRotation -= mouseY * sensY * multiplier;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }
}