using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class SmoothSlopeFix : MonoBehaviour
{
    public ActionBasedContinuousMoveProvider moveProvider;
    public float stickToGroundForce = 5f;
    public float slopeRayLength = 1.5f;

    public float maxFallSpeed = -10f;
    public float bigFallThreshold  = -6f;
    public LayerMask groundLayers;

    private CharacterController controller;
    private Vector3 verticalVelocity;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 inputMove = moveProvider.GetLastInputDirection();

        Vector3 slopeMove = ProjectOntoSlope(inputMove);

        controller.Move(slopeMove * moveProvider.moveSpeed * Time.deltaTime);

        HandleGravity();
    }

    Vector3 ProjectOntoSlope(Vector3 move)
    {
        if (Physics.Raycast(transform.position + Vector3.up * 0.2f, Vector3.down,
            out RaycastHit hit, slopeRayLength, groundLayers))
        {
            return Vector3.ProjectOnPlane(move, hit.normal);
        }

        return move;
    }

    void HandleGravity()
{
    bool grounded = controller.isGrounded;

    if (grounded)
    {
        if (verticalVelocity.y < 0f)
            verticalVelocity.y = -stickToGroundForce;
    }
    else
    {
        verticalVelocity.y += Physics.gravity.y * Time.deltaTime;

        if (verticalVelocity.y < bigFallThreshold)
        {
            verticalVelocity.y = Mathf.Max(verticalVelocity.y, maxFallSpeed);
        }
    }

    controller.Move(verticalVelocity * Time.deltaTime);
}
}
