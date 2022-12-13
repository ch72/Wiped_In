using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource EffectsSource;
    public AudioSource MusicSource;
    public AudioSource EnemySource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Play(AudioClip clip)
    {
        EffectsSource.clip = clip;
        EffectsSource.Play();
    }

    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    public void RandomSoundEffect(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, (clips.Length - 1));
        EffectsSource.clip = clips[randomIndex];
        EffectsSource.Play();
    }

    public void RandomSoundEffectEnemy(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, (clips.Length - 1));
        EnemySource.clip = clips[randomIndex];
        EnemySource.Play();
    }
}
