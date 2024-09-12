using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls controls; 
    PlayerControls.GroundMovementActions groundMovement;
    MouseLook mouseLook;
    

    Vector2 horizontalInput;
    Vector2 mouseInput;
    Movement movement;
    public void Awake()
    {
        controls = new PlayerControls();
        movement = this.GetComponent<Movement>();
        mouseLook = this.GetComponent<MouseLook>();
        groundMovement = controls.GroundMovement;

        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        movement.GetInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);
    }
}
