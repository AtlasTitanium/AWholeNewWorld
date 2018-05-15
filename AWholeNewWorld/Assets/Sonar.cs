using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour {
	private Camera Camera;
	public float speed;
	private float near;
	private bool go = false;
	private bool rern = false;
	private bool clickable = true;
	// Use this for initialization
	void Start () {
		Camera = GetComponent<Camera>();
		near = 82f;
	}
	
	// Update is called once per frame
	void Update () {
		if(go){
			near += speed;
			if(near >= 159.3){
				near = 159.3f;
				go = false;
				clickable = true;
			}
		} 

		if(rern){
			near -= speed;
			if(near <= 82){
				near = 82f;	
				rern = false;
				clickable = true;
			}
		} 

		if(clickable){
			if(Input.GetMouseButtonDown(0)){
				go = true;
				clickable = false;
			}
			if(Input.GetMouseButtonDown(1)){
				rern = true;
				clickable = false;
			}
		}

		Camera.nearClipPlane = near;
	}
}
