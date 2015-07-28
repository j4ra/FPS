using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {

    public AudioClip[] music;
    
    int current;
	// Use this for initialization
	void Start () {
        audio.volume = GlobalVariables.MusicVolume;
	}
	
	// Update is called once per frame
	void Update () {
        if (!audio.isPlaying)
        {
            audio.clip = music[Random.Range(0, music.Length)];
            audio.Play();
        }
        audio.volume = GlobalVariables.MusicVolume;
	}
}
