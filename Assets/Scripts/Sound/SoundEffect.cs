using UnityEngine;
using System.Collections;

public class SoundEffect : MonoBehaviour {

    public AudioClip[] soundEffects;

    AudioSource audioSource;

    public bool OneShot = false;

    int current;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (OneShot)
        {
            audioSource.clip = soundEffects[Random.Range(0, soundEffects.Length)];
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!OneShot)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = soundEffects[Random.Range(0, soundEffects.Length)];
                audioSource.Play();
            }
        }
    }
}
