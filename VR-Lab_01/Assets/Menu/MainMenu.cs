using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour {

	public UnityEvent GVRLoader;
	public UnityEvent GVRClick;
	public bool isLoaded=false;
	public bool gvrStatus=false;
	public float loadingTime=2;
	public float gvrTimer;
	public GameObject mainMenu;
	public GameObject insMenuBackSlider;
	public GameObject button;
	public GameObject instructions;
	public GameObject quit;
	public GameObject quitMenu;
	public Slider slider;
	void Start(){
		mainMenu = GameObject.Find("PlaySlider");
		instructions = GameObject.Find("InstSlider");
		quit = GameObject.Find("QuitSlider");
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
	public void playGameHover(){
		slider = mainMenu.GetComponent<Slider>();
		button = GameObject.Find("PlayButton");
		pointerActive();
	}
	public void playGame(){
		SceneManager.LoadScene("InitialScene");
	}
	public void showInstructionsHover(){
		slider = instructions.GetComponent<Slider>();
		button = GameObject.Find("InstructionsButton");
		pointerActive(); 
	}
	public void showInstructions(){

	}
	public void quitGameHover(){
		slider = quit.GetComponent<Slider>();
		button = GameObject.Find("QuitButton");
		pointerActive();
	}
	
}
