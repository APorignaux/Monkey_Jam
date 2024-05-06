using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source ---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clip ---------")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip collectACoin;
    public AudioClip extraLife;
    public AudioClip areaUnlocked;

    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}
