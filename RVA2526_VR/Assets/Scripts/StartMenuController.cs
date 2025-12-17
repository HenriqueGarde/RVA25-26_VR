using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class VRStartMenuController : MonoBehaviour
{
    [Header("Menu")]
    public GameObject menuCanvas;

    [Header("Left Hand UI Ray")]
    public XRRayInteractor leftHandRayInteractor;
    public XRInteractorLineVisual leftHandLineVisual;

    [Header("Scene Loading")]
    public string gameplaySceneName = "GameplayScene";

    void Start()
    {
        if (menuCanvas != null)
            menuCanvas.SetActive(true);

        if (leftHandRayInteractor != null)
            leftHandRayInteractor.enabled = true;

        if (leftHandLineVisual != null)
            leftHandLineVisual.enabled = true;
    }

    // -------- BUTTONS --------

    public void StartMeditation()
    {
        GameMode.selectedMode = 1;
        SceneManager.LoadScene(gameplaySceneName);
    }

    public void StoneStacking()
    {
        GameMode.selectedMode = 2;
        SceneManager.LoadScene(gameplaySceneName);
    }

    public void FreeWalk()
    {
        GameMode.selectedMode = 3;
        SceneManager.LoadScene(gameplaySceneName);
    }

    public void QuitApp()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
