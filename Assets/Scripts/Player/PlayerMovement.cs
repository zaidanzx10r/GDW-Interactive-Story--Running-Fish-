using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;

    private CharacterController controller;  
    private Vector2 WASDInput;  
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        WASDInput = context.ReadValue<Vector2>();
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

        controller.Move(direction * movementSpeed * Time.deltaTime);
    }
}
