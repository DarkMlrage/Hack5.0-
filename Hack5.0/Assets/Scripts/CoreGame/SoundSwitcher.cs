using UnityEngine;
using System.Collections;

public class SoundSwitcher : MonoBehaviour
{
    public AudioClip initialSound; // Початковий звук
    public AudioClip secondarySound; // Другий звук
    private AudioSource audioSource;

    private bool state;

    private bool hasPlayedInitialSound = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SetState(bool value)
    {
        if (value && !state)
        {
            state = value;
            hasPlayedInitialSound = false;
        }
        else
        {
            state = value;
        }
    }

    void Update()
    {
        Debug.Log(state);
        if (state)
        {
            // Перевірка, чи звук не відтворюється вже
            if (!hasPlayedInitialSound && !audioSource.isPlaying)
            {
                audioSource.clip = initialSound;
                audioSource.Play();
                hasPlayedInitialSound = true;
            }
            // Перевірка, чи звук першого не відтворюється, і вже відтворюється другий
            else if (hasPlayedInitialSound && !audioSource.isPlaying)
            {
                audioSource.clip = secondarySound;
                audioSource.Play();
            }
        }        
    }
}
