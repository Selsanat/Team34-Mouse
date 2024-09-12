using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls controls; 
    PlayerControls.GroundMovementActions groundMovement;
    MouseLook mouseLook;
    GameManager gameManager;
    CameraHop cameraHop;
    

    Vector2 horizontalInput;
    Vector2 mouseInput;
    float sprintInput;
    Movement movement;
    public void Awake()
    {
        gameManager = GameManager.instance;
        controls = new PlayerControls();
        movement = this.GetComponent<Movement>();
        mouseLook = this.GetComponent<MouseLook>();
        cameraHop = this.GetComponent<CameraHop>();
        groundMovement = controls.GroundMovement;

        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
        groundMovement.PauseGame.performed += ctx => gameManager.gamePaused.Invoke();
        groundMovement.Sprint.performed += ctx => sprintInput = ctx.ReadValue<float>();
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
        Vector3 horizontalVelocity = movement.GetInput(horizontalInput, sprintInput);
        mouseLook.ReceiveInput(mouseInput);
        cameraHop.ReceiveVelocity(horizontalInput, sprintInput);
    }
}
