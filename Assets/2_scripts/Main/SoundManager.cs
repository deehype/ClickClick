using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    public static SoundManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Sound(Define.Sound sound)
    {
        audioSource.PlayOneShot(audioClips[(int)sound]);
    }
}

