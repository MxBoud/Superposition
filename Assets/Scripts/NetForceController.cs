using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetForceController : MonoBehaviour {
	public VectorController [] vectorList; 
	public GameObject vectorObjectPrefab; 
	public GameObject coulombForceVectors; 

	public  VectorController netForceVector; 
	public Vector2 netForce; 

	// Use this for initialization
	void Start () {
		//UpdateVectorList ();
		netForceVector = Instantiate (vectorObjectPrefab,Vector3.zero,Quaternion.identity, this.transform).GetComponent<VectorController>();

	}
	void UpdateVectorList() {
		vectorList = null; 
		vectorList = new VectorController[10]; 
		vectorList = coulombForceVectors.GetComponentsInChildren<VectorController> (); 

		//Debug.Log (vectorList.Length); 
	}
	// Update is called once per frame
	void Update () {
		//UpdateVectorList ();
		netForce = Vector2.zero; 
		foreach (VectorController cF in vectorList) {
			netForce += cF.vector; 
		}
		netForceVector.SetVector (this.transform.position,netForce,Color.black); 



	}

	public void UpdateNetForceController(){
		UpdateVectorList ();
		//Debug.Log ("MessageReceived");
	}
		
}
