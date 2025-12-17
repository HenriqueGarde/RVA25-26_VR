using UnityEngine;

public class AmbientFade : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeInTime = 3f;
    public float targetVolume = 0.1f;

    void Start()
    {
        audioSource.volume = 0f;
        audioSource.Play();
        StartCoroutine(FadeIn());
    }

    System.Collections.IEnumerator FadeIn()
    {
        float t = 0f;
        while (t < fadeInTime)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0f, targetVolume, t / fadeInTime);
            yield return null;
        }
    }
}
