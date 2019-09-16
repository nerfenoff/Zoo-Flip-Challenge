using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource effectAudioSource;
    [SerializeField]
    AudioSource coinsAudioSource;

    public void CollectCoin()
    {
        coinsAudioSource.Play();
    }
    public void Jump()
    {
        effectAudioSource.Play();
    }
}
