using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class GamePlay : MonoBehaviour {
	public Camera cam;
	public Transform vrCamera;
	public Text timerText;
	public Text scoreText;
	public Text amountText;
	public Color orange = new Color(1.0f,0.64f,0.0f);
	public float timeOfImpact=300.0f;
	public int goal=3;
	public float gameTimer;
	public bool remainder = true;
	public bool checkNeeded=true;
	public GameObject prefabBall;
	// Use this for initialization
	void Start () {
		timerText = GameObject.Find("TimerText").GetComponent<Text>();
		amountText = GameObject.Find("AmountText").GetComponent<Text>();
		scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
		cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		PlayerPrefsX.SetBool("checkNeeded",true);
		//the balls need to be added as objects dynamicaly
		if(PlayerPrefsX.GetBool("Pause")){
			//load all prefs
			GameObject.Find("Player").transform.position = PlayerPrefsX.GetVector3("PlayerPosition");
			cam.transform.localEulerAngles = PlayerPrefsX.GetVector3("PlayerOrientation");
			PlayerPrefsX.SetBool("Pause",false);
			checkNeeded = true;
			amountText.text = PlayerPrefs.GetString("score");
			timeOfImpact = PlayerPrefs.GetFloat("timeLeft");
			Vector3[] ballPositions = PlayerPrefsX.GetVector3Array("BallPositions");
			foreach(Vector3 pos in ballPositions){
                Instantiate(prefabBall,pos, Quaternion.identity);
			}
		}
	}

    // Update is called once per frame
    void Update () {
		timerTick();
		updateTime(); // UI timer
		if(checkNeeded){
		checkGoal(); // check if the required number of balls are transported to locations
		}
	}
	
	
    private void checkGoal()
    {
		int momentScore = Int16.Parse(amountText.text);
        if(momentScore==goal){
			scoreText.color = Color.green;
			scoreText.text = "Safe place unlocked !";
			scoreText.fontSize = 13;
			amountText.fontSize = 1;
			Destroy(GameObject.Find("Portal"));
			HouseManagement.locked = false;
			checkNeeded = false;
			PlayerPrefsX.SetBool("checkNeeded",checkNeeded);
		}
    }

    void timerTick(){
		gameTimer += Time.deltaTime;
	}

	void updateTime(){
		float t = timeOfImpact - gameTimer;
		if(t <= 0){ //Game Over you die
			PlayerPrefsX.SetBool("GameOver",true);
			SceneManager.LoadScene("Menu");
		} 
		if(remainder && t <= 8.0f)
		{
			FindObjectOfType<AudioManager>().PlaySound("LastWarning");
			remainder = false;
		}
		float sec = t % 60;
		string minutes = ((int) t / 60).ToString();
		string seconds = sec.ToString("00");
		if(t >= 10 && t <= 60) timerText.color = orange;
		if(t <= 10) timerText.color = Color.red;
		timerText.text = minutes + ":" + seconds;
	}
}
