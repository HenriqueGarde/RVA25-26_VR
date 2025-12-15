using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRMenuController : MonoBehaviour
{
    [Header("Menu")]
    public GameObject menuCanvas;

    [Header("Player")]
    public Transform xrOrigin;

    [Header("Teleport Targets")]
    public Transform teleportPointA;
    public Transform teleportPointB;
    public Transform teleportPointC;

    [Header("Left Hand UI Ray")]
    public XRRayInteractor leftHandRayInteractor;
    public XRInteractorLineVisual leftHandLineVisual;

    private CharacterController characterController;

    void Start()
    {
        if (menuCanvas != null)
            menuCanvas.SetActive(false);

        if (leftHandRayInteractor != null)
            leftHandRayInteractor.enabled = false;

        if (leftHandLineVisual != null)
            leftHandLineVisual.enabled = false;

        if (xrOrigin != null)
            characterController = xrOrigin.GetComponent<CharacterController>();
    }

    public void ToggleMenu()
    {
        bool isOpen = !menuCanvas.activeSelf;

        menuCanvas.SetActive(isOpen);

        // Enable ray + line only when menu is open
        if (leftHandRayInteractor != null)
            leftHandRayInteractor.enabled = isOpen;

        if (leftHandLineVisual != null)
            leftHandLineVisual.enabled = isOpen;
    }

    public void TeleportToPointA() => Teleport(teleportPointA);
    public void TeleportToPointB() => Teleport(teleportPointB);
    public void TeleportToPointC() => Teleport(teleportPointC);

    private void Teleport(Transform target)
    {
        if (xrOrigin == null || target == null)
            return;

        if (characterController != null)
            characterController.enabled = false;

        xrOrigin.position = target.position;

        if (characterController != null)
            characterController.enabled = true;
    }

    public void QuitApp()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
