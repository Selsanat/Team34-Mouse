using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class InputManager : MonoBehaviour
{
    PlayerControls controls; 
    PlayerControls.GroundMovementActions groundMovement;
    PlayerControls.ControllerInputActions controllerInput;
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
        controllerInput = controls.ControllerInput;

        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
        groundMovement.PauseGame.performed += ctx => gameManager.gamePaused.Invoke();
        groundMovement.Sprint.performed += ctx => sprintInput = ctx.ReadValue<float>();

        controllerInput.North.performed += ctx => Triangle();
        controllerInput.West.performed += ctx => Circle();
    }

    private void Circle()
    {
        gameManager.resetAlertLevel.Invoke();
    }
    private void Triangle()
    {
        gameManager.Death.Invoke();
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
