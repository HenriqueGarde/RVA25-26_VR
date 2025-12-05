using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public static class MoveProviderExtensions
{
    public static Vector3 GetLastInputDirection(this ActionBasedContinuousMoveProvider provider)
    {
        Vector2 move = provider.leftHandMoveAction.action.ReadValue<Vector2>();
        if (move == Vector2.zero && provider.rightHandMoveAction != null)
            move = provider.rightHandMoveAction.action.ReadValue<Vector2>();

        Transform forwardSource = provider.forwardSource;

        Vector3 forward = forwardSource.forward;
        forward.y = 0; forward.Normalize();

        Vector3 right = forwardSource.right;
        right.y = 0; right.Normalize();

        return (forward * move.y + right * move.x);
    }
}
