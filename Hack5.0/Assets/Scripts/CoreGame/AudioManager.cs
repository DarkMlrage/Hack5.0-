using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] soundClips; // Масив звукових файлів

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomSound()
    {        
        if (soundClips.Length > 0)
        {
            int randomIndex = Random.Range(0, soundClips.Length);
            AudioClip randomClip = soundClips[randomIndex];

            if (randomClip != null && audioSource != null)
            {
                audioSource.clip = randomClip;
                audioSource.Play();
            }
        }
    }
}
