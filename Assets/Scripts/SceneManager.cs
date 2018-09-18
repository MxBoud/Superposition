using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SceneManager : MonoBehaviour
{

    //public static bool showVectors = true;
    //public static void SetShowVectors(bool input) {
    //showVectors = input;
    //}
    private GameObject previousActiveObject;
    public  GameObject activeObject;
    public GameObject inspector;
    public bool inspectorState = false;

    public GameObject chargePrefab;
    private bool sceneObjectClicked = false;
  
    public ChargeContainer chargeContainer;

    //Inspector objects: 
    public InputField chargeInputField;
    public Toggle allVectorsToOriginToggle; 

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            if(sceneObjectClicked){
                Debug.Log("ObjectClicked");
                sceneObjectClicked = false;

            }
            else {
                Debug.Log("No object clicked");
                //NullActiveObject();

            }



        }
        else {

        }
    }


    public void SetActiveObject(ActiveObjectManager newActiveObject)
    {

        //Deactivate current active object indicator


        if (newActiveObject != null)
        {
            if (activeObject != newActiveObject.transform.gameObject)
            {//Verify if the object is already active. If so, deactivate.
                if (activeObject != null)
                {
                    activeObject.GetComponent<ActiveObjectManager>().SetIndicatorUnactive();
                }
                previousActiveObject = activeObject;
                activeObject = newActiveObject.transform.gameObject;
                newActiveObject.SetIndicatorActive();
                inspector.transform.SetParent(newActiveObject.transform, false);
            }
            else
            {
                //Nothing to do

                //NullActiveObject ();
            }

        }
        else
        {
            NullActiveObject();
        }

        UpdateInspectorContent(); 

    }
    void UpdateInspectorContent() {
        ChargeController chargeController; 
        if (activeObject != null){
            chargeController = activeObject.GetComponent<ChargeController>(); 
            if (chargeController != null){
                chargeInputField.text = chargeController.Charge.ToString(); 
            }
            else {
                chargeInputField.text = "error";
            }
        }

        //chargeInputField.text = 
    }
    void NullActiveObject()
    {
        if (activeObject != null)
        {
            activeObject.GetComponent<ActiveObjectManager>().SetIndicatorUnactive();
        }
        activeObject = null;
        if (previousActiveObject != null)
        {
            inspector.transform.SetParent(previousActiveObject.transform, false);

        }
        else
        {
            // inspector.transform.SetParent(this.transform, false);
        }
        //i

    }

    public void ToggleInspector()

    {

        inspectorState = !inspectorState;
        inspector.SetActive(inspectorState);
        if (activeObject != null)
        {
            inspector.transform.SetParent(activeObject.transform, false);
            //inspector.GetComponent<RectTransform> ().position = Vector3.zero;
        }


    }

    //NewCharges
    public void AddCharge()
    {
        SceneObjectMouseDown(); // UGLY

        if (activeObject.GetComponent<ChargeController>()!=null){
            chargeContainer.AddCharge();

            //GameObject newCharge = Instantiate(chargePrefab, chargeContainer.transform);
            //ChargeController newChargeController = newCharge.GetComponent<ChargeController>();
            //newChargeController = Instantiate(activeObject.GetComponent<ChargeController>());
           // newCharge.GetComponent<ChargeController>().spriteColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

        }

        //newCharge.GetComponent<ChargeController>().chargeInfoManagerController = chargeInfoManagerController;

    }
    public void RemoveCharge()
    {
        SceneObjectMouseDown(); //UGLY
        int numCharges = chargeContainer.transform.childCount;
        if (numCharges > 0)
        {
            //if (previousActiveObject != null)
            //{
            //    inspector.transform.SetParent(previousActiveObject.transform, false);

            //}
            //else{
            //    inspector.transform.SetParent(this.gameObject.transform);
            //}
            inspector.transform.SetParent(this.gameObject.transform, false);

            inspectorState = false;
            inspector.SetActive(inspectorState);
            //NullActiveObject();
			         chargeContainer.RemoveCharge(activeObject);


        }


    }

    public void ChargeValueChanged(){
       // Debug.Log(value);
        float fValue = 0;

        if (float.TryParse(chargeInputField.text, out fValue) ){
            Debug.Log(fValue);
            activeObject.GetComponent<ChargeController>().Charge = fValue;
        }



    }
    public void ToggleAllVectorToOrigin(){
        activeObject.GetComponent<ChargeController>().attachAllVectorAtOrigin = allVectorsToOriginToggle.isOn;
        
    }


    public void SceneObjectMouseDown(){
        sceneObjectClicked = true;

    }








}
