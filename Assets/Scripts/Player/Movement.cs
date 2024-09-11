using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 horizontalInput;
    [SerializeField] float speed = 5f;
    [SerializeField] CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void GetInput(Vector2 _input)
    {
        horizontalInput = _input;
    }

    private void Update()
    {
        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) *speed;
        controller.Move(horizontalVelocity * Time.deltaTime);
    }
}
