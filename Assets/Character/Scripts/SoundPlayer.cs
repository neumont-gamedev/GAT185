using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] int maxAudioSources = 5;
    [SerializeField] AudioClip[] audioClips;

    List<AudioSource> audioSources = new List<AudioSource>();
    Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();

    void Start()
    {
        foreach (var audioClip in audioClips)
		{
            clips[audioClip.name.ToLower()] = audioClip;
		}
    }

    public void PlayClip(string name)
	{
        AudioSource audioSource = GetFreeAudioSource();
        if (audioSource == null)
		{
            if (audioSources.Count == maxAudioSources) return;

            audioSource = gameObject.AddComponent<AudioSource>();
            audioSources.Add(audioSource);
		}

        if (clips.TryGetValue(name.ToLower(), out AudioClip audioClip))
		{
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    public AudioSource GetFreeAudioSource()
	{
        foreach(AudioSource audioSource in audioSources)
		{
            if (!audioSource.isPlaying) return audioSource;
		}

        return null;
    }
}
