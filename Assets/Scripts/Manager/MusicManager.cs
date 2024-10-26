using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioMixerGroup mixerGroup;

    private void Start()
    {
        audioSource.outputAudioMixerGroup = mixerGroup;
    }

    public void changeBGM(AudioClip bgm)
    {
        if (audioSource.clip != bgm)
        {
            audioSource.clip = bgm;
            StartBGM();
        }
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }

    public void StartBGM()
    {
        audioSource.Play();
    }
}