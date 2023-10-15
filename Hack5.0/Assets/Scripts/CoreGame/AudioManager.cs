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
            int randomIndex = Random.Range(0, 2); //Бо закинув ще 2 звуки, варто довести до ладу 
            AudioClip randomClip = soundClips[randomIndex];

            if (randomClip != null && audioSource != null)
            {
                audioSource.clip = randomClip;
                audioSource.Play();
            }
        }
    }

    public void PlaySound3Once()
    {
        if (soundClips.Length > 3)
        {
            audioSource.clip = soundClips[3];
            audioSource.Play();
        }
    }

    public void PlaySound4Looped()
    {
        if (soundClips.Length > 4)
        {
            audioSource.clip = soundClips[4];
            audioSource.loop = true; // Звук 4 зациклюється
            audioSource.Play();
        }
    }

    public void StopSound4Looped()
    {
        audioSource.Stop();
        audioSource.loop = false; // Зупиняємо звук 4 та вимикаємо зациклювання
    }
}