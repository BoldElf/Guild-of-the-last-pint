using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] musicClips;
    private AudioSource audioSource;
    private int currentClipIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        PlayNextClip();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextClip();
        }
    }

    private void PlayNextClip()
    {
        if (musicClips.Length == 0)
        {
            Debug.LogWarning("No music clips assigned to the MusicPlayer.");
            return;
        }

        audioSource.clip = musicClips[currentClipIndex];
        audioSource.Play();

        currentClipIndex = (currentClipIndex + 1) % musicClips.Length;
    }
}
