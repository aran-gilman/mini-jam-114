using UnityEngine;

public class PlaySfx : MonoBehaviour
{
    public void Play(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Sfx").GetComponent<AudioSource>();
    }
}
