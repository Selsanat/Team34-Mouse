using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 horizontalInput;
    GameManager gameManager;
    bool sprinting;
    bool grounded = true;
    float airTime = 0;
    [SerializeField] float speed = 5f;
    [SerializeField] float sprintSpeed = 10f;
    [SerializeField] float gravity = 5f;

    CharacterController controller;
    Vector3 horizontalVelocity;
    Vector3 verticalVelocity;

    private void Start()
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
        horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * (sprinting ? speed : sprintSpeed);
        verticalVelocity = Vector3.down * gravity;
        if(controller.enabled) controller.Move((horizontalVelocity + verticalVelocity) * Time.deltaTime);

        if (!grounded && !gameManager.spawning)
        {
            airTime += Time.deltaTime;
        }
        else { airTime = 0; }
        if (controller.isGrounded && !grounded && airTime>0.25f)
        {
           gameManager.fellDown.Invoke();
        }
        grounded = controller.isGrounded;
    }

}
