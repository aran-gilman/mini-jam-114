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
        // Putting this in Start() instead of Awake() makes it more likely for Play() to be called before audioSource is initialized. However, putting this in Awake() runs the risk of grabbing the "wrong" SfxPlayer, so Start() seems like the lesser of two evils.
        audioSource = GameObject.FindGameObjectWithTag("Sfx").GetComponent<AudioSource>();
    }
}
