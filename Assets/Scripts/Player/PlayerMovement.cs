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

    public float maxStam = 100f;
    public float stamDrain = 15f;
    public float stamRegen = 10f;
    public float currentStam;

    public Transform StaminaBar;
    private Vector3 OGScale;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        currentStam = maxStam;
    }
    public void Start()
    {
        OGScale = StaminaBar.localScale;
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
            Stamina();
            Movement();

            float scaleConversion = ((currentStam / 100) * 1.5f);
            StaminaBar.localScale = new Vector3(scaleConversion, OGScale.y, OGScale.z);
    }

    private void Movement()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        forward.y = 0f;
        right.y = 0f;

        Vector3 direction = (forward * WASDInput.y) + (right * WASDInput.x);

        bool canSprint = isSprinting && currentStam > 0;
        float currentSpeed = canSprint ? movementSpeed * movementSpeedMultiplier : movementSpeed;
    
        controller.Move((direction * currentSpeed + Vector3.up * Gravity) * Time.deltaTime);
    }
    private void Stamina()
    {
        if (isSprinting && WASDInput.magnitude > 0f)
        {
            currentStam -= stamDrain * Time.deltaTime;
            if (currentStam < 0f)
            {
                currentStam = 0f;
            }
        }
        else 
        {
            currentStam += stamRegen * Time.deltaTime;
            if (currentStam > maxStam)
            {
                currentStam = maxStam;
            }
        }
    }
    public float IsWalking()
    {
        return WASDInput.magnitude;
    }
}
