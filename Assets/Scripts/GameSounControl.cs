using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSounControl : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] allClipSounds;
    public static GameSounControl instance;
    private void Start()
    {
        instance = this;
    }
    public void VfxPlay(int clipIndex)
    {
        audioSource.clip = allClipSounds[clipIndex];
        audioSource.Play();

    }
}

