using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Portal : MonoBehaviour {
	public Text scoreText;
	private void Start() {
		scoreText = GameObject.Find("AmountText").GetComponent<Text>();
		if(PlayerPrefsX.GetBool("Pause")){
			this.transform.position = PlayerPrefsX.GetVector3("portalPosition");
			if(PlayerPrefsX.GetBool("portalVisible")){
				this.GetComponent<Renderer>().enabled = true;
			}
		}
	}
	private void OnTriggerEnter(Collider other) {
		if(other.tag.CompareTo("RedBall") == 0){
			FindObjectOfType<AudioManager>().PlaySound("EnteringTeleport");
			scoreText.text = (Int16.Parse(scoreText.text) + 1).ToString();
		}
	}
	private void OnTriggerExit(Collider other) {
		if(other.tag.CompareTo("RedBall") == 0){
			Destroy(other.gameObject);
			float x = UnityEngine.Random.Range(-119.0f,165.0f);
			float z = UnityEngine.Random.Range(-167.0f,110.0f);
			this.transform.position = new Vector3(x,90.0f,z); //random
			PlayerPrefsX.SetVector3("portalPosition",this.transform.position);
		}
	}
}
