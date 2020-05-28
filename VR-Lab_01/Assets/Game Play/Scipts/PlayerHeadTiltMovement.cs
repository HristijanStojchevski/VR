using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class PlayerHeadTiltMovement : MonoBehaviour {
	public Camera cam;
	public Transform vrCamera;
	public AudioSource footsteps;
	public bool startWalking = true;
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
		cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		checkHeadTilt();
		
		if(moveForward){
			Vector3 forward = vrCamera.TransformDirection(Vector3.forward);	
			cc.SimpleMove(forward*speedOfMovement);
			if(startWalking){
				footsteps.Play();
				startWalking = false;
			}
		}
		else{
			footsteps.Stop();
			startWalking = true;
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
		PlayerPrefsX.SetVector3("PlayerPosition",this.transform.position);
		PlayerPrefsX.SetVector3("PlayerOrientation",cam.transform.localEulerAngles);
		if(PlayerPrefsX.GetBool("checkNeeded"))	PlayerPrefsX.SetVector3("portalPosition",GameObject.Find("Portal").transform.position);
		GameObject[] balls = GameObject.FindGameObjectsWithTag("RedBall");
		Vector3[] positions = new Vector3[balls.Length];
		int counter = 0;
		foreach(GameObject ball in balls){
			positions[counter] = ball.transform.position;
			counter++;
		}
		PlayerPrefsX.SetVector3Array("BallPositions",positions);
		PlayerPrefs.SetString("score",GameObject.Find("AmountText").GetComponent<Text>().text);
		PlayerPrefsX.SetBool("Pause",true);
		string[] temp = GameObject.Find("TimerText").GetComponent<Text>().text.Split(':');
		float timeLeft =  float.Parse(temp[0])*60 + float.Parse(temp[1]);
		PlayerPrefs.SetFloat("timeLeft",timeLeft);
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
