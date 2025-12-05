using UnityEngine;
using UnityEngine.SceneManagement;

public class VRMenuActions : MonoBehaviour
{
    public void StartMeditation()
    {
        SceneManager.LoadScene("MeditationScene");
    }

    public void StartStoneStacking()
    {
        SceneManager.LoadScene("StoneStackScene");
    }

    public void StartFreeWalk()
    {
        SceneManager.LoadScene("WalkScene");
    }
}
