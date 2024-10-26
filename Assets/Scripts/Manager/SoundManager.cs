using UnityEngine;
using System;
using UnityEngine.Audio;
public enum SoundType
{
    JUMP,
    SHOOT,
    UI
}
[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundList[] soundList;
    public static SoundManager Instance;
    private AudioSource audioSource;
    private AudioSource lastPlayed;
    [SerializeField] private AudioMixerGroup audioMixer;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = audioMixer;
    }

    public static void PlaySound(SoundType sound, int number, bool cancelOnNextSound, float volume = 1)
    {
        if (Instance != null)
        {
            if (Instance.lastPlayed != null && Instance.lastPlayed.isPlaying)
            {
                Instance.lastPlayed.Stop();
            }

            AudioClip audioClip = GetAudioClip(sound, number);
            Instance.audioSource.PlayOneShot(audioClip, volume);
            if (cancelOnNextSound)
            {
                Instance.lastPlayed = Instance.audioSource;
            }
        }

    }

    public static AudioClip GetAudioClip(SoundType sound, int number)
    {
        AudioClip[] clips = Instance.soundList[(int)sound].Sounds;
        return clips[number];
    }

    public static void PlayRandomSound(SoundType sound, float volume = 1)
    {
        AudioClip[] clips = Instance.soundList[(int)sound].Sounds;
        AudioClip audioClip = clips[UnityEngine.Random.Range(0, clips.Length)];
        Instance.audioSource.PlayOneShot(audioClip, volume);
    }

    public void PlayButtonSound()
    {
        PlaySound(SoundType.UI, 0, false);
    }

#if UNITY_EDITOR
    private void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList, names.Length);
        for (int i = 0; i < soundList.Length; i++)
        {
            soundList[i].name = names[i];
        }
    }
#endif
}


[Serializable]
public struct SoundList
{
    public AudioClip[] Sounds { get => sounds; }
    [HideInInspector] public string name;
    [SerializeField] private AudioClip[] sounds;
}