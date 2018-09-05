using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
    public GameObject chargePrefab;
    public GameObject chargeContainer; 
    GameObject instantiatedCharge; 

    private Vector3 initialObjectPosition;
    private Vector3 initialMousePosition;
    private Camera cam; 

	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Debug.Log("MouseDown");
        initialMousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        instantiatedCharge = Instantiate(chargePrefab,initialMousePosition,Quaternion.identity); 
       
       // SendMessage("UpdateChargeList()");
       // Broad


    }
}
