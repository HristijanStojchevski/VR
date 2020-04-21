using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class Instructions : MonoBehaviour {

	public UnityEvent GVRLoader;
	public UnityEvent GVRClick;
	public bool isLoaded=false;
	public bool gvrStatus=false;
	public float loadingTime=2;
	public float gvrTimer;
	public GameObject insMenuBackSlider;
	public GameObject button;
	public Slider slider;
	void Start(){
		insMenuBackSlider = GameObject.Find("BackSlider");
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
	public void hideInstructions(){
		slider = insMenuBackSlider.GetComponent<Slider>();
		button = GameObject.Find("BackButton");
		pointerActive(); 
	}
}
