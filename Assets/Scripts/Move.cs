using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    Vector3 pos; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pos.x = Mathf.Cos(Time.time);
        pos.y = Mathf.Sin(Time.time);
        this.transform.position = pos; 

		
	}
}
