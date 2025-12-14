using UnityEngine;

public class BowlSound : MonoBehaviour
{
    public AudioClip hitClip;
    public float volumeMultiplier = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Bowl"))
            return;

        float strength = collision.relativeVelocity.magnitude;
        float volume = Mathf.Clamp01(strength * volumeMultiplier);

        AudioSource.PlayClipAtPoint(
            hitClip,
            collision.contacts[0].point,
            volume
        );
    }
}
