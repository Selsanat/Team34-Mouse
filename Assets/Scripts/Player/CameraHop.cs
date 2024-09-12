using DG.Tweening;
using NaughtyAttributes.Test;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHop : MonoBehaviour
{
    Vector3 velocity;
    Transform playerCamera;
    Vector3 initialCameraPos;
    float sprinting;
    float time = 0;
    float offset = 0;
    [SerializeField] float hopHeight = 1f;
    [SerializeField] float hopSpeed = 1f;
    [SerializeField] float sprintModifier = 2f;
    private void Start()
    {
        playerCamera = this.GetComponentInChildren<Camera>().transform;
        initialCameraPos = playerCamera.localPosition;
        GameManager.instance.hitTrap.AddListener(() =>
        {
            this.GetComponentInChildren<Camera>().DOShakeRotation(0.5f, 30);
        });
        GameManager.instance.fellDown.AddListener(() =>
        {
            this.GetComponentInChildren<Camera>().DOShakeRotation(0.5f, 30);
        });

    }
    public void ReceiveVelocity(Vector3 _velocity, float _sprinting)
    {
        velocity = _velocity;
        sprinting = _sprinting;
    }

    private void Update()
    {
        float velocityY = Mathf.Clamp(velocity.y, 0, velocity.y);

        Vector3 pos = playerCamera.localPosition;
        if (velocityY > 0)
        {
            time += Time.deltaTime * hopSpeed * (sprinting>0? velocityY * 2:velocityY);
            playerCamera.localPosition = new Vector3(pos.x, pos.y + Mathf.Sin(time) * Time.deltaTime * hopHeight, pos.z);
        }
    }
}
