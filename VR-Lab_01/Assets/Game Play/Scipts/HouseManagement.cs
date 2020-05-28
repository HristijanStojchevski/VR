using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class HouseManagement : MonoBehaviour {
	public AudioSource source;
	static public bool locked = true;
	public GameObject rules;
	public bool entered=false;
	public float timer;
	public float entranceTime=2;
	// Use this for initialization
	void Start () {
		rules = GameObject.Find("Plane");
		rules.GetComponent<Renderer>().enabled = false;
		rules.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(entered){
			timerTick();
			if(timer >= entranceTime){
				source.Play();
				PlayerPrefsX.SetBool("win",true);
				SceneManager.LoadScene("Menu");
			}
		}
	}

    private void timerTick()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
		if(other.name.CompareTo("Player") == 0){
			if(locked){
				Debug.Log("Still locked");
				rules.GetComponent<Renderer>().enabled = true;
				rules.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
				//tell him he needs to deliver x more balls.
			}
			else{
				rules.GetComponent<Renderer>().enabled = true;
				rules.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
				rules.transform.GetChild(0).GetComponent<TextMesh>().text = "You can now enter !";
				//win the game
				entered = true;
			}
		}
	}

	private void OnTriggerExit(Collider other) {
		if(other.name.CompareTo("Player") == 0){
			entered = false;
			timer = 0;
			rules.GetComponent<Renderer>().enabled = false;
			rules.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
		}
	}
}
