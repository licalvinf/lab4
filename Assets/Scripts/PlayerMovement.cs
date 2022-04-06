using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    float drag = 15f;
    public float movemulti = 10f;
    float horizontalMovement;
    float verticalMovement;
    Vector3 moveDirection;

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    { 
        PlayerInput();
        ControlDrag();
    }
    void PlayerInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.AddForce(moveDirection.normalized * moveSpeed * movemulti, ForceMode.Acceleration);
    }
    void ControlDrag()
    {
        rb.drag = drag;
    }



}
