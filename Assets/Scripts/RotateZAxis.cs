using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateZAxis : MonoBehaviour {
    public float rotationSpeed = 2; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
	}
}
