using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BallGenerator : MonoBehaviour {
	public bool isFirst = true;
	public GameObject activatorX;
	public GameObject activatorZ;
	public GameObject activator_X;
	public GameObject activator_Z;
	public GameObject activator;
	public Material activatorMaterial;
	public bool gvrStatus=false;
	public float loadingTime=2;
	public float gvrTimer;
	public bool firstBall = true;
	float lightChange = 0.015f;
	float currColor = 0.141f;
	public GameObject prefabBall;
	Color activatorMatColor;
	// Use this for initialization
	void Start () {
		activatorX = GameObject.Find("ActivatorX");
		activatorZ= GameObject.Find("ActivatorZ");
		activator_X = GameObject.Find("Activator_X");
		activator_Z = GameObject.Find("Activator_Z");
		activatorMatColor = new Color(0.141f,0.01347793f,0.01347793f);
		// activatorX.GetComponent<Renderer>().enabled = false;
		// activatorX.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
		Vector3[] ballPositions = PlayerPrefsX.GetVector3Array("BallPositions");
		if(ballPositions.Length > 90){
			firstBall = false;
			foreach(Vector3 vc in ballPositions){
				Instantiate(prefabBall,vc,Quaternion.identity);
			}
		}
	}
	private void Update() {
		if(gvrStatus){
			gvrTimer += Time.deltaTime;
			//change lights on activator
			glow();
		}
		if(gvrTimer >= loadingTime){
			//GVRClick.Invoke();
			SpawnBall();
			gvrTimer = 0;
			//lighting normal
			activatorMaterial.SetColor("_EmissionColor",activatorMatColor);
			gvrStatus = false;
		}
	}

    private void glow()
    {	if(currColor > 0.513 || currColor < 0.141) lightChange *= -1;
		currColor += lightChange;
		activatorMaterial.SetColor("_EmissionColor",new Color(currColor,0.01347793f,0.01347793f));
    }

    private void OnTriggerEnter(Collider other) {
		if(other.name.CompareTo("Player") == 0){ // and player position
			checkPlayerPosition(other);
			// activatorX.GetComponent<Renderer>().enabled = true;
			// activatorX.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
			// activatorZ.GetComponent<Renderer>().enabled = true;
			// activatorZ.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
			// activator_X.GetComponent<Renderer>().enabled = true;
			// activator_X.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
			activator.GetComponent<Renderer>().enabled = true;
			activator.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
			activator.GetComponent<Collider>().enabled = true;
		}
	}
	// Nice function to determine player's approach to a cube so we can be sure on wich wall we want the UI to appear
	private void checkPlayerPosition(Collider player){
		Vector3 vector = player.transform.position;
			float x = vector.x;
			float z = vector.z;
			// Debug.Log(x + " , "+ z);
			// Activator X
			if((x>5.02 && z<7.51 && (x+z)>12.53) || (x>5.02 && z>7.51 && (x-z)>-2.49)) activator = activatorX;
			// Activator -Z
			if((x<5.02 && z<7.51 && (z-x)>2.49) || (x>5.02 && z<7.51 && (x+z)<12.53)) activator = activator_Z;
			// Activator -X
			if((x<5.02 && z<7.51 && (z-x)<2.49) || (x<5.02 && z>7.51 && (-x-z)>-12.53)) activator = activator_X;
			// Activator Z
			if((x>5.02 && z>7.51 && (x-z)<-2.49) || (x<5.02 && z>7.51 && (-x-z)<-12.53)) activator = activatorZ;
			// Debug.Log(activator.name);
	}

	private void OnTriggerExit(Collider other) {
		if(other.name.CompareTo("Player") == 0){
			// activatorX.GetComponent<Renderer>().enabled = false;
			// activatorX.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
			// activatorZ.GetComponent<Renderer>().enabled = false;
			// activatorZ.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
			// activator_X.GetComponent<Renderer>().enabled = false;
			// activator_X.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
			// activator_Z.GetComponent<Renderer>().enabled = false;
			// activator_Z.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
			activator.GetComponent<Renderer>().enabled = false;
			activator.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
			activator.GetComponent<Collider>().enabled = false;
		}
	}

	//spawns/throws a ball on a random location
	public void SpawnBall(){
		float x = UnityEngine.Random.Range(-119.0f,165.0f);
		float z = UnityEngine.Random.Range(-167.0f,110.0f);
		float y = UnityEngine.Random.Range(0.5f,12.0f);
		FindObjectOfType<AudioManager>().PlaySound("BallSpawn");
		Instantiate(prefabBall,new Vector3(x,y,z), Quaternion.identity);
		if(firstBall){
			SpawnFirstPortal(); // only one needed
		}
		// ballObject.transform.position = new Vector3(0,0,0);
	}

	void SpawnFirstPortal(){
        // random location, mesh activate, si ima skripta vekje za render na novo mesto
        float x = UnityEngine.Random.Range(-119.0f,165.0f);
		float z = UnityEngine.Random.Range(-167.0f,110.0f);
		GameObject portal = GameObject.Find("Portal");
		portal.transform.position = new Vector3(x,90.0f,z);
		portal.GetComponent<Renderer>().enabled = true;
		firstBall = false;
		PlayerPrefsX.SetBool("portalVisible",true);
	}
	public void ActivatorX_Hover(){
		activator = activatorX;
		PointerActive();
	}
	public void Activator_X_Hover(){
		activator = activator_X;
		PointerActive();
	}
	public void ActivatorZ_Hover(){
		activator = activatorZ;
		PointerActive();
	}
	public void Activator_Z_Hover(){
		activator = activator_Z;
		PointerActive();
	}
	public void PointerActive(){
		gvrStatus = true;
	}
	public void PointerNotActive(){
		gvrStatus = false;
		gvrTimer = 0;
		//activator normalized
	}
}
