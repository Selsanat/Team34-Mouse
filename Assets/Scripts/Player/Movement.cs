using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 horizontalInput;
    GameManager gameManager;
    bool sprinting;
    bool grounded = true;
    [SerializeField] float speed = 5f;
    [SerializeField] float sprintSpeed = 10f;
    [SerializeField] float gravity = 5f;

    CharacterController controller;
    Vector3 horizontalVelocity;
    Vector3 verticalVelocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        gameManager = GameManager.instance;
    }

    public Vector3 GetInput(Vector2 _horizontalInput, float sprint)
    {
        horizontalInput = _horizontalInput;
        sprinting = sprint>0;
        return horizontalVelocity;
    }

    private void Update()
    {
        horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * (sprinting ? sprintSpeed : speed);
        verticalVelocity = Vector3.down * gravity;
        if(controller.enabled) controller.Move((horizontalVelocity + verticalVelocity) * Time.deltaTime);


        if (controller.isGrounded && !grounded)
        {
           gameManager.fellDown.Invoke();
        }
        grounded = controller.isGrounded;
    }

}
