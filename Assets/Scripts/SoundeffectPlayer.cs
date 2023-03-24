using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundeffectPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip levelClear, clickSound, failSound;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayClick() { _audioSource.PlayOneShot(clickSound); }

    public void PlayLevelClear() { _audioSource.PlayOneShot(levelClear); }

    public void PlayFail() { _audioSource.PlayOneShot(failSound); }
}
