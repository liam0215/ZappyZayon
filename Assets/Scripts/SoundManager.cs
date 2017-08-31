using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource musicSource;
    public static SoundManager instance = null;

	// Use this for initialization
	void Awake () {
		if(instance == null)
        {
            instance = this;
        } else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
	}
	
    public void PlaySingle(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void FadeSong()
    {
        StartCoroutine(FadeSongHelper());
    }

    IEnumerator FadeSongHelper()
    {
        float startVolume = musicSource.volume;
        float fadeTime = 0.5f;
        while(musicSource.volume > 0)
        {
            musicSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
        musicSource.Stop();
        musicSource.volume = startVolume;
    }
}
