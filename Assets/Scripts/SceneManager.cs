using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager: MonoBehaviour  {

	//public static bool showVectors = true; 
	//public static void SetShowVectors(bool input) {
		//showVectors = input;
	//}

	private GameObject activeObject;
	public GameObject inspector; 
	public bool inspectorState = false;
    public GameObject chargeContainer;
    public GameObject chargePrefab; 


	public void SetActiveObject(ActiveObjectManager newActiveObject) {
		
		//Deactivate current active object indicator 


		if (newActiveObject != null) {
			if (activeObject != newActiveObject.transform.gameObject) {//Verify if the object is already active. If so, deactivate. 
				if (activeObject!=null) {
					activeObject.GetComponent<ActiveObjectManager>().SetIndicatorUnactive (); 
				}
				activeObject = newActiveObject.transform.gameObject; 
				newActiveObject.SetIndicatorActive();
                inspector.transform.SetParent(newActiveObject.transform,false);
			} 
			else {
				//Nothing to do 

				//NullActiveObject ();
			}

		} 
		else {
			NullActiveObject ();
		}
		


	}
	void NullActiveObject() {
		if (activeObject!=null) {
			activeObject.GetComponent<ActiveObjectManager>().SetIndicatorUnactive (); 
		}
		activeObject = null;
		//inspector.transform.SetParent (this.transform,false);


	}

	public void ToggleInspector() {
		inspectorState = !inspectorState; 
		inspector.SetActive (inspectorState); 
		if (activeObject != null) {
			inspector.transform.SetParent (activeObject.transform,false); 
			//inspector.GetComponent<RectTransform> ().position = Vector3.zero;
		}

	}

    //NewCharges
    public void AddCharge()
    {
        GameObject newCharge = Instantiate(chargePrefab, chargeContainer.transform);
        newCharge.GetComponent<ChargeController>().spriteColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        //newCharge.GetComponent<ChargeController>().chargeInfoManagerController = chargeInfoManagerController;

    }
    public void RemoveCharge()
    {
        int numCharges = chargeContainer.transform.childCount;
        if (numCharges > 0)
        {
            Destroy(chargeContainer.transform.GetChild(numCharges - 1).gameObject);
        }

    }








}
