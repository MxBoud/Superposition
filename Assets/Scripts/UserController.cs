using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour {

    private Vector3 initialObjectPosition;
    private Vector3 initialMousePosition;
    private Camera cam; 
	public Transform chargeSpriteTransform;

    private ChargeController chargeController; 

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        chargeController = GetComponent<ChargeController>(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
        //chargeController.SetToActiveComponent();
		//BroadcastMessage ("UpdateNetForceController"); 
        initialObjectPosition = this.transform.position;
        initialMousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
		chargeSpriteTransform.localScale = Vector3.one * 1.3f;
        //this.transform.localScale = new Vector3(2, 2, 2);
        //Debug.Log("ButtonDown");
    }

    void OnMouseUp()
    {
        this.transform.localScale = new Vector3(1, 1, 1);
		chargeSpriteTransform.localScale = Vector3.one;
        //Debug.Log("ButtonUp");
    }
    void OnMouseDrag()
    {
        Vector3 currentMousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 displacement = currentMousePosition - initialMousePosition;
		//Debug.Log (currentMousePosition);
        //if (lockUp)
        //{
        //    targetTransform.position = initialObjectPosition + Vector3.up * displacement.y;
        //}
        //else if (dontLock)
        //{
            this.transform.position = initialObjectPosition + displacement;
        //}
        //else
        //{
        //    targetTransform.position = initialObjectPosition + Vector3.right * displacement.x;
        //}



    }



}
