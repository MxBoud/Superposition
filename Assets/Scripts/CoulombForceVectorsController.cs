using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoulombForceVectorsController : MonoBehaviour {
	public NetForceController netForceController; 

	// Use this for initialization
	void Start () {
		
	}
	void OnTransformChildrenChanged() {
		netForceController.UpdateNetForceController (); 
	}

}
