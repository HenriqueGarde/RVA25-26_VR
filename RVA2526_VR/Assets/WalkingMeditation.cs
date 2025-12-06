using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMeditation : MonoBehaviour
{
    public GameObject guideSphere;

    public float inhaleDuration = 4.0f;

    public float holdDuration = 7.0f;

    public float exhaleDuration = 8.0f;

    public Vector3 minSize = new(0.5f, 0.5f, 0.5f);

    public Vector3 maxSize = new(1.5f, 1.5f, 1.5f);

    private AudioSource _audioSource;

    private bool _isMeditating;

    private float _timer = 0f;

    public TrailRenderer handTrailRight;
    public TrailRenderer handTrailLeft;

    private enum BreathPhase
    {
        Inhale,
        Hold,
        Exhale
    };

    private BreathPhase currPhase = BreathPhase.Inhale; 
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if(guideSphere != null) guideSphere.SetActive(false);
        ChangeTrailEmission(handTrailLeft, false);
        ChangeTrailEmission(handTrailRight, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isMeditating) return;

        _timer += Time.deltaTime;

        if (currPhase == BreathPhase.Inhale)
        {
            float progress = _timer / inhaleDuration;
            guideSphere.transform.localScale = Vector3.Lerp(minSize, maxSize, progress);
            if (_timer >= inhaleDuration)
            {
                _timer = 0f;
                currPhase = BreathPhase.Hold;
            }
        }
        else if (currPhase == BreathPhase.Hold)
        {
            guideSphere.transform.localScale = maxSize;
            if (_timer >= inhaleDuration)
            {
                _timer = 0f;
                currPhase = BreathPhase.Exhale;
            }
        }
        else
        {
            float progress = _timer / exhaleDuration;
            guideSphere.transform.localScale = Vector3.Lerp(minSize, maxSize, progress);
            if (_timer >= exhaleDuration)
            {
                _timer = 0f;
                currPhase = BreathPhase.Inhale;
            }
        }

        if (!_audioSource.isPlaying)
        {
            StopSession();
        }
    }

    public void StartSession()
    {
        if (_isMeditating)
        {
            _isMeditating = true;
            guideSphere.SetActive(true);
            _audioSource.Play();
            
            ChangeTrailEmission(handTrailLeft, true);
            ChangeTrailEmission(handTrailRight, true);

            _timer = 0f;
            currPhase = BreathPhase.Inhale;
            guideSphere.transform.localScale = minSize;
        }
    }

    void StopSession()
    {
        _isMeditating = false;
        if(guideSphere !=null) guideSphere.SetActive(false);
        
        ChangeTrailEmission(handTrailLeft, false);
        ChangeTrailEmission(handTrailRight, false);

    }

    void ChangeTrailEmission(TrailRenderer trailRenderer, bool value)
    {
        if (trailRenderer != null) trailRenderer.emitting = value;
    }
}
