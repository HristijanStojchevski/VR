using UnityEngine.Audio;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour {
	public Sound[] sounds;

	public static AudioManager instance;

	// Use this for initialization
	private void Awake() {

		if(instance == null){
			instance = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

		foreach(Sound sound in sounds){
			sound.source = gameObject.AddComponent<AudioSource>();
			sound.source.clip = sound.clip;
			sound.source.volume = sound.volume;
			sound.source.pitch = sound.pitch;
			sound.source.loop = sound.loop;
		}
	} 
	private void Start() {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlaySound(string name){
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			Debug.LogWarning("No sound with the name" + name + " was found!");
			return;
		}
		s.source.Play();
	}
}
