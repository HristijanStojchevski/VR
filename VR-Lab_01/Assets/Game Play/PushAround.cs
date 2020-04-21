using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAround : MonoBehaviour {

    public float pushForce = 100;
    private Rigidbody rigidBody;
    public GameObject player;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void push() {

        transform.rotation = Quaternion.AngleAxis(player.transform.rotation.eulerAngles.y, Vector3.up);
        rigidBody.AddForce(player.transform.forward*pushForce);
    }
}
