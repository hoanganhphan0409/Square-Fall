using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private List<SoundType> soundList;
    [SerializeField] private AudioSource audioSource;
    private void Start()
    {
        Observer.PlaySound += PlaySound;
    }

    void PlaySound(ESound eSoundPlay)
    {
        var audioClip = soundList.FirstOrDefault(soundType => soundType.eSound == eSoundPlay).sound;
        if (audioClip) audioSource.PlayOneShot(audioClip);
    }

    private void OnDestroy()
    {
        Observer.PlaySound -= PlaySound;
    }
}

[Serializable]
public class SoundType
{
    public ESound eSound;
    public AudioClip sound;
}

public enum ESound
{
    GetPoint,
    Button,
    Lose,
    RevertMove,
    Tap
}