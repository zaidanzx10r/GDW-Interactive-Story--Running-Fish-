using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float movementSpeedMultiplier = 2f;
    public float Gravity = -9.81f;

    private CharacterController controller;  
    private Vector2 WASDInput;  
    private bool isSprinting = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        WASDInput = context.ReadValue<Vector2>();
    }
    public void OnSprint(InputAction.CallbackContext context)
    {
        isSprinting = context.ReadValueAsButton();
    }

    private void Update()
    {
            Movement();
    }

    private void Movement()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        forward.y = 0f;
        right.y = 0f;

        Vector3 direction = (forward * WASDInput.y) + (right * WASDInput.x);

        float currentSpeed = isSprinting ? movementSpeed * movementSpeedMultiplier : movementSpeed;
    
        controller.Move((direction * currentSpeed + Vector3.up * Gravity) * Time.deltaTime);
    }
    public float IsWalking()
    {
        return WASDInput.magnitude;
    }
}
