using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (FieldOfVieuw))]
public class FieldOfVieuwEditor : Editor {
	void OnSceneGUI(){
		FieldOfVieuw fow = (FieldOfVieuw)target;
		Handles.color = Color.white;
		Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);
		Vector3 vieuwAngleA = fow.DirFromAngle (-fow.viewAngle / 2, false);
		Vector3 vieuwAngleB = fow.DirFromAngle (fow.viewAngle / 2, false);

		Handles.DrawLine(fow.transform.position, fow.transform.position + vieuwAngleA * fow.viewRadius);
		Handles.DrawLine(fow.transform.position, fow.transform.position + vieuwAngleB * fow.viewRadius);

		Handles.color = Color.red;
		foreach (Transform visibleTarget in fow.visibleTargets){
			Handles.DrawLine (fow.transform.position,visibleTarget.position);
		}
	}
}
