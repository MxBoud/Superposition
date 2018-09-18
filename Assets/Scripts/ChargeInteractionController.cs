using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeInteractionController : MonoBehaviour {
    Transform[] chargeList;
    int childCount; 
    //Transform[] interactionVectorList; 
    public GameObject vectorPrefab;
	public NetForceController netForceController ;
	//public SceneSettingsManager sceneSettingManager; 

	public void SceneSettingsManagerChanged() {
		//ToggleAttachAllVectorToOrigin (sceneSettingManager.allVectorsAtOrigin); 
		
		
	}


//    void UpdateChargeList(){
//        childCount = this.transform.childCount; 
//        chargeList = null;
//        chargeList = new Transform[childCount];
//        for (int j = 0; j<this.transform.childCount;j++){
//            chargeList[j] = this.transform.GetChild(j);
//            
//        }
//       // Debug.Log("foud " + childCount.ToString() + " childs.");
//
//        
//    }

    	void OnTransformChildrenChanged() {
		//Debug.Log ("The list of charge interaction controller's childrens have changed");

		BroadcastMessage ("UpdateChargeList",SendMessageOptions.DontRequireReceiver); 
		//BroadcastMessage ("UpdateNetForceController",SendMessageOptions.DontRequireReceiver);

	}
	// Use this for initialization
	void Start () {
        //UpdateChargeList();
		BroadcastMessage ("UpdateChargeList",SendMessageOptions.DontRequireReceiver); 
		//BroadcastMessage ("UpdateNetForceController",SendMessageOptions.DontRequireReceiver); 
       // UpdateInteractionVectors();
		
	}
	public void ToggleAttachAllVectorToOrigin(bool value) {
		
		BroadcastMessage ("SetVectorReprensentation",value); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
