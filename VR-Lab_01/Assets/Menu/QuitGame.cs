using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class QuitGame : MonoBehaviour {

	public UnityEvent GVRLoader;
	public UnityEvent GVRClick;
	public bool isLoaded=false;
	public bool gvrStatus=false;
	public float loadingTime=2;
	public float gvrTimer;
	public GameObject button;
	public GameObject quitYes;
	public GameObject quitNo;
	public Slider slider;
	void Start(){
		quitYes = GameObject.Find("YesSlider");
		quitNo = GameObject.Find("NoSlider");
	}
	void Update(){
		if(gvrStatus){
			gvrTimer += Time.deltaTime;
			slider.normalizedValue = gvrTimer/loadingTime;
			//slider fill
		}
		if(gvrTimer >= loadingTime){
			//GVRClick.Invoke();
			button.GetComponent<Button>().onClick.Invoke();
			gvrTimer = 0;
			slider.normalizedValue = 0;
			gvrStatus = false;
		}

	}
	public void pointerActive(){
		gvrStatus = true;
	}
	public void pointerNotActive(){
		gvrStatus = false;
		gvrTimer = 0;
		slider.normalizedValue = 0;
	}
	public void quitGame(){
		//Shold close app on phone
		Application.Quit();
	}
	public void quitAck(){
		slider = quitYes.GetComponent<Slider>();
		button = GameObject.Find("YesButton");
		pointerActive();
	}
	public void doNotQuit(){
		slider = quitNo.GetComponent<Slider>();
		button = GameObject.Find("NoButton");
		pointerActive();
	}
}
