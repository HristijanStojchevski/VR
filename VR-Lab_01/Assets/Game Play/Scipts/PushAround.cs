using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAround : MonoBehaviour {

    public float pushForce = 100;
    public float gvrTimer;

    public bool pushing = false;
    private Rigidbody rigidBody;
    public GameObject player;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if(pushing){
            timerTick();
            transform.rotation = Quaternion.AngleAxis(player.transform.rotation.eulerAngles.y, Vector3.up);
            calculateForce();
            rigidBody.AddForce(player.transform.forward*pushForce);
        }
	}

    private void calculateForce()
    {
        pushForce += gvrTimer;
    }

    private void timerTick()
    {
        gvrTimer += Time.deltaTime;
    }

    public void push() {
        pushing = true;
    }
    public void stopPushing(){
        pushing = false;
        pushForce = 50;
        gvrTimer = 0;
    }
}
