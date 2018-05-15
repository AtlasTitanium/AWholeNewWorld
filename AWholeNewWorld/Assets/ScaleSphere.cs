using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSphere : MonoBehaviour {

	public float speed;
	
	private float scroll;
	
	// Update is called once per frame
	void Update () {
		scroll = Input.GetAxis("Mouse ScrollWheel");
		if(Input.GetMouseButtonDown(0)){
			Debug.Log("ye");
			this.transform.localScale = new Vector3(this.transform.localScale.x + speed, this.transform.localScale.y + speed, this.transform.localScale.z + speed);
		}
		 if (scroll > 0f){
			this.transform.localScale = new Vector3(this.transform.localScale.x + speed/2, this.transform.localScale.y + speed/2, this.transform.localScale.z + speed/2);
		}
		else if (scroll < 0f){
			this.transform.localScale = new Vector3(this.transform.localScale.x - speed/2, this.transform.localScale.y - speed/2, this.transform.localScale.z - speed/2);
		}
		if(Input.GetMouseButtonDown(1)){
			Debug.Log("no");
			this.transform.localScale = new Vector3(1,1,1);
		}
	}
}
