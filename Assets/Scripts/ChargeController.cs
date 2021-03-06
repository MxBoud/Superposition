﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeController : MonoBehaviour
{
    private float charge = 1;

    public float Charge {
        set {
            charge = value;
            chargeContainer.UpdateIOOfAllCharges(); 
            Debug.Log("Charge changed");
        }
        get {
            return charge; 
        }
    }

    public Color spriteColor;
    public GameObject vectorPrefab;
    public int parentChildCount;
    public ChargeContainer chargeContainer;
    private CoulombForceVectorsController coulombForceVectorsController;
    private NetForceController netForceController; 


   // public ChargeInfoManagerController chargeInfoManagerController;
	


	//public bool showResultingVector = true; 

	public  bool attachAllVectorAtOrigin = true;

    private bool showForces = true; 
    public bool ShowForces {
        get {
            return showForces;
        }
        set {
            Debug.Log("ValueChanged");
            showForces = value;
            coulombForceVectorsController.transform.gameObject.SetActive(value);
        }
    }

    private bool showNetForce = true; 
    public bool ShowNetForce {
        set{
            showNetForce = value;
            netForceController.transform.gameObject.SetActive(value); 

        }
        get{
            return showNetForce; 
            
        }
    }


    //Transform[] chargeList;
    //VectorController[] attachedVectors;
    public InteractionInfo[] interactionInfos;

    private bool isActiveUserComponent = false;


    public void UpdateChargeList()
    {
        //Destroy all childrens
        foreach (InteractionInfo iI in interactionInfos)
        {
            Destroy(iI.interactionVector.transform.gameObject);
        }
        interactionInfos = null;
        //Repopulate childrens

        parentChildCount = this.transform.parent.childCount;
        //chargeList = new Transform[parentChildCount];
        interactionInfos = new InteractionInfo[parentChildCount - 1];

        int interactionVectorIndex = 0;
        for (int j = 0; j < parentChildCount; j++)
        {
            Transform charge1Transform = this.transform;
            Transform charge2Transform = this.transform.parent.GetChild(j);
            if (this.transform != charge2Transform)
            {
                interactionInfos[interactionVectorIndex] = new InteractionInfo();
                interactionInfos[interactionVectorIndex].q1 = Charge; //charge1.gameObject.GetComponent<ChargeController>().charge;
                interactionInfos[interactionVectorIndex].q2 = charge2Transform.gameObject.GetComponent<ChargeController>().Charge;
                interactionInfos[interactionVectorIndex].charge1Transform = charge1Transform;
                interactionInfos[interactionVectorIndex].charge2Transform = charge2Transform;
                interactionInfos[interactionVectorIndex].arrowColor = spriteColor;

                interactionInfos[interactionVectorIndex].interactionVector =
                    Instantiate(vectorPrefab, Vector3.zero, Quaternion.identity, charge2Transform.Find("CoulombForceVectors")).GetComponent<VectorController>();


                //Debug.Log(interactionVectorIndex);
                interactionVectorIndex++;

            }

        }


    }

    void UpdateCoulombVectorInteraction()
    {
        foreach (InteractionInfo iI in interactionInfos)
        {
			int vectorIndex = iI.interactionVector.transform.GetSiblingIndex (); 
			Vector2 vectorOrigin;
            if (attachAllVectorAtOrigin) { //sceneSettingsManager.allVectorsAtOrigin) {
				vectorOrigin = iI.charge2Transform.position;
			} 
			else {
				if (vectorIndex > 0) {
					VectorController previousVector = iI.interactionVector.transform.parent.GetChild (vectorIndex - 1).GetComponent<VectorController>(); 
					vectorOrigin = previousVector.origin + previousVector.vector; 
				} else {
					vectorOrigin = iI.charge2Transform.position;
				}
				
			}

			iI.interactionVector.SetVector(vectorOrigin,
				CoulombForce.Fab(iI.charge2Transform.position, iI.charge1Transform.position, iI.q2, iI.q1), iI.arrowColor);
        }
    }
    // Use this for initialization
    void Start()
    {
        //UpdateChargeList();

		
        this.transform.Find("Sprite").GetComponent<SpriteRenderer>().color = spriteColor;
        chargeContainer = GetComponentInParent<ChargeContainer>();
        coulombForceVectorsController = GetComponentInChildren<CoulombForceVectorsController>();
        netForceController = GetComponentInChildren<NetForceController>(); 
    }


    // Update is called once per frame
    void Update()
    {
        UpdateCoulombVectorInteraction();
    }

    private void OnDestroy()
    {
        foreach (InteractionInfo iI in interactionInfos)
        {
            Destroy(iI.interactionVector.transform.gameObject);
        }
        // BroadcastMessage("UpdateChargeList");
    }

    //public void SetToActiveComponent()
   //{
     //   isActiveUserComponent = true;
	//
      //  chargeInfoManagerController.SetActiveCharge(this);
      //  selectionCircle.gameObject.SetActive(true);
   // }
    //public void UnsetToActiveComponent() {
    //    selectionCircle.gameObject.SetActive(false);
        //chargeInfoManagerController.SetActiveCharge(null);
   // }

	//public void SetVectorReprensentation(bool value) {
	//	attachAllVectorAtOrigin = value; 
	//}

	//public void SceneSettingManagerChanged() {
		//Debug.Log ("SceneSettingManagerChanged"); 
	//}







}

[System.Serializable]

public class InteractionInfo {
    public float q1;
    public float q2;

    public Transform charge1Transform;
    public Transform charge2Transform;
    public VectorController interactionVector;
    public Color arrowColor; 

}

