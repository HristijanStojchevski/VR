using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerHeadTiltMovement : MonoBehaviour {
	
	public Transform vrCamera;

	public float headAngleDown = 30.0f;
	public float headAngleUpForPause = -65.0f;

	public float speedOfMovement = 10.0f;
	public float gvrTimer;
	public float loadingTime=5;

	public bool moveForward;
	public bool showPauseMenu;
	private CharacterController cc;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		checkHeadTilt();
		
		if(moveForward){
			Vector3 forward = vrCamera.TransformDirection(Vector3.forward);	
			cc.SimpleMove(forward*speedOfMovement);
		}

		if(showPauseMenu){
			timerTick();
		}
		if(gvrTimer >= loadingTime){
			openPauseMenu();
		}
	}
	void timerTick(){
		gvrTimer += Time.deltaTime;	
	}
	void openPauseMenu(){
		SceneManager.LoadScene("Menu");
		//save player position

	}
	void checkHeadTilt(){
		float angle = vrCamera.eulerAngles.x;
		angle = (angle > 180) ? angle - 360 : angle;
		if(angle >= headAngleDown && angle < 90.0f){
			moveForward = true;
		}
		else{
			moveForward = false;
		}
		
		if(angle <= headAngleUpForPause){
			showPauseMenu = true;
		}
		else{
			showPauseMenu = false;
		}
	}
}
