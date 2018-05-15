using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldOfVieuw : MonoBehaviour {
	public Material invisibleMaterial;
	private Color color = Color.white;
	private float alphaColor = 0.0f;
	public float refreshRate = 1f;
	public float viewRadius;
	[Range(0,360)]
	public float viewAngle;

	public LayerMask targetMask;
	public LayerMask obstacleMask;

	[HideInInspector]
	public List<Transform> visibleTargets = new List<Transform>();

	void Start(){
		StartCoroutine("FindTargetsWithDelay", refreshRate);
	}

	IEnumerator FindTargetsWithDelay(float delay){
		while(true){
			yield return new WaitForSeconds (delay);
			FindVisibleTargets();
		}
	}

	void FindVisibleTargets(){
		visibleTargets.Clear();

		Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position,viewRadius,targetMask);

		for(int i=0; i< targetsInViewRadius.Length; i++){
			Transform target = targetsInViewRadius [i].transform;
			Vector3 dirToTarget = (target.position - transform.position).normalized;
			if(Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2){
				float dstToTarget = Vector3.Distance(transform.position, target.position);

				if(!Physics.Raycast(transform.position,dirToTarget,dstToTarget,obstacleMask)){
						if(dstToTarget < 5){
							Debug.Log("Transparent");
							invisibleMaterial.color = new Color(250,250,250,0);
						} 
						if(dstToTarget > 5){
							Debug.Log("normal");
							invisibleMaterial.color = new Color(250,250,250,1);
						}
					visibleTargets.Add(target);
				}
			}
		}
	}

	public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal){
		if(!angleIsGlobal){
			angleInDegrees += transform.eulerAngles.y;
		}
		return new Vector3(Mathf.Sin(angleInDegrees* Mathf.Deg2Rad),0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}
}
