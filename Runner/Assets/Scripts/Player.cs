using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour {

[SerializeField]
private Rigidbody rigidBody;
[SerializeField]
private float speed;
[SerializeField]
private float sideSpeed;
public Action onGameOver;
public Action onGameWin;

	private void Start () {
	
	}
	
	private void Update () {
	if(transform.position.y < -5){		
		if(onGameOver != null){				
				onGameOver();				
			}				
	}

	if(Input.GetKey(KeyCode.A)){
		rigidBody.AddForce(-sideSpeed * Time.deltaTime,0,0,ForceMode.VelocityChange);
	}else if(Input.GetKey(KeyCode.D)){
		rigidBody.AddForce(sideSpeed * Time.deltaTime,0,0,ForceMode.VelocityChange);
	}
			else if(Input.GetKey(KeyCode.W))
		{
			//Move front
		rigidBody.AddForce(0, 0, speed * Time.deltaTime, ForceMode.VelocityChange);
		}
		else if(Input.GetKey(KeyCode.S))
		{
		rigidBody.AddForce(0, 0, -speed * Time.deltaTime, ForceMode.VelocityChange);
		}

	
	}
	private void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Obstacle"){
			rigidBody.AddForce(0,0,-speed*200);	
		}
	}

	 private void OnTriggerEnter(Collider other) {

		 if(other.tag == "Finish"){
			this.enabled = false;
			if(onGameWin != null){
				onGameWin();
			}				
		}
		else if(other.tag == "SpringBoard"){
			rigidBody.AddForce(0,1000,0);	
		}
		else if(other.tag == "Coin"){
						
		}
	}

}