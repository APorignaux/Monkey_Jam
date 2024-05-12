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
    public AudioClip levelGoal;
    public AudioClip stomp;

    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void CollectACoinSound()
    {
        SFXSource.clip = collectACoin;
        SFXSource.Play();
    }

    public void LevelGoalSound()
    {
        SFXSource.clip = levelGoal;
        SFXSource.Play();
    }

    public void DeadSound()
    {
        SFXSource.clip = death;
        SFXSource.Play();
    }

    public void extraLifeSound()
    {
        SFXSource.clip = extraLife;
        SFXSource.Play();
    }

    public void StompSound()
    {
        SFXSource.clip = stomp;
        SFXSource.Play();
    }
}
