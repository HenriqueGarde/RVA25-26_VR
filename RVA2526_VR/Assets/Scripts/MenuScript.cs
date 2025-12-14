using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class VRMenuController : MonoBehaviour
{
    [Header("Menu")]
    public GameObject menuCanvas; // your hand menu canvas

    [Header("Player")]
    public Transform xrOrigin; // XR Origin transform

    [Header("Teleport Targets")]
    public Transform teleportPointA;
    public Transform teleportPointB;

    void Start()
    {
        // Hide menu at start
        if (menuCanvas != null)
            menuCanvas.SetActive(false);
    }

    // Called from input (e.g. button or gesture)
    public void ToggleMenu()
    {
        menuCanvas.SetActive(!menuCanvas.activeSelf);
    }

    public void TeleportToPointA()
    {
        if (xrOrigin != null && teleportPointA != null)
            xrOrigin.position = teleportPointA.position;
    }

    public void TeleportToPointB()
    {
        if (xrOrigin != null && teleportPointB != null)
            xrOrigin.position = teleportPointB.position;
    }

    public void QuitApp()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
