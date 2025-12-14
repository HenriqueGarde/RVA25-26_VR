using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonFeedback : MonoBehaviour
{
    public float hoverSize = 1.2f;

    private Vector3 _originalScale;
    // Start is called before the first frame update
    void Start()
    {
        _originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnHoverEnter()
    {
        transform.localScale = _originalScale * hoverSize;

        var interactable = GetComponent<XRSimpleInteractable>();
        if (interactable && interactable.interactorsHovering.Count > 0)
        {
            var interactor = interactable.interactorsHovering[0];
            if (interactor is XRBaseControllerInteractor controllerInteractor)
            {
                controllerInteractor.SendHapticImpulse(0.5f, 0.1f);
            }
        }
    }

    public void OnHoverExit()
    {
        transform.localScale = _originalScale;
    }
}
