using UnityEngine;

public class StoneSound : MonoBehaviour
{
    public AudioClip hitSound;
    private AudioSource _source;
    
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //sound only if great impact
        if (collision.relativeVelocity.magnitude > 0.5f)
        {
            _source.pitch = Random.Range(0.8f, 1.2f); //the sound vary to mantain realism
            _source.PlayOneShot(hitSound);
        }
    }
}
